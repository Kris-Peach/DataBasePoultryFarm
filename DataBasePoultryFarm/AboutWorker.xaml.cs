using System.Windows;
using System.Data.SqlClient;

namespace DataBasePoultryFarm
{
    /// <summary>
    /// Логика взаимодействия для AboutWorker.xaml
    /// </summary>
    public partial class AboutWorker : Window
    {
        SqlConnection sqlcn = new SqlConnection();
        public AboutWorker(SqlConnection cn)
        {
            InitializeComponent();
            sqlcn = cn;
        }
        private void BtnEWorkerBackClick(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.Menu mn = new Menu(sqlcn);
            mn.Show();
            this.Close();
        }
        private  void BtnWorker1Click(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.Workers w = new Workers(sqlcn);
            w.Show();
            this.Close();
        }
        private void BtnWorker2Click(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.CountEggsFromWorker cefw = new CountEggsFromWorker(sqlcn);
            cefw.Show();
            this.Close();
        }
        private void BtnWorker3Click(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.CountEggsFromEveryWorker cerew = new CountEggsFromEveryWorker(sqlcn);
            cerew.Show();
            this.Close();
        }
        private void BtnWorker4Click(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.CountHensForWorker chfw = new CountHensForWorker(sqlcn);
            chfw.Show();
            this.Close();
        }
    }
}
