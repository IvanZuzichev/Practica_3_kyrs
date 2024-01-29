using Practica_3_kyrs.SERVICEDataSetTableAdapters;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        STAFFTableAdapter staff = new STAFFTableAdapter();
        CLIENTSTableAdapter client = new CLIENTSTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void autorization_btn_Click(object sender, RoutedEventArgs e)
        {
            var all_staff = staff.GetData().Rows;
            for (int i = 0; i < all_staff.Count; i++)
            {
                if (all_staff[i][1].ToString() == familii_txt.Text && all_staff[i][5].ToString() == password_txt.Text)
                {
                    if (all_staff[i][4].ToString() == "1")
                    {
                        autarization_page.Content = new Administrator();
                    }
                    else if (all_staff[i][4].ToString() == "2")
                    {
                        autarization_page.Content = new Master();
                    }
                    // здесь необходимо добавлять новые роли
                }
            }

            var all_client = client.GetData().Rows;
            for (int i = 0; i < all_client.Count; i++)
            {
                if (all_client[i][1].ToString() == familii_txt.Text && all_client[i][6].ToString() == password_txt.Text)
                {
                    autarization_page.Content = new Client();
                }
            }
        }

        private void registration_btn_Click(object sender, RoutedEventArgs e)
        {
            autarization_page.Content = new Registration();
        }
    }
}
