using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Practica_3_kyrs.SERVICEDataSetTableAdapters;
namespace Practica_3_kyrs
{
    /// <summary>
    /// Логика взаимодействия для Master_Order.xaml
    /// </summary>
    public partial class Master_Order : Page
    {
        ORDERTableAdapter orders = new ORDERTableAdapter();
        public Master_Order()
        {
            InitializeComponent();
            order_m_table.ItemsSource = orders.GetData();
        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            master_status_page.Content = new Master();
        }
    }
}
