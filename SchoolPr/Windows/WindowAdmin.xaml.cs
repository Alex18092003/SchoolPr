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
using System.Windows.Shapes;

namespace SchoolPr.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowAdmin.xaml
    /// </summary>
    public partial class WindowAdmin : Window
    {
        public WindowAdmin()
        {
            InitializeComponent();
        }

        // проверка на админа
        private void ButtonInput_Click(object sender, RoutedEventArgs e)
        {
            if(PasswordBoxKod.Password != "")
            {
                if (PasswordBoxKod.Password == "0000")
                {
                    string kode = "0000";
                    Pages.PageServices.kode = kode;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Вы ввели не верный код администратора\nПовторите попытку", "Ошибка");
                    PasswordBoxKod.Password = "";
                }
            }
            else
            {
                MessageBox.Show("Поле не заполнено\nВведите код или закройте окно","Ошибка");
            }
        }
    }
}
