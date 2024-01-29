using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для Admin_Orders.xaml
    /// </summary>
    public partial class Admin_Orders : Page
    {
        ORDERTableAdapter order = new ORDERTableAdapter();

        CLIENTSTableAdapter client = new CLIENTSTableAdapter();
 
        DEVICESTableAdapter device = new DEVICESTableAdapter();

        WORKSTableAdapter work = new WORKSTableAdapter();

        public Admin_Orders()
        {
            InitializeComponent();
            orders_table.ItemsSource = order.GetData();
            Client_box.ItemsSource = client.GetData();
            Client_box.DisplayMemberPath = "ID";
            Client_box.SelectedValue = "ID";

            Device_box.ItemsSource = device.GetData();
            Device_box.DisplayMemberPath = "ID";
            Device_box.SelectedValue = "ID";

            Work_box.ItemsSource = work.GetData();
            Work_box.DisplayMemberPath = "ID";
            Work_box.SelectedValue = "ID";

        }

        private void Work_btn_Click(object sender, RoutedEventArgs e)
        {
            order_a_page.Content = new Admin_Order_Work();
        }

        private void Device_btn_Click(object sender, RoutedEventArgs e)
        {
            order_a_page.Content = new Admin_Order_Device();
        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            order_a_page.Content = new Administrator();
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Cost_txt.Text != "")
            {
                DateTime now = DateTime.Now;
                DateTime? selectedDate = calendar.SelectedDate;
                string data_work = selectedDate.Value.Date.ToShortDateString();
                string data_now =  now.ToShortDateString();
               
                // (selecteditem as твоямодель).значениеизмодели
                if (decimal.TryParse(Cost_txt.Text, out decimal cost))
                {
                    order.InsertQuery(Convert.ToInt32(((DataRowView)Client_box.SelectedValue).Row["ID"]), data_now, data_work, Convert.ToInt32(Device_box.SelectedValue), Convert.ToInt32(Work_box.SelectedValue), cost);
                    orders_table.ItemsSource = order.GetData();
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

                    Object id = (orders_table.SelectedItem as DataRowView).Row[0];
                    order.UpdateQuery(Convert.ToInt32(((DataRowView)Client_box.SelectedValue).Row["ID"]), data_now, data_work, Convert.ToInt32(Device_box.SelectedValue), Convert.ToInt32(Work_box.SelectedValue), cost, Convert.ToInt32(id));
                    orders_table.ItemsSource = order.GetData();
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
            if (orders_table.SelectedItem != null)
            {
                int id = (int)(orders_table.SelectedItem as DataRowView).Row[0];
                order.DeleteQuery(id);
                orders_table.ItemsSource = order.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }
    }
}
