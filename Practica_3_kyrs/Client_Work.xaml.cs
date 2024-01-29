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
    /// Логика взаимодействия для Client_Work.xaml
    /// </summary>
    public partial class Client_Work : Page
    {
            WORKSTableAdapter work = new WORKSTableAdapter();
        public Client_Work()
        {
            InitializeComponent();
            work_table.ItemsSource = work.GetData();
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            if (work_txt.Text != "")
            {

                work.InsertQuery(work_txt.Text);
                work_table.ItemsSource = work.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void Ren_btn_Click(object sender, RoutedEventArgs e)
        {
            if (work_txt.Text != "")
            {
                Object id = (work_table.SelectedItem as DataRowView).Row[0];
                work.UpdateQuery(work_txt.Text, Convert.ToInt32(id));
                work_table.ItemsSource = work.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void Del_btn_Click(object sender, RoutedEventArgs e)
        {
            if (work_table.SelectedItem != null)
            {
                int id = (int)(work_table.SelectedItem as DataRowView).Row[0];
                work.DeleteQuery(id);
                work_table.ItemsSource = work.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            worc_c_page.Content = new Client();
        }
    }
}
