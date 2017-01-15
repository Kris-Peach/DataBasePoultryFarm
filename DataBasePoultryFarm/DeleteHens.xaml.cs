using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;

namespace DataBasePoultryFarm
{
    /// <summary>
    /// Логика взаимодействия для DeleteHens.xaml
    /// </summary>
    public partial class DeleteHens : Window
    {
        SqlConnection sqlcn = new SqlConnection();
        private string code;
        public DeleteHens(SqlConnection cn)
        {
            InitializeComponent();
            sqlcn = cn;
            SqlCommand myCommand = sqlcn.CreateCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "[AllHens]";
            sqlcn.Open();
            SqlDataReader dataReader = myCommand.ExecuteReader();
            List<string> cell = new List<string>();
            while (dataReader.Read())
            {
                string str = dataReader["№Курицы"].ToString();
                cell.Add(str);
            }
            CmbDP.ItemsSource = cell;
            sqlcn.Close();
        }
        private void ComboBox_Selected(object sender, SelectionChangedEventArgs args)
        {
            code = CmbDP.SelectedValue.ToString();
        }
        private void BtnDPClick(object sender, RoutedEventArgs e)
        {
            if (code == null)
            { MessageBox.Show("укажите № курицы!"); }
            else
            {
                SqlCommand myCommand = sqlcn.CreateCommand();
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "[DeleteService]";
                myCommand.Parameters.Add("@NumHen", SqlDbType.Int);
                myCommand.Parameters["@NumHen"].Value = int.Parse(code);
                sqlcn.Open();
                myCommand.ExecuteScalar();
                myCommand.Parameters.Clear();
                myCommand.CommandText = "[DeleteHen]";
                myCommand.Parameters.Add("@NumHen", SqlDbType.Int);
                myCommand.Parameters["@NumHen"].Value = int.Parse(code);
                myCommand.ExecuteScalar();
                sqlcn.Close();
                MessageBox.Show("Удалено!");
            }
        }
        private void BtnDPExClick(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.Hens h = new Hens(sqlcn);
            h.Show();
            this.Close();
        }
    }
}
