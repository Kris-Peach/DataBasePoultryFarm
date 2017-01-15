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


namespace DataBasePoultryFarm
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        SqlConnection sqlcn = new SqlConnection();
        public Menu(SqlConnection cn)
        {
            InitializeComponent();
            sqlcn = cn;
        }
        private void BtnExMenuClick(object sender, RoutedEventArgs e)
        {
            sqlcn.Close();
            this.Close();
        }
        private void BtnMenu1Click(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.AboutWorker aw = new AboutWorker(sqlcn);
            aw.Show();
            this.Close();
        }
        private void BtnMenu2Click(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.AboutHens ah = new AboutHens(sqlcn);
            ah.Show();
            this.Close();
        }
        private void BtnMenu3Click(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.Report rep = new Report(sqlcn);
            rep.Show();
            this.Close();
        }
    }
}
