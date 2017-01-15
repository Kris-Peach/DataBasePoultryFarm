using System.Windows;
using System.Data.SqlClient;

namespace DataBasePoultryFarm
{
    /// <summary>
    /// Логика взаимодействия для AboutHens.xaml
    /// </summary>
    public partial class AboutHens : Window
    {
        SqlConnection sqlcn = new SqlConnection();
        public AboutHens(SqlConnection cn)
        {
            InitializeComponent();
            sqlcn = cn;
        }
        private void BtnEHensBackClick(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.Menu mn = new Menu(sqlcn);
            mn.Show();
            this.Close();
        }
        private void BtnHens1Click(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.Hens h = new Hens(sqlcn);
            h.Show();
            this.Close();
        }
        private void BtnHens2Click(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.PerfomanceHens ph = new PerfomanceHens(sqlcn);
            ph.Show();
            this.Close();
        }
        private void BtnHens3Click(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.GildMaxBreed gmb = new GildMaxBreed(sqlcn);
            gmb.Show();
            this.Close();
        }
        private void BtnHens4Click(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.GildMaxHens gmh = new GildMaxHens(sqlcn);
            gmh.Show();
            this.Close();
        }
        private void BtnHens5Click(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.CountHensInDepartment chid = new CountHensInDepartment(sqlcn);
            chid.Show();
            this.Close();
        }
        private void BtnHens6Click(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.PerfomanceFactory pf = new PerfomanceFactory(sqlcn);
            pf.Show();
            this.Close();
        }
        private void BtnHens7Click(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.AboutBreed ab = new AboutBreed(sqlcn);
            ab.Show();
            this.Close();
        }
    }
}
