using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Page
    {
        MARKSTableAdapter mark = new MARKSTableAdapter();

        ORDERTableAdapter order = new ORDERTableAdapter();

        CLIENTSTableAdapter client = new CLIENTSTableAdapter();

        DEVICESTableAdapter device = new DEVICESTableAdapter();

        WORKSTableAdapter work = new WORKSTableAdapter();
        // заказы
        public Client()
        {
            InitializeComponent();
            order_table.ItemsSource = order.GetData();
            mark_table.ItemsSource = mark.GetData();

            Client_box.ItemsSource = client.GetData();
            Client_box.DisplayMemberPath = "ID";
            Client_box.SelectedValuePath = "ID";

            Device_box.ItemsSource = device.GetData();
            Device_box.DisplayMemberPath = "ID";
            Device_box.SelectedValuePath = "ID";

            Work_box.ItemsSource = work.GetData();
            Work_box.DisplayMemberPath = "ID";
            Work_box.SelectedValuePath = "ID";

            number_order_box.ItemsSource = order.GetData();
            number_order_box.DisplayMemberPath = "ID";
            number_order_box.SelectedValuePath = "ID";
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Cost_txt.Text != "")
            {
                DateTime now = DateTime.Now;
                DateTime? selectedDate = calendar.SelectedDate;
                string data_work = selectedDate.Value.Date.ToShortDateString();
                string data_now = now.ToShortDateString();
                if (decimal.TryParse(Cost_txt.Text, out decimal cost))
                {
                    order.InsertQuery(Convert.ToInt32(((DataRowView)Client_box.SelectedValue).Row["ID"]), data_now, data_work, Convert.ToInt32(Device_box.SelectedValue), Convert.ToInt32(Work_box.SelectedValue), cost);
                    order_table.ItemsSource = order.GetData();
                }
                else
                {
                    MessageBox.Show("Неверное значение в поле стоимости.");
                }
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void Ren_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Cost_txt.Text != "")
            {
                if (decimal.TryParse(Cost_txt.Text, out decimal cost))
                {
                    DateTime now = DateTime.Now;
                    DateTime? selectedDate = calendar.SelectedDate;
                    string data_work = selectedDate.Value.Date.ToShortDateString();
                    string data_now = now.ToShortDateString();

                    Object id = (order_table.SelectedItem as DataRowView).Row[0];
                    order.UpdateQuery(Convert.ToInt32(((DataRowView)Client_box.SelectedValue).Row["ID"]), data_now, data_work, Convert.ToInt32(Device_box.SelectedValue), Convert.ToInt32(Work_box.SelectedValue), cost, Convert.ToInt32(id));
                    order_table.ItemsSource = order.GetData();
                }
                else
                {
                    MessageBox.Show("Неверное значение в поле стоимости.");
                }
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void Del_btn_Click(object sender, RoutedEventArgs e)
        {
            if (order_table.SelectedItem != null)
            {
                int id = (int)(order_table.SelectedItem as DataRowView).Row[0];
                order.DeleteQuery(id);
                order_table.ItemsSource = order.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        // оценки
        private void Add_btn2_Click(object sender, RoutedEventArgs e)
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

        private void Ren_btn2_Click(object sender, RoutedEventArgs e)
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

        private void Del_btn2_Click(object sender, RoutedEventArgs e)
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
        // навигация

        private void Profille_btn_Click(object sender, RoutedEventArgs e)
        {
            client_page.Content = new Client_profile();
        }

        private void Work_btn_Click(object sender, RoutedEventArgs e)
        {
            client_page.Content = new Client_Work();
        }

        private void Device_btn_Click(object sender, RoutedEventArgs e)
        {
            client_page.Content = new Client_device();
        }


    }
}
