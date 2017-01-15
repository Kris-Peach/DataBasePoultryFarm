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
    /// Логика взаимодействия для PerfomanceHens.xaml
    /// </summary>
    public partial class PerfomanceHens : Window
    {
        SqlConnection sqlcn = new SqlConnection();
        private DataTable _datasource = new DataTable();
        public PerfomanceHens(SqlConnection cn)
        {
            InitializeComponent();
            sqlcn = cn;
            SqlCommand myCommand = sqlcn.CreateCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "[AllHens]";
            sqlcn.Open();
            SqlDataReader dataReader = myCommand.ExecuteReader();
            List<string> hens = new List<string>();
            while (dataReader.Read())
            {
                string str = dataReader["№Курицы"].ToString();
                hens.Add(str);
            }
            CmbPer.ItemsSource = hens;
            sqlcn.Close();
        }
        private void BtnPerClick(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.AboutHens ah = new AboutHens(sqlcn);
            ah.Show();
            this.Close();
        }
        private void ComboBox_Selected(object sender, SelectionChangedEventArgs args)
        {
            SqlCommand myCommand = sqlcn.CreateCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "[PerfomanceHens]";
            int Num = Int32.Parse(CmbPer.SelectedValue.ToString());
            myCommand.Parameters.Add("@Num", SqlDbType.Int);
            myCommand.Parameters["@Num"].Value = Num;
            sqlcn.Open();
            myCommand.ExecuteScalar();
            TbxPer.Text = "";
            TbxPer.Text = Convert.ToString(myCommand.ExecuteScalar());
            sqlcn.Close();

        }
    }
}
