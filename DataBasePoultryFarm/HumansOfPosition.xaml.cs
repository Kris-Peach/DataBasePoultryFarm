using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Data;

namespace DataBasePoultryFarm
{
    /// <summary>
    /// Логика взаимодействия для HumansOfPosition.xaml
    /// </summary>
    public partial class HumansOfPosition : Window
    {
        SqlConnection sqlcn = new SqlConnection();
        
        public HumansOfPosition(SqlConnection cn)
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
            CmbPos.ItemsSource = worker;
            sqlcn.Close();
        }
        private void ComboBox_Selected(object sender, SelectionChangedEventArgs args)
        {
            DataTable _datasource = new DataTable();
            SqlCommand myCommand = sqlcn.CreateCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "[HumanResourcesOfPosition]";
            string position = CmbPos.SelectedValue.ToString();
            myCommand.Parameters.Add("@Position", SqlDbType.VarChar, 50);
            myCommand.Parameters["@Position"].Value = position;
            sqlcn.Open();
            SqlDataReader dataReader = myCommand.ExecuteReader();
            _datasource.Load(dataReader);
            dataReader.Close();
            Binding bind = new Binding();
            DG1.DataContext = _datasource;
            DG1.SetBinding(DataGrid.ItemsSourceProperty, bind);
            sqlcn.Close();
        }
        private void BtnPosClick(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.Workers wor = new Workers(sqlcn);
            wor.Show();
            this.Close();
        }
    }
}
