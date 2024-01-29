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
    /// Логика взаимодействия для Admin_mark.xaml
    /// </summary>
    public partial class Admin_mark : Page
    {
        MARKSTableAdapter mark = new MARKSTableAdapter();

        ORDERTableAdapter order = new ORDERTableAdapter();
        public Admin_mark()
        {
            InitializeComponent();
            mark_table.ItemsSource = mark.GetData();
            number_order_box.ItemsSource = order.GetData();
            number_order_box.DisplayMemberPath = "ID";
            number_order_box.SelectedValuePath = "ID";
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            mark_admin_page.Content = new Administrator();
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            if (mark_txt.Text != "")
            {

                mark.InsertQuery((int)number_order_box.SelectedValue, Convert.ToInt32(mark_txt.Text));
                mark_table.ItemsSource = mark.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void Ren_btn_Click(object sender, RoutedEventArgs e)
        {
            if (mark_table.SelectedItem != null && mark_txt.Text != "")
            {
                Object id = (mark_table.SelectedItem as DataRowView).Row[0];
                mark.UpdateQuery((int)number_order_box.SelectedValue, Convert.ToInt32(mark_txt.Text), Convert.ToInt32(id));
                mark_table.ItemsSource = mark.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void Del_btn_Click(object sender, RoutedEventArgs e)
        {
            if (mark_table.SelectedItem != null)
            {
                int id = (int)(mark_table.SelectedItem as DataRowView).Row[0];
                mark.DeleteQuery(id);
                mark_table.ItemsSource = mark.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }
    }
}
