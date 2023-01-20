using MobileOperator.Model;
using MobileOperator.View.Pages;
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

namespace MobileOperator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Core db = new Core();
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new AuthPage());
        }
        /// <summary>
        /// Кнопка назад
        /// </summary>
        private void BehaindButtonClick(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }
          
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            var activePage = e.Content;
            if (activePage is AuthPage || activePage is RegPage)
            {
                UserTextBlock.Text = "";
            }
            else
            { 
                if (Properties.Settings.Default.loginClient != String.Empty)
                {
                    Client clientData = db.context.Client.Where(x => x.Login == Properties.Settings.Default.loginClient).First();
                    string fullName = clientData.LastName + "\n" + clientData.FirstName + "\n" + clientData.PatronymicName;
                    UserTextBlock.Text = fullName;
                }
            }
            if (!MainFrame.CanGoBack)
            {
                BehaindButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                BehaindButton.Visibility = Visibility.Visible;
            }
            if (activePage is PersonalPage || activePage is AuthPage)
            {
                BehaindButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                BehaindButton.Visibility = Visibility.Visible;
            }
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            Properties.Settings.Default.loginClient = String.Empty;
            Properties.Settings.Default.Save();
        }
    }
}
