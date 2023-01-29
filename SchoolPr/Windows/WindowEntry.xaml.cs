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
    /// Логика взаимодействия для WindowEntry.xaml
    /// </summary>
    public partial class WindowEntry : Window
    {
        Service s;
        ClientService c;
        int HH;
        int MM;
        public WindowEntry(Service service)
        {
            InitializeComponent();
            this.s = service;
            TextBlockTitle.Text = " " + s.Title;
            TextBlockTime.Text = " " + s.DurationInSeconds / 60;
            TextBoxTimeStart.Text = DateTime.Now.ToString("HH");
            TextBoxTimeStart2.Text = DateTime.Now.ToString("mm");
            List<Client> clients = Classes.BaseClass.DB.Client.ToList();
            for(int i = 0; i < clients.Count; i++)
            {
                ComboBocClient.Items.Add(clients[i].FIO);
            }
            HH = Convert.ToInt32(DateTime.Now.ToString("HH"));
            MM = Convert.ToInt32(DateTime.Now.ToString("mm"));
            Time();
        }
        
        public void Time()
        {
            DateTime date = new DateTime(2000, 2, 2, HH, MM, 0);
            DateTime data = date.AddSeconds(Convert.ToInt32(s.DurationInSeconds));
            TextBlockTimeEnd.Text = data.ToShortTimeString();
        }

        private void TextBoxTimeStart_TextChanged(object sender, TextChangedEventArgs e)
        {

            showTime();
        }

        private void TextBoxTimeStart2_TextChanged(object sender, TextChangedEventArgs e)
        {

            showTime();
        }

        public void showTime()
        {
            try
            {

                string hour = TextBoxTimeStart.Text;
                string minu = TextBoxTimeStart2.Text;
                int hours = Convert.ToInt32(hour);
                int minut = Convert.ToInt32(minu);
                if (hours < 0 || hours > 23)
                {
                    MessageBox.Show("Часы введены некорректно", "Ошибка");
                }
                else
                {
                    if (minut < 0 || minut > 60)
                    {
                        MessageBox.Show("Минуты введены некорректно", "Ошибка");
                    }
                    else
                    {
                        MM = minut;
                        HH = hours;
                        Time();
                    }


                }
            }
            catch
            {
               
            }

            
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ComboBocClient.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите клиента", "Ошибка");
                }
                else
                {
                    if (DataPickerData.Text == "")
                    {
                        MessageBox.Show("Выберите дату", "Ошибка");
                    }
                    else
                    {
                        if (TextBoxTimeStart.Text == "" || TextBoxTimeStart2.Text == "")
                        {
                            MessageBox.Show("Введите время начала занятия", "Ошибка");
                        }
                        else
                        {
                            c = new ClientService();
                            c.ClientID = ComboBocClient.SelectedIndex + 1;
                            c.ServiceID = s.ID;

                            DateTime dateTime = DataPickerData.SelectedDate.Value;
                            dateTime = dateTime.Add(new TimeSpan(Convert.ToInt32(TextBoxTimeStart.Text), Convert.ToInt32(TextBoxTimeStart2.Text), 0));
                            c.Comment = null;


                            c.StartTime = dateTime;
                            Classes.BaseClass.DB.ClientService.Add(c);
                            Classes.BaseClass.DB.SaveChanges();

                            MessageBox.Show("Клиент записан на занятие успешно", "Информация");
                            Close();
                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так с добавлением записи", "Ошибка");
            }
        }

        //запрет ввода символов
        private void TextBoxTimeStart_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.Text, 0))
                {
                    e.Handled = true;
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так с запретом ввода символов", "Ошибка");
            }
        }
        //запрет ввода символов
        private void TextBoxTimeStart2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                if(!Char.IsDigit(e.Text, 0))
                {
                    e.Handled = true;
                }    
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так с запретом ввода символов", "Ошибка");
            }
        }

        private void TextBoxTimeStart_SelectionChanged(object sender, RoutedEventArgs e)
        {
            showTime();
        }

        private void TextBoxTimeStart2_SelectionChanged(object sender, RoutedEventArgs e)
        {
            showTime();
        }
    }
}
