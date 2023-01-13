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

namespace SchoolPr.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageServices.xaml
    /// </summary>
    public partial class PageServices : Page
    {

        List<Service> listFilter = new List<Service>();
        public static string kode;
        public PageServices()
        {
            InitializeComponent();

            ListServices.ItemsSource = Classes.BaseClass.DB.Service.ToList();
            ComboBoxFilterDiscount.SelectedIndex = 0;
            TextCountDB.Text ="Количество записей в бд:" + Classes.BaseClass.DB.Service.ToList().Count;
            TextCount.Text = "Количество выведенных записей: " + Classes.BaseClass.DB.Service.ToList().Count;
        }

        private void AdminWindows_Click(object sender, RoutedEventArgs e)
        {
            Windows.WindowAdmin windowPerson = new Windows.WindowAdmin(); 
            windowPerson.ShowDialog();
            Classes.Framec.MainFrame.Navigate(new PageServices());
        }

        private void buttonEditServices_Loaded(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (kode == "0000")
            {
                button.Visibility = Visibility.Visible;
            }
            else
            {
                button.Visibility = Visibility.Collapsed;
            }
        }

        private void AdminWindows_Loaded(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (kode == "0000")
            {
                button.Visibility = Visibility.Collapsed;
            }
            else
            {
                button.Visibility = Visibility.Visible;
            }
        }

        private void ExitAdminWindows_Click(object sender, RoutedEventArgs e)
        {
            AdminWindows.Visibility = Visibility.Visible;
            ExitAdminWindows.Visibility = Visibility.Collapsed;
            ButoonAddandEditing.Visibility = Visibility.Collapsed;
            kode = "1111";
        }

        void Filter()
        {
            List<Service> services = Classes.BaseClass.DB.Service.ToList();
            if (ComboBoxFilterDiscount.SelectedIndex == 1)
            {
                listFilter = new List<Service>();
                listFilter = Classes.BaseClass.DB.Service.Where(x => x.Discount == null || x.Discount < 0.05).ToList();
            }
           else if (ComboBoxFilterDiscount.SelectedIndex == 2)
            {
                listFilter = new List<Service>();
                listFilter = Classes.BaseClass.DB.Service.Where(x => x.Discount >= 0.05 && x.Discount < 0.15).ToList();
            }
            else if (ComboBoxFilterDiscount.SelectedIndex == 3)
            {
                listFilter = new List<Service>();
                listFilter = Classes.BaseClass.DB.Service.Where(x => x.Discount >= 0.15 && x.Discount < 0.3).ToList();
            }
            else if (ComboBoxFilterDiscount.SelectedIndex == 4)
            {
                listFilter = new List<Service>();
                listFilter = Classes.BaseClass.DB.Service.Where(x => x.Discount >= 0.3 && x.Discount < 0.7).ToList();
            }
            else if (ComboBoxFilterDiscount.SelectedIndex == 5)
            {
                listFilter = new List<Service>();
                listFilter = Classes.BaseClass.DB.Service.Where(x => x.Discount >= 0.7 && x.Discount < 1).ToList();
            }
            else
            {
                listFilter =Classes.BaseClass.DB.Service.ToList();
            }


            if (!string.IsNullOrWhiteSpace(TextBoxDescription.Text))
            {
                List<Service> s = Classes.BaseClass.DB.Service.Where(x => x.Description != null).ToList();
                if (s.Count > 0)
                {
                    foreach(Service ss in services)
                    {
                        if(ss.Description != null)
                        {
                            listFilter = listFilter.Where(x => x.Description.ToLower().Contains(TextBoxDescription.Text.ToLower())).ToList();
                        }
                        
                    }
                   
                }
                else
                {
                   
                    MessageBox.Show("нет записей");
                }
            }

            if (!string.IsNullOrWhiteSpace(TextBoxTitle.Text))
            {

                listFilter = listFilter.Where(x => x.Title.ToLower().Contains(TextBoxTitle.Text.ToLower())).ToList();
            }

            ListServices.ItemsSource = listFilter;
            if (listFilter.Count == 0)
            {
                MessageBox.Show("нет записей");
            }
            TextCount.Text = "Количество выведенных записей: " + listFilter.Count;
        }

        private void ComboBoxFilterDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void TextBoxTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void TextBoxDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void ButoonAddandEditing_Click(object sender, RoutedEventArgs e)
        {
            Windows.WindowAddAndEditing windowPerson = new Windows.WindowAddAndEditing();
            windowPerson.ShowDialog();
            Classes.Framec.MainFrame.Navigate(new PageServices());
        }

        private void buttonEditServices_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
