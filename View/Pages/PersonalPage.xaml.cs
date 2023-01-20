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
    /// Логика взаимодействия для PersonalPage.xaml
    /// </summary>
    public partial class PersonalPage : Page
    {
        public PersonalPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Расходы
        /// </summary>
        private void ExpensesClick(object sender, RoutedEventArgs e)
        {
        
        }

        /// <summary>
        /// Настройки
        /// </summary>
        private void SetingsClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SettingRate());
        }
        /// <summary>
        /// Услуги
        /// </summary>
        private void ServicesClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ServicesPage());
        }
        /// <summary>
        /// Поддержка
        /// </summary>
        private void SupportClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ServiceHelp());
        }

    }
}
