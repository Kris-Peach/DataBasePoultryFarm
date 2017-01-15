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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace DataBasePoultryFarm
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlcn = new SqlConnection();
        public MainWindow(SqlConnection cn)
        {
            InitializeComponent();
            sqlcn = cn;
        }
        private void BtnExitClick(object sender, RoutedEventArgs e)
        {
            sqlcn.Close();
            this.Close();
            
        }
        private void BtnGoClick(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.Menu mn = new Menu(sqlcn);
            mn.Show();
            this.Close();
        }
    }
}
