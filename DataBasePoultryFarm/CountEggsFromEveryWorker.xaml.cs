using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Data;

namespace DataBasePoultryFarm
{
    /// <summary>
    /// Логика взаимодействия для CountEggsFromEveryWorker.xaml
    /// </summary>
    public partial class CountEggsFromEveryWorker : Window
    {
        SqlConnection sqlcn = new SqlConnection();
        private DataTable _datasource = new DataTable();
        public CountEggsFromEveryWorker(SqlConnection cn)
        {
            InitializeComponent();
            sqlcn = cn;
            SqlCommand myCommand = sqlcn.CreateCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "[PerfomanceHensByWorker]";
            sqlcn.Open();
            SqlDataReader dataReader = myCommand.ExecuteReader();
            _datasource.Load(dataReader);
            dataReader.Close();
            Binding bind = new Binding();
            DG1.DataContext = _datasource;
            DG1.SetBinding(DataGrid.ItemsSourceProperty, bind);
            sqlcn.Close();
        }
        private void BtnEggsEWClick(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.AboutWorker aw = new AboutWorker(sqlcn);
            aw.Show();
            this.Close();
        }
    }
}
