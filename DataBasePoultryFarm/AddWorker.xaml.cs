using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;

namespace DataBasePoultryFarm
{
    /// <summary>
    /// Логика взаимодействия для AddWorker.xaml
    /// </summary>
    public partial class AddWorker : Window
    {
        SqlConnection sqlcn = new SqlConnection();
        private string position;
        public AddWorker(SqlConnection cn)
        {
            InitializeComponent();
            sqlcn = cn;
            SqlCommand myCommand = sqlcn.CreateCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "[AllPosition]";
            sqlcn.Open();
            SqlDataReader dataReader = myCommand.ExecuteReader();
            List<string> worker = new List<string>();
            while (dataReader.Read())
            {
                string str = dataReader["Название должности"].ToString();
                worker.Add(str);
            }
            CmbAddW.ItemsSource = worker;
            sqlcn.Close();
        }
        private void ComboBox_Selected(object sender, SelectionChangedEventArgs args)
        {
            position = CmbAddW.SelectedValue.ToString();
        }
        private void BtnAddWClick(object sender, RoutedEventArgs e)
        {
            bool b = false;
            string pasport = TbxAddW1.Text.ToString();
            string record = TbxAddW2.Text.ToString();
            string fullname = TbxAddW3.Text.ToString();
            if (pasport == null | record == null | fullname == null | position == null)
            { MessageBox.Show("Неправильно заполнены или пустые поля!"); }
            else
            {
                SqlCommand myCommand = sqlcn.CreateCommand();
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "[AddWorker]";

                myCommand.Parameters.Add("@Pasport", SqlDbType.VarChar, 50);
                myCommand.Parameters["@Pasport"].Value = pasport;

                myCommand.Parameters.Add("@RecordOfService", SqlDbType.VarChar, 50);
                myCommand.Parameters["@RecordOfService"].Value = record;

                myCommand.Parameters.Add("@FullName", SqlDbType.VarChar, 50);
                myCommand.Parameters["@FullName"].Value = fullname;

                myCommand.Parameters.Add("@Position", SqlDbType.VarChar, 50);
                myCommand.Parameters["@Position"].Value = position;
                sqlcn.Open();
                myCommand.ExecuteScalar();
                sqlcn.Close();
                b = true;
                MessageBox.Show("Добавлено!");
            }
            if(b== true)
            {
                TbxAddW1.Text = "";
                TbxAddW2.Text = "";
                TbxAddW3.Text = "";
            }
           
        }
        private void BtnAddWExClick(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.Workers w = new Workers(sqlcn);
            w.Show();
            this.Close();
        }
    }
}
