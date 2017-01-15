using System.Windows;
using System.Data.SqlClient;

namespace DataBasePoultryFarm
{
    /// <summary>
    /// Логика взаимодействия для Hens.xaml
    /// </summary>
    public partial class Hens : Window
    {
        SqlConnection sqlcn = new SqlConnection();
        public Hens(SqlConnection cn)
        {
            InitializeComponent();
            sqlcn = cn;
        }
        private void BtnHens1Click(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.AddHens ah = new AddHens(sqlcn);
            ah.Show();
            this.Close();
        }
        private void BtnHens2Click(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.DeleteHens dh = new DeleteHens(sqlcn);
            dh.Show();
            this.Close();
        }
        private void BtnHens3Click(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.AddCell ac = new AddCell(sqlcn);
            ac.Show();
            this.Close();
        }
        private void BtnHens4Click(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.DeleteCell dc = new DeleteCell(sqlcn);
            dc.Show();
            this.Close();
        }
        private void BtnHensBackClick(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.AboutHens aw = new AboutHens(sqlcn);
            aw.Show();
            this.Close();
        }
    }
}
