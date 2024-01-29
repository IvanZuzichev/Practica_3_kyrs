using System;
using System.Collections.Generic;
using System.Data;
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
using Practica_3_kyrs.SERVICEDataSetTableAdapters;

namespace Practica_3_kyrs
{
    /// <summary>
    /// Логика взаимодействия для Admin_adress.xaml
    /// </summary>
    public partial class Admin_adress : Page
    {
        ADDRESSESTableAdapter address = new ADDRESSESTableAdapter();
        public Admin_adress()
        {
            InitializeComponent();
            address_table.ItemsSource = address.GetData();
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            address_admin_page.Content = new Administrator();
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            if (city_txt.Text != "" && street_txt.Text != "" && number_txt.Text != "")
            {

                address.InsertQuery(city_txt.Text, street_txt.Text, Convert.ToInt16(number_txt.Text));
                address_table.ItemsSource = address.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void Ren_btn_Click(object sender, RoutedEventArgs e)
        {
            if (city_txt.Text != "" && street_txt.Text != "" && number_txt.Text != "")
            {
                Object id = (address_table.SelectedItem as DataRowView).Row[0];
                address.UpdateQuery(city_txt.Text, street_txt.Text, Convert.ToInt16(number_txt.Text), Convert.ToInt32(id));
                address_table.ItemsSource = address.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void Del_btn_Click(object sender, RoutedEventArgs e)
        {
            if (address_table.SelectedItem != null)
            {
                int id = (int)(address_table.SelectedItem as DataRowView).Row[0];
                address.DeleteQuery(id);
                address_table.ItemsSource = address.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }
    }
}
