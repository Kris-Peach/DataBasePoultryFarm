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
    /// Логика взаимодействия для GildMaxBreed.xaml
    /// </summary>
    public partial class GildMaxBreed : Window
    {
        SqlConnection sqlcn = new SqlConnection();
       
        public GildMaxBreed(SqlConnection cn)
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
            CmbGild.ItemsSource = breeds;
            sqlcn.Close();
        }
        private void BtnGildClick(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.AboutHens ah = new AboutHens(sqlcn);
            ah.Show();
            this.Close();
        }
        private void ComboBox_Selected(object sender, SelectionChangedEventArgs args)
        {
            
           SqlCommand myCommand = sqlcn.CreateCommand();
           myCommand.CommandType = CommandType.StoredProcedure;
           myCommand.CommandText = "[DepartmentMAXCountBreed]";
            string NameBreed = CmbGild.SelectedValue.ToString();
           myCommand.Parameters.Add("@NameBreed", SqlDbType.VarChar, 50);
           myCommand.Parameters["@NameBreed"].Value = NameBreed;
           sqlcn.Open();
           myCommand.ExecuteScalar();
           TbxGild.Text = "";
           TbxGild.Text = Convert.ToString(myCommand.ExecuteScalar());
           sqlcn.Close();
            
           
        }
    }
}
