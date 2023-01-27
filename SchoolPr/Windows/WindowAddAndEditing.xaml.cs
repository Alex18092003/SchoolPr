using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;
using Microsoft.Win32;

namespace SchoolPr.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowAddAndEditing.xaml
    /// </summary>
    public partial class WindowAddAndEditing : Window
    {
        bool flag = false;
        Service s;
        public object OpenFileDialoge { get; private set; }

        //добавление
        public WindowAddAndEditing()
        {
            InitializeComponent();
            ImageService.Source = new BitmapImage(new Uri("....\\Resources\\picture.png", UriKind.Relative));

        }
        //редактирование
        public WindowAddAndEditing(Service service)
        {
            InitializeComponent();
            flag = true;
            this.s = service;
            TextId.Visibility = Visibility.Visible;
            TextBoxId.Visibility = Visibility.Visible;

            TextBoxTitle.Text = service.Title;
            TextBoxId.Text = Convert.ToString(service.ID);
            double price = Convert.ToInt32(service.Cost);
            TextBoxCost.Text = Convert.ToString(price);
            TextBoxTime.Text = Convert.ToString(service.DurationInSeconds/60);
            TextBoxDiscription.Text = service.Description;
            if (service.Discount != null)
            {
                TextBoxDiscount.Text = Convert.ToString(service.Discount.Value * 100);
            }

        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (flag == false)
                {
                    if (TextBoxTitle.Text == "" || TextBoxTime.Text == "" || TextBoxCost.Text == "")
                    {
                        MessageBox.Show("Не все обязательные поля заполнены", "Сохранение данных");
                    }
                    else
                    {
                        List<Service> services = Classes.BaseClass.DB.Service.Where(x => x.Title == TextBoxTitle.Text).ToList();
                        if (services.Count > 0)
                        {
                            MessageBox.Show("Данная услуга уже существует", "Сохранение данных");
                        }
                        else
                        {
                            if (Convert.ToDouble(TextBoxTime.Text) < 0 || Convert.ToDouble(TextBoxTime.Text) > 240)
                            {
                                MessageBox.Show("Длительность услуги должна быть не более 240 минут и не отрицательная", "Сохранение данных");
                            }
                            else
                            {
                                if (Convert.ToInt32(TextBoxDiscount.Text) < 0 || Convert.ToInt32(TextBoxDiscount.Text) > 100)
                                {
                                    MessageBox.Show("Скидка должна быть в диапазоне от 1 до 99%", "Сохранение данных");
                                }
                                else
                                {
                                    if (Convert.ToInt32(TextBoxCost.Text) < 0)
                                    {
                                        MessageBox.Show("Стосимость не может быть отрицательной", "Сохранение данных");
                                    }
                                    else
                                    {
                                        s = new Service();
                                        s.Title = TextBoxTitle.Text;
                                        s.Cost = Convert.ToInt32(TextBoxCost.Text);
                                        s.DurationInSeconds = Convert.ToInt32(TextBoxTime.Text) * 60;
                                        if (TextBoxDiscription.Text == "")
                                        {
                                            s.Description = null;
                                        }
                                        else
                                        {
                                            s.Description = TextBoxDiscription.Text;
                                        }
                                        if (TextBoxDiscount.Text == "")
                                        {
                                            s.Discount = null;
                                        }
                                        else
                                        {
                                            s.Discount = Convert.ToDouble(TextBoxDiscount.Text) / 100;
                                        }
                                        s.MainImagePath = path;
                                        Classes.BaseClass.DB.Service.Add(s);
                                        //servph = new ServicePhoto();
                                        //servph.ServiceID = s.ID;
                                        //servph.PhotoPath = path;
                                        //Classes.BaseClass.DB.ServicePhoto.Add(servph);

                                        Classes.BaseClass.DB.SaveChanges();
                                        MessageBox.Show("Данные добавлены", "Добавление данных");
                                        Close();
                                        //Classes.Framec.MainFrame.Navigate(new Pages.PageServices());
                                    }
                                }

                            }
                        }
                    }

                }
                else
                {
                    if (TextBoxTitle.Text == "" || TextBoxTime.Text == "" || TextBoxCost.Text == "")
                    {
                        MessageBox.Show("Не все обязательные поля заполнены", "Сохранение данных");
                    }
                    else
                    {
                        if (Convert.ToDouble(TextBoxTime.Text) < 0 || Convert.ToDouble(TextBoxTime.Text) > 240)
                        {
                            MessageBox.Show("Длительность услуги должна быть не более 240 минут и не отрицательная", "Сохранение данных");
                        }
                        else
                        {
                            if (Convert.ToInt32(TextBoxDiscount.Text) < 0 || Convert.ToInt32(TextBoxDiscount.Text) > 100)
                            {
                                MessageBox.Show("Скидка должна быть в диапазоне от 1 до 99%", "Сохранение данных");
                            }
                            else
                            {
                                if (Convert.ToInt32(TextBoxCost.Text) < 0)
                                {
                                    MessageBox.Show("Стосимость не может быть отрицательной", "Сохранение данных");
                                }
                                else
                                {
                                    s.Title = TextBoxTitle.Text;
                                    s.Cost = Convert.ToInt32(TextBoxCost.Text);
                                    s.DurationInSeconds = Convert.ToInt32(TextBoxTime.Text) * 60;
                                    if (TextBoxDiscription.Text == "")
                                    {
                                        s.Description = null;
                                    }
                                    else
                                    {
                                        s.Description = TextBoxDiscription.Text;
                                    }
                                    if (TextBoxDiscount.Text == "")
                                    {
                                        s.Discount = null;
                                    }
                                    else
                                    {
                                        s.Discount = Convert.ToDouble(TextBoxDiscount.Text) / 100;
                                    }
                                    s.MainImagePath = path;
                                    Classes.BaseClass.DB.SaveChanges();
                                    MessageBox.Show("Изменения сохранены", "Изменение данных");
                                    Close();
                                }
                            }
                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Ошибка");
            }
        }

        //запрет ввода чисел
        private void TextBoxTitle_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Regex x = new Regex("^[0-9]+");
                e.Handled = x.IsMatch(e.Text);
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так с запретом ввода чисел");
            }
        }

        //запрет ввода символов
        private void TextBoxCost_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                if(!Char.IsDigit(e.Text, 0))
                { e.Handled = true; }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так с запретом ввода символов");
            }
        }
        //запрет ввода символов
        private void TextBoxTime_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
                MessageBox.Show("Что-то пошло не так с запретом ввода символов");
            }

        }
        //запрет ввода символов
        private void TextBoxDiscount_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
                MessageBox.Show("Что-то пошло не так с запретом ввода символов");
            }
        }

        string path = null;
        ServicePhoto servph;
        private void ButtonAddImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.ShowDialog();
                path = OFD.FileName;
                string[] arrayPath = path.Split('\\');
                path = "\\" + arrayPath[arrayPath.Length - 2] + "\\" + arrayPath[arrayPath.Length - 1];
                //List<ServicePhoto> servicePhotos = Classes.BaseClass.DB.ServicePhoto.Where(x => x.ServiceID == s.ID).ToList();
                //if(servicePhotos.Count == 0)
                //{
                //    servph = new ServicePhoto();
                //    servph.ServiceID = s.ID;
                //    servph.PhotoPath = s.MainImagePath;
                //    Classes.BaseClass.DB.ServicePhoto.Add(servph);
                //}
                BitmapImage bitmapImage = new BitmapImage(new Uri(path, UriKind.Relative));
                ImageService.Source = bitmapImage;
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Добавление фото");
            }
        }


        //Ввод заглавной буквы
        private void TextBoxTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if(TextBoxTitle.Text.Length ==1)
                {
                    TextBoxTitle.Text = TextBoxTitle.Text.ToUpper();
                    TextBoxTitle.Select(TextBoxTitle.Text.Length, 0);
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так с первой заглавной буквой");
            }
        }
        //Ввод заглавной буквы
        private void TextBoxDiscription_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if(TextBoxDiscription.Text.Length == 1)
                {
                    TextBoxDiscription.Text = TextBoxDiscription.Text.ToUpper();
                    TextBoxDiscription.Select(TextBoxDiscription.Text.Length, 0);
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так с первой заглавной буквой");
            }
        }
      

    }
}
