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
    /// Логика взаимодействия для AboutBreed.xaml
    /// </summary>
    public partial class AboutBreed : Window
    {
        SqlConnection sqlcn = new SqlConnection();
        private string breed;
        public AboutBreed(SqlConnection cn)
        {
            InitializeComponent();
            sqlcn = cn;
            SqlCommand myCommand = sqlcn.CreateCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "[AllBreed]";
            sqlcn.Open();
            SqlDataReader dataReader = myCommand.ExecuteReader();
            List<string> breeds = new List<string>();
            while (dataReader.Read())
            {
                string str = dataReader["НазваниеПороды"].ToString();
                breeds.Add(str);
            }
            CmbPos.ItemsSource = breeds;
            sqlcn.Close();
        }
        private void ComboBox_Selected(object sender, SelectionChangedEventArgs args)
        {
            breed = CmbPos.SelectedValue.ToString();

            SqlCommand myCommand = sqlcn.CreateCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "[AboutBreed]";
            myCommand.Parameters.Add("@NameBreed", SqlDbType.VarChar, 50);
            myCommand.Parameters["@NameBreed"].Value = breed;
            sqlcn.Open();
            SqlDataReader dataReader = myCommand.ExecuteReader();
            dataReader.Read();
            TbxBred1.Text = dataReader.GetInt32(1).ToString();
            TbxBred2.Text = dataReader.GetDouble(2).ToString();
            TbxBred3.Text = dataReader.GetInt32(3).ToString();
            TbxBred4.Text = dataReader.GetInt32(6).ToString();
            TbxBred5.Text = dataReader.GetDouble(5).ToString();
            TbxBred6.Text = dataReader.GetInt32(4).ToString();
            dataReader.Close();
            sqlcn.Close();
        }
        private void BtnPosClick(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.AboutHens ah = new AboutHens(sqlcn);
            ah.Show();
            this.Close();
        }
    }
}
