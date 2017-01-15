using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;

namespace DataBasePoultryFarm
{
    /// <summary>
    /// Логика взаимодействия для CountEggsFromWorker.xaml
    /// </summary>
    public partial class CountEggsFromWorker : Window
    {
        SqlConnection sqlcn = new SqlConnection();
        public CountEggsFromWorker(SqlConnection cn)
        {
            InitializeComponent();
            sqlcn = cn;
            SqlCommand myCommand = sqlcn.CreateCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "[WorkerCareForHens]";
            myCommand.Parameters.Add("@Position", SqlDbType.VarChar, 50);
            myCommand.Parameters["@Position"].Value = "Рабочий по уходу за птицей";
            sqlcn.Open();
            SqlDataReader dataReader = myCommand.ExecuteReader();
            List<string> worker = new List<string>();
            while (dataReader.Read())
            {
                string str = dataReader["ФИО"].ToString();
                worker.Add(str);
            }
            CmbEggs.ItemsSource = worker;
            sqlcn.Close();
        }
        private void BtnEggsClick(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.AboutWorker aw = new AboutWorker(sqlcn);
            aw.Show();
            this.Close();
        }
        private void ComboBox_Selected(object sender, SelectionChangedEventArgs args)
        {
            SqlCommand myCommand = sqlcn.CreateCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "[CountEggsFromWorker]";
            string FullName = CmbEggs.SelectedValue.ToString();
            myCommand.Parameters.Add("@FullName", SqlDbType.VarChar, 50);
            myCommand.Parameters["@FullName"].Value = FullName;
            sqlcn.Open();
            myCommand.ExecuteScalar();
            TbxEggs.Text = "";
            TbxEggs.Text = Convert.ToString(myCommand.ExecuteScalar());
            sqlcn.Close();

        }
    }
}
