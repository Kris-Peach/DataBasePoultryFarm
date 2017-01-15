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
    /// Логика взаимодействия для AddCell.xaml
    /// </summary>
    public partial class AddCell : Window
    {
        SqlConnection sqlcn = new SqlConnection();
        public AddCell(SqlConnection cn)
        {
            InitializeComponent();
            sqlcn = cn;

        }
        private void BtnAddWClick(object sender, RoutedEventArgs e)
        {
            string code = TbxAddW1.Text.ToString();
            string depart = TbxAddW2.Text.ToString();
            string line = TbxAddW3.Text.ToString();
            string num = TbxAddW4.Text.ToString();
            bool b = false;
            if (code == null | depart == null | line == null | num == null)
            { MessageBox.Show("Неправильно заполнены или пустые поля!"); }
            else
            {
                SqlCommand myCommand = sqlcn.CreateCommand();
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "[AddCell]";

                myCommand.Parameters.Add("@Code", SqlDbType.Int);
                myCommand.Parameters["@Code"].Value = int.Parse(code);

                myCommand.Parameters.Add("@Department", SqlDbType.Int);
                myCommand.Parameters["@Department"].Value = int.Parse(depart);

                myCommand.Parameters.Add("@Line", SqlDbType.Int);
                myCommand.Parameters["@Line"].Value = int.Parse(line);

                myCommand.Parameters.Add("@Number", SqlDbType.Int);
                myCommand.Parameters["@Number"].Value = int.Parse(num);
                sqlcn.Open();
                myCommand.ExecuteScalar();
                sqlcn.Close();
                b = true;
                MessageBox.Show("Добавлено!");
            }
            if (b == true)
            {
                TbxAddW1.Text = "";
                TbxAddW2.Text = "";
                TbxAddW3.Text = "";
                TbxAddW4.Text = "";
            }
            
        }
        private void BtnAddWExClick(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.Hens h = new Hens(sqlcn);
            h.Show();
            this.Close();
        }
    }
}
