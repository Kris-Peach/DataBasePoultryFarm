using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;

namespace DataBasePoultryFarm
{
    /// <summary>
    /// Логика взаимодействия для DeleteCell.xaml
    /// </summary>
    public partial class DeleteCell : Window
    {
        SqlConnection sqlcn = new SqlConnection();
        private string code;
        public DeleteCell(SqlConnection cn)
        {
            InitializeComponent();
            sqlcn = cn;
            SqlCommand myCommand = sqlcn.CreateCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "[AllCell]";
            sqlcn.Open();
            SqlDataReader dataReader = myCommand.ExecuteReader();
            List<string> cell = new List<string>();
            while (dataReader.Read())
            {
                string str = dataReader["КодКлетки"].ToString();
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
            { MessageBox.Show("укажите код клеки!"); }
            else
            {
                SqlCommand myCommand = sqlcn.CreateCommand();
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "[DeleteCell]";
                myCommand.Parameters.Add("@Code", SqlDbType.Int);
                myCommand.Parameters["@Code"].Value = int.Parse(code);
                sqlcn.Open();
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
