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
    /// Логика взаимодействия для Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        SqlConnection sqlcn = new SqlConnection();
        private DataTable _datasource = new DataTable();
        public Report(SqlConnection cn)
        {
            InitializeComponent();
            sqlcn = cn;
            SqlCommand myCommand = sqlcn.CreateCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "[Report]";
            sqlcn.Open();
            SqlDataReader dataReader = myCommand.ExecuteReader();
            _datasource.Load(dataReader);
            dataReader.Close();
            Binding bind = new Binding();
            DG1.DataContext = _datasource;
            DG1.SetBinding(DataGrid.ItemsSourceProperty, bind);

            myCommand.CommandText = "[FinalValue]";
            dataReader = myCommand.ExecuteReader();
            dataReader.Read();
            CounHens.Content = dataReader.GetInt32(0).ToString();
            AvgPer.Content = dataReader.GetInt32 (1).ToString();
            Per.Content = dataReader.GetInt32(2).ToString();
            dataReader.Close();
            sqlcn.Close();
        }
        private void BtnEggsEWClick(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.Menu aw = new Menu(sqlcn);
            aw.Show();
            this.Close();
        }
    }

}
