using System.Data.SqlClient;
using System.Windows;


namespace DataBasePoultryFarm
{
    /// <summary>
    /// Логика взаимодействия для Authentication.xaml
    /// </summary>
    public partial class Authentication : Window
    {
        public Authentication()
        {
            InitializeComponent();
        }
        private void BtnCancel_1Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void BtnEnterClick(object sender, RoutedEventArgs e)
        {
            bool b = false;
            SqlConnection cn = new SqlConnection();
            try
            {
                SqlConnectionStringBuilder connect = new SqlConnectionStringBuilder();
                connect.DataSource = @"DESKTOP-VUCNPEH\SQLEXPRESS";
                connect.InitialCatalog = "Poultry Farm";
                connect.ConnectTimeout = 15;
                connect.PersistSecurityInfo = false;
                connect.UserID = TbUsr.Text;
                connect.Password = TbPas.Password;
                
                    cn.ConnectionString = connect.ConnectionString;
                    cn.Open();
                    b = true;
                
            }
            catch
            {
                MessageBox.Show("Неправильно Пользователь или Пароль!");
                cn.Close();
            }
            if (b)
            {
                DataBasePoultryFarm.MainWindow MainWindow = new MainWindow( cn);
                MainWindow.Show();
                cn.Close();
                this.Close();
            }
            
        }
    }
}
