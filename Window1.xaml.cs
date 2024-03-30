using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
             MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();    
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginTB.Text;
            var pass = passwordTB.Text;
            var mail = mailTB.Text;
            var context = new AppDbContext();
            var user_exists = context.Users.FirstOrDefault(x => x.Login == login);
            if (user_exists is not null)
            {
                MessageBox.Show("Такой пользователь уже существует");
                return;
            }
            var users = new user {Login = login, Password = pass, Mail = mail};
            context.Users.Add(users);
            context.SaveChanges();
            MessageBox.Show("Вы успешно зарегистрировались ");



        }
    }
}
