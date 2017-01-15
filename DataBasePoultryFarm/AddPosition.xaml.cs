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
    /// Логика взаимодействия для AddPosition.xaml
    /// </summary>
    public partial class AddPosition : Window
    {
        SqlConnection sqlcn = new SqlConnection();
        public AddPosition(SqlConnection cn)
        {
            InitializeComponent();
            sqlcn = cn;
        }
        private void BtnAddPClick(object sender, RoutedEventArgs e)
        {
            bool b = false;
            string namepos = TbxAddP1.Text.ToString();
            string salary = TbxAddP2.Text.ToString();
            if(namepos == null | salary == null)
            {
                MessageBox.Show("Неправильно заполнены или пустые поля!");
            }
            else
            {
                SqlCommand myCommand = sqlcn.CreateCommand();
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "[AddPosition]";

                myCommand.Parameters.Add("@NamePosition", SqlDbType.VarChar, 50);
                myCommand.Parameters["@NamePosition"].Value = namepos;

                myCommand.Parameters.Add("@Salary", SqlDbType.SmallMoney);
                myCommand.Parameters["@Salary"].Value = Int32.Parse(salary);

                sqlcn.Open();
                myCommand.ExecuteScalar();
                sqlcn.Close();
                b = true;
                MessageBox.Show("Добавлено!");
            }
            if(b == true)
            {
                TbxAddP1.Text = "";
                TbxAddP2.Text = "";
            }
        }
        private void BtnAddPExClick(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.Workers w = new Workers(sqlcn);
            w.Show();
            this.Close();
        }
    }
}
