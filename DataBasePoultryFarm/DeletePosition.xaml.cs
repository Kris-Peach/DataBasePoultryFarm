using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;


namespace DataBasePoultryFarm
{
    /// <summary>
    /// Логика взаимодействия для DeletePosition.xaml
    /// </summary>
    public partial class DeletePosition : Window
    {
        SqlConnection sqlcn = new SqlConnection();
        private string position;
        public DeletePosition(SqlConnection cn)
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
            CmbDP.ItemsSource = worker;
            sqlcn.Close();
        }
        private void ComboBox_Selected(object sender, SelectionChangedEventArgs args)
        {
            position = CmbDP.SelectedValue.ToString();
        }
        private void BtnDPClick(object sender, RoutedEventArgs e)
        {
            if (position == null)
            { MessageBox.Show("укажите должность!"); }
            else
            {
                SqlCommand myCommand = sqlcn.CreateCommand();
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "[DeletePosition]";
                myCommand.Parameters.Add("@NamePosition", SqlDbType.VarChar, 50);
                myCommand.Parameters["@NamePosition"].Value = position;
                sqlcn.Open();
                myCommand.ExecuteScalar();
                sqlcn.Close();
                MessageBox.Show("Удалено!");
            }
        }
        private void BtnDPExClick(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.Workers w = new Workers(sqlcn);
            w.Show();
            this.Close();
        }
    }
}
