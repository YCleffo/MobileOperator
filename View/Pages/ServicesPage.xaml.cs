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
    /// Логика взаимодействия для ServicesPage.xaml
    /// </summary>
    public partial class ServicesPage : Page
    {
        Core db = new Core();
        List<Rate> arrayRate;
        //List<Services> arrayServices;
        public ServicesPage()
        {
            InitializeComponent();
            arrayRate = db.context.Rate.ToList();
            RateDataGrid.ItemsSource = arrayRate;
        }
    }
}
