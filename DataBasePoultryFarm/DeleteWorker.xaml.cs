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
    /// Логика взаимодействия для DeleteWorker.xaml
    /// </summary>
    public partial class DeleteWorker : Window
    {
        SqlConnection sqlcn = new SqlConnection();
        private string pasport;
        public DeleteWorker(SqlConnection cn)
        {
            InitializeComponent();
            sqlcn = cn;
            SqlCommand myCommand = sqlcn.CreateCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "[AllWorkers]";
            sqlcn.Open();
            SqlDataReader dataReader = myCommand.ExecuteReader();
            List<string> worker = new List<string>();
            while (dataReader.Read())
            {
                string str = dataReader["№Паспорта"].ToString();
                worker.Add(str);
            }
            CmbDW.ItemsSource = worker;
            sqlcn.Close();
        }
        private void ComboBox_Selected(object sender, SelectionChangedEventArgs args)
        {
            pasport = CmbDW.SelectedValue.ToString();
        }
        private void BtnDPClick(object sender, RoutedEventArgs e)
        {
            if (pasport == null)
            { MessageBox.Show("укажите № паспорта!"); }
            else
            {
                SqlCommand myCommand = sqlcn.CreateCommand();
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "[DeleteWorker]";
                myCommand.Parameters.Add("@Pasport", SqlDbType.VarChar, 50);
                myCommand.Parameters["@Pasport"].Value = pasport;
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
