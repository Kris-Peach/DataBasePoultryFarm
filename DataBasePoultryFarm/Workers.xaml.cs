using System.Windows;
using System.Data.SqlClient;

namespace DataBasePoultryFarm
{
    /// <summary>
    /// Логика взаимодействия для Workers.xaml
    /// </summary>
    public partial class Workers : Window
    {
        SqlConnection sqlcn = new SqlConnection();
        public Workers(SqlConnection cn)
        {
            InitializeComponent();
            sqlcn = cn;
        }
        private void BtnWorkerBackClick(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.AboutWorker aw = new AboutWorker(sqlcn);
            aw.Show();
            this.Close();
        }
        private void BtnWork1Click(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.AddWorker aw = new AddWorker(sqlcn);
            aw.Show();
            this.Close();
        }
        private void BtnWork2Click(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.DeleteWorker dw = new DeleteWorker(sqlcn);
            dw.Show();
            this.Close();
        }
        private void BtnWork3Click(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.AddPosition ap = new AddPosition(sqlcn);
            ap.Show();
            this.Close();
        }
        private void BtnWork4Click(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.DeletePosition dp = new DeletePosition(sqlcn);
            dp.Show();
            this.Close();
        }
        private void BtnWork5Click(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.HumansOfPosition hp = new HumansOfPosition(sqlcn);
            hp.Show();
            this.Close();
        }
       

    }
}
