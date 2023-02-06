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
    /// Логика взаимодействия для PageEntry.xaml
    /// </summary>
    public partial class PageEntry : Page
    {
        public PageEntry()
        {
            InitializeComponent();

            //сортировка данных по дате
            DateTime date2 = DateTime.Today;
            DateTime date = date2.AddDays(2);
            List<ClientService> cl = Classes.BaseClass.DB.ClientService.Where(x=>x.StartTime >= DateTime.Today && x.StartTime < date).ToList();
            ListEntry.ItemsSource = cl.OrderBy(x => x.StartTime).ToList();
        }

        private void ButtodBack_Click(object sender, RoutedEventArgs e)
        {
            Classes.Framec.MainFrame.Navigate(new PageServices());
        }
    }
}
