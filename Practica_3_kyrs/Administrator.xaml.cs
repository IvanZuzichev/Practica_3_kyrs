using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using Microsoft.Win32;
using Practica_3_kyrs.SERVICEDataSetTableAdapters;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Controls;
namespace Practica_3_kyrs
{
    /// <summary>
    /// Логика взаимодействия для Administrator.xaml
    /// </summary>
    public partial class Administrator : Page
    {
        CLIENTSTableAdapter client = new CLIENTSTableAdapter();
        STAFFTableAdapter staff = new STAFFTableAdapter();

        ADDRESSESTableAdapter address = new ADDRESSESTableAdapter();
        POSTSTableAdapter post = new POSTSTableAdapter();
        public Administrator()
        {
            InitializeComponent();
            people_table.ItemsSource = client.GetData();
            stuff_table.ItemsSource = staff.GetData();

            Adress_box.ItemsSource =  address.GetData();
            Adress_box.DisplayMemberPath = "ID";
            Adress_box.SelectedValuePath = "ID";

            Doljnost_box.ItemsSource = post.GetData();
            Doljnost_box.DisplayMemberPath = "ID";
            Doljnost_box.SelectedValuePath = "ID";
        }

        private void Exp_Click(object sender, RoutedEventArgs e)
        {

            // Перебираем строки и столбцы DataGrid и заполняем соответствующие ячейки в Excel
            for (int rowIndex = 0; rowIndex < stuff_table.Items.Count; rowIndex++)
            {
                var row = stuff_table.Items[rowIndex] as DataRowView;
                for (int columnIndex = 0; columnIndex < stuff_table.Columns.Count; columnIndex++)
                {
                    //worksheet.Cells[rowIndex + 1, columnIndex + 1].Value = row[columnIndex];
                }
            }

            // Сохраняем Excel файл
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (saveFileDialog.ShowDialog() == true)
            {
                FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                //excelPackage.SaveAs(excelFile);
            }
        }

        private void Orders_btn_Click(object sender, RoutedEventArgs e)
        {
            admin_page.Content = new Admin_Orders();
        }

        private void Adress_btn_Click(object sender, RoutedEventArgs e)
        {
            admin_page.Content = new Admin_adress();
        }

        private void Doljnost_btn_Click(object sender, RoutedEventArgs e)
        {
            admin_page.Content = new Admin_doljnost();
        }

        private void Mark_btn_Click(object sender, RoutedEventArgs e)
        {
            admin_page.Content = new Admin_mark();
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Surname_txt.Text != "" && Name_txt.Text != "" && Password_txt.Text != "")
            {

                staff.InsertQuery(Convert.ToString(Surname_txt.Text), Convert.ToString(Name_txt.Text), Convert.ToString(Father_txt.Text), (int)Doljnost_box.SelectedValue, Convert.ToString(Password_txt.Text));
                stuff_table.ItemsSource = staff.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void Ren_btn_Click(object sender, RoutedEventArgs e)
        {
            if (stuff_table.SelectedItem != null && Surname_txt.Text != "" && Name_txt.Text != "" && Password_txt.Text != "")
            {
                Object id = (stuff_table.SelectedItem as DataRowView).Row[0];
                staff.UpdateQuery(Convert.ToString(Surname_txt.Text), Convert.ToString(Name_txt.Text), Convert.ToString(Father_txt.Text), (int)Doljnost_box.SelectedValue, Convert.ToString(Password_txt.Text), Convert.ToInt32(id));
                stuff_table.ItemsSource = staff.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void Del_btn_Click(object sender, RoutedEventArgs e)
        {
            if (stuff_table.SelectedItem != null)
            {
                int id = (int)(stuff_table.SelectedItem as DataRowView).Row[0];
                staff.DeleteQuery(id);
                stuff_table.ItemsSource = staff.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void Add2_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Surname_txt.Text != "" && Name_txt.Text != "" && Password_txt.Text != ""  && MAil_txt.Text != "")
            {

                client.InsertQuery(Convert.ToString(Surname_txt.Text), Convert.ToString(Name_txt.Text), Convert.ToString(Father_txt.Text), (int)Adress_box.SelectedValue, Convert.ToString(Password_txt.Text), Convert.ToString(MAil_txt.Text));
                people_table.ItemsSource = client.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void Ren2_btn_Click(object sender, RoutedEventArgs e)
        {
            if (people_table.SelectedItem != null && Surname_txt.Text != "" && Name_txt.Text != "" && Password_txt.Text != "" && MAil_txt.Text != "")
            {
                Object id = (people_table.SelectedItem as DataRowView).Row[0];
                client.UpdateQuery(Convert.ToString(Surname_txt.Text), Convert.ToString(Name_txt.Text), Convert.ToString(Father_txt.Text), (int)Adress_box.SelectedValue, Convert.ToString(Password_txt.Text), Convert.ToString(MAil_txt.Text), Convert.ToInt32(id));
                people_table.ItemsSource = client.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void Del2_btn_Click(object sender, RoutedEventArgs e)
        {
            if (people_table.SelectedItem != null)
            {
                int id = (int)(people_table.SelectedItem as DataRowView).Row[0];
                client.DeleteQuery(id);
                people_table.ItemsSource = client.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }
    }
}
