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
using Practica_3_kyrs.Properties;
namespace Practica_3_kyrs
{
    /// <summary>
    /// Логика взаимодействия для Master.xaml
    /// </summary>
    public partial class Master : Page
    {
        STATUSESTableAdapter status = new STATUSESTableAdapter();
        public Master()
        {
            InitializeComponent();
            Status_table.ItemsSource = status.GetData();
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Status_txt.Text != "" && Convert.ToString(Status_box.SelectedItem) != "")
            {
               
                status.InsertQuery(Convert.ToInt16(Status_txt.Text), (int)Status_box.SelectedValue);
                Status_table.ItemsSource = status.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void Re_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Status_table.SelectedItem != null && Status_txt.Text != "")
            {
                Object id = (Status_table.SelectedItem as DataRowView).Row[0];
                status.UpdateQuery((int)Status_box.SelectedValue, Convert.ToInt32(Status_txt.Text), Convert.ToInt32(id));
                Status_table.ItemsSource = status.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void Del_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Status_table.SelectedItem != null)
            {
                int id = (int)(Status_table.SelectedItem as DataRowView).Row[0];
                status.DeleteQuery(id);
                Status_table.ItemsSource = status.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }   
        }

        private void Order_btn_Click(object sender, RoutedEventArgs e)
        {
            master_page.Content = new Master_Order();
        }
    }
}
