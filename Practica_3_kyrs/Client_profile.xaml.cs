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

namespace Practica_3_kyrs
{
    /// <summary>
    /// Логика взаимодействия для Client_profile.xaml
    /// </summary>
    public partial class Client_profile : Page
    {
        public Client_profile()
        {
            InitializeComponent();
        }

        private void registration_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            profile_page.Content = new Client();
        }
    }
}
