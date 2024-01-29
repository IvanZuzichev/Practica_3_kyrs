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
    /// Логика взаимодействия для Admin_doljnost.xaml
    /// </summary>
    public partial class Admin_doljnost : Page
    {
        POSTSTableAdapter post = new POSTSTableAdapter();
        public Admin_doljnost()
        {
            InitializeComponent();
            doljnest_table.ItemsSource = post.GetData();
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            if (doljnest_txt.Text != "")
            {

                post.InsertQuery(doljnest_txt.Text);
                doljnest_table.ItemsSource = post.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void Ren_btn_Click(object sender, RoutedEventArgs e)
        {
            if (doljnest_txt.Text != "")
            {
                Object id = (doljnest_table.SelectedItem as DataRowView).Row[0];
                post.UpdateQuery(doljnest_txt.Text, Convert.ToInt32(id));
                doljnest_table.ItemsSource = post.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void Del_btn_Click(object sender, RoutedEventArgs e)
        {
            if (doljnest_table.SelectedItem != null)
            {
                int id = (int)(doljnest_table.SelectedItem as DataRowView).Row[0];
                post.DeleteQuery(id);
                doljnest_table.ItemsSource = post.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            doljnest_page.Content = new Administrator();
        }
    }
}
