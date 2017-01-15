using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace DataBasePoultryFarm
{
    /// <summary>
    /// Логика взаимодействия для AddHens.xaml
    /// </summary>
    public partial class AddHens : Window
    {
        SqlConnection sqlcn = new SqlConnection();
        private string code;
        private string breed;
        private string worker;
        public AddHens(SqlConnection cn)
        {
            InitializeComponent();
            sqlcn = cn;
            SqlCommand myCommand = sqlcn.CreateCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            sqlcn.Open();
            myCommand.CommandText = "[FreeCell]";
            SqlDataReader dataReader1= myCommand.ExecuteReader();
            
            List<string> cell = new List<string>();
            while (dataReader1.Read())
            {
                string str = dataReader1["КодКлетки"].ToString();
                cell.Add(str);
            }
            dataReader1.Close();
            CmbAddH1.ItemsSource = cell;

            myCommand.CommandText = "[AllBreed]";
            SqlDataReader dataReader2 = myCommand.ExecuteReader();
            List<string> breeds = new List<string>();
            while (dataReader2.Read())
            {
                string str = dataReader2["НазваниеПороды"].ToString();
                breeds.Add(str);
            }
            dataReader2.Close();
            CmbAddH2.ItemsSource = breeds;

            myCommand.CommandText = "[WorkerCareForHens]";
            myCommand.Parameters.Add("@Position", SqlDbType.VarChar, 50);
            myCommand.Parameters["@Position"].Value = "Рабочий по уходу за птицей";

            SqlDataReader dataReader3 = myCommand.ExecuteReader();
            List<string> workers = new List<string>();
            while (dataReader3.Read())
            {
                string str = dataReader3["ФИО"].ToString();
                workers.Add(str);
            }
            dataReader3.Close();
            CmbAddH3.ItemsSource = workers;
            sqlcn.Close();
        }
        private void ComboBox_Selected1(object sender, SelectionChangedEventArgs args)
        {
            code = CmbAddH1.SelectedValue.ToString();
        }
        private void ComboBox_Selected2(object sender, SelectionChangedEventArgs args)
        {
            breed = CmbAddH2.SelectedValue.ToString();
        }
        private void ComboBox_Selected3(object sender, SelectionChangedEventArgs args)
        {
            worker = CmbAddH3.SelectedValue.ToString();
        }
        private void BtnAddWClick(object sender, RoutedEventArgs e)
        {
            bool b = false;
            string weight = TbxAddW1.Text.ToString();
            string date = TbxAddW2.Text.ToString();
            string counteggs = TbxAddW3.Text.ToString();
            if (code == null | breed == null | worker == null | weight == null | date == null | counteggs == null)
            { MessageBox.Show("Неправильно заполнены или пустые поля!"); }
            else
            {
                //добавление курицы
                SqlCommand myCommand = sqlcn.CreateCommand();
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "[AddHens]";

                myCommand.Parameters.Add("@Code", SqlDbType.Int);
                myCommand.Parameters["@Code"].Value = Int32.Parse(code);

                myCommand.Parameters.Add("@Breed", SqlDbType.VarChar, 50);
                myCommand.Parameters["@Breed"].Value = breed;

                myCommand.Parameters.Add("@Weight", SqlDbType.Float);
                myCommand.Parameters["@Weight"].Value = float.Parse(code);

                myCommand.Parameters.Add("@Date", SqlDbType.Date);
                myCommand.Parameters["@Date"].Value = date;

                myCommand.Parameters.Add("@Count", SqlDbType.Int);
                myCommand.Parameters["@Count"].Value = Int32.Parse(counteggs);

                sqlcn.Open();
                myCommand.ExecuteScalar();
                myCommand.Parameters.Clear();
                //получение номера паспорта по фамилии рабочего
                myCommand.CommandText = "[Pasport]";

                myCommand.Parameters.Add("@FullName", SqlDbType.VarChar, 50);
                myCommand.Parameters["@FullName"].Value = worker;
                string pasport = myCommand.ExecuteScalar().ToString();
                myCommand.Parameters.Clear();
                //добавление связи "обслуживает"
                myCommand.CommandText = "[AddService]";

                myCommand.Parameters.Add("@Pasport", SqlDbType.VarChar, 50);
                myCommand.Parameters["@Pasport"].Value = pasport;

                myCommand.Parameters.Add("@Code", SqlDbType.Int);
                myCommand.Parameters["@Code"].Value = int.Parse(code);

                myCommand.ExecuteScalar();
                sqlcn.Close();
                b = true;
                MessageBox.Show("Добавлено!");
            }
        }
        private void BtnAddWExClick(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.Hens h = new Hens(sqlcn);
            h.Show();
            this.Close();
        }
    }
}
