using MobileOperator.Model;
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

namespace MobileOperator.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        Core db = new Core();
        List<Client> arrayclients;
        public AuthPage()
        {
            InitializeComponent();
            arrayclients = db.context.Client.ToList();
        }


        private void SingInButtonClick(object sender, RoutedEventArgs e)
        {
            if (LogInTextBox.Text != String.Empty && PasswordTextBox.Password != String.Empty && !String.IsNullOrWhiteSpace(LogInTextBox.Text) && !String.IsNullOrWhiteSpace(PasswordTextBox.Password))
            {
                int countRecord = arrayclients.Where(x => x.Login == LogInTextBox.Text && x.Password == PasswordTextBox.Password).Count();
                if (countRecord == 1)
                {
                    Properties.Settings.Default.loginClient = LogInTextBox.Text;
                    Properties.Settings.Default.Save();
                    this.NavigationService.Navigate(new PersonalPage());
                }
            }
            else
            {
                MessageBox.Show("Заполните поля авторизации!");
            }
        }


        private void RegTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new RegPage());
        }
    }
}
