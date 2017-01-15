using System.Windows;
using System.Data.SqlClient;
using System.Data;

namespace DataBasePoultryFarm
{
    /// <summary>
    /// Логика взаимодействия для GildMaxHens.xaml
    /// </summary>
    public partial class GildMaxHens : Window
    {
        SqlConnection sqlcn = new SqlConnection();
        public GildMaxHens(SqlConnection cn)
        {
            InitializeComponent();
            sqlcn = cn;
            SqlCommand myCommand = sqlcn.CreateCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "[DepartmentWithHen]";
            sqlcn.Open();
            SqlDataReader dataReader = myCommand.ExecuteReader();
            dataReader.Read();
            //while (dataReader.Read())
            //{
            TbGilHensd1.Text = dataReader.GetInt32(0).ToString();
            TbGilHensd2.Text = dataReader.GetString(1);
            TbGilHensd3.Text = dataReader.GetInt32(2).ToString();
            TbGilHensd4.Text = dataReader.GetInt32(3).ToString();
            //}
            dataReader.Close();
            sqlcn.Close();
           
        }
        private void BtnMH1Click(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.AboutHens ah = new AboutHens(sqlcn);
            ah.Show();
            this.Close();
        }
    }
}
