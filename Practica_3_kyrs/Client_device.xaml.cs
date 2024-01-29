using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
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
using Practica_3_kyrs.SERVICEDataSetTableAdapters;

namespace Practica_3_kyrs
{
    /// <summary>
    /// Логика взаимодействия для Client_device.xaml
    /// </summary>
    public partial class Client_device : Page
    {
        DEVICESTableAdapter devices = new DEVICESTableAdapter();
        public Client_device()
        {
            InitializeComponent();
            device_table.ItemsSource = devices.GetData();
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            if (device_txt.Text != "")
            {

                devices.InsertQuery(device_txt.Text);
                device_table.ItemsSource = devices.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void Ren_btn_Click(object sender, RoutedEventArgs e)
        {
            if (device_txt.Text != "")
            {
                Object id = (device_table.SelectedItem as DataRowView).Row[0];
                devices.UpdateQuery(device_txt.Text, Convert.ToInt32(id));
                device_table.ItemsSource = devices.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void Del_btn_Click(object sender, RoutedEventArgs e)
        {
            if (device_table.SelectedItem != null)
            {
                int id = (int)(device_table.SelectedItem as DataRowView).Row[0];
                devices.DeleteQuery(id);
                device_table.ItemsSource = devices.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            device_c_page.Content = new Client();
        }
    }
}
