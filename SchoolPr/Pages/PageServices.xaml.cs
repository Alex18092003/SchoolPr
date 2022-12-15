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
       public static string kode;
        public PageServices()
        {
            InitializeComponent();

            ListServices.ItemsSource = Classes.BaseClass.DB.Service.ToList();
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
            kode = "0";
        }
    }
}
