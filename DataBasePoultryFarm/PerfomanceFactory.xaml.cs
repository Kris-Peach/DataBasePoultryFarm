﻿using System;
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
    /// Логика взаимодействия для PerfomanceFactory.xaml
    /// </summary>
    public partial class PerfomanceFactory : Window
    {
        SqlConnection sqlcn = new SqlConnection();
        private DataTable _datasource = new DataTable();
        public PerfomanceFactory(SqlConnection cn)
        {
            InitializeComponent();
            sqlcn = cn;
            SqlCommand myCommand = sqlcn.CreateCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "[PerfomanceFactory]";
            sqlcn.Open();
            SqlDataReader dataReader = myCommand.ExecuteReader();
            _datasource.Load(dataReader);
            dataReader.Close();
            Binding bind = new Binding();
            DG1.DataContext = _datasource;
            DG1.SetBinding(DataGrid.ItemsSourceProperty, bind);
            sqlcn.Close();
        }

        private void BtnPerfClick(object sender, RoutedEventArgs e)
        {
            DataBasePoultryFarm.AboutHens ah = new AboutHens(sqlcn);
            ah.Show();
            this.Close();
        }
    }
}
