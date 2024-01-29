using Practica_3_kyrs.SERVICEDataSetTableAdapters;
using System;
using System.Collections;
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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        ADDRESSESTableAdapter address = new ADDRESSESTableAdapter();
        CLIENTSTableAdapter client = new CLIENTSTableAdapter();

        public Registration()
        {
            InitializeComponent();
        }

        private void registration_btn_Click(object sender, RoutedEventArgs e)
        {
            if (city_txt.Text != "" && street_txt.Text != "" && number_txt.Text != "")
            {

                address.InsertQuery(city_txt.Text, street_txt.Text, Convert.ToInt16(number_txt.Text));
            }
            else
            {
                MessageBox.Show("Поля для ввода адреса пусты, заполните их.");
            }

            var address_new_client = address.GetData().Rows;
            int id = 0;
            for (int i = 0; i < address_new_client.Count; i++)
            {
                id = Convert.ToInt32(address_new_client[i][0]);
            }
            if (familii_txt.Text != "" && name_txt.Text != "" && password_txt.Text != "" && mail_txt.Text != "")
            {

                client.InsertQuery(Convert.ToString(familii_txt.Text), Convert.ToString(name_txt.Text), Convert.ToString(father_txt.Text), (int)id, Convert.ToString(mail_txt.Text), Convert.ToString(password_txt.Text));
 
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
            (Application.Current.MainWindow as MainWindow).autarization_page.Content = null;
        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).autarization_page.Content = null;
        }
    }
}
