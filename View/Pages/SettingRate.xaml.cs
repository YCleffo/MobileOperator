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
    /// Логика взаимодействия для SettingRate.xaml
    /// </summary>
    public partial class SettingRate : Page
    {
        Core db = new Core();
        List<Rate> arrayRate;
        Client clientInfo;
        int clientIdRate;
        public SettingRate()
        {
            InitializeComponent();
            arrayRate = db.context.Rate.ToList();
            RateCombobox.ItemsSource = arrayRate;
            RateCombobox.DisplayMemberPath = "RateName";
            RateCombobox.SelectedValuePath = "idRate";

            clientInfo = db.context.Client.Where(x =>x.Login == Properties.Settings.Default.loginClient).FirstOrDefault();
            clientIdRate = clientInfo.IdRate;
            Console.WriteLine("Тарифный план " + clientIdRate);

            Rate activeRate = arrayRate.Where(x => x.idRate == clientIdRate).First();
            RateCombobox.Text = activeRate.RateName;
            InternetSlider.Value = Convert.ToInt32(activeRate.Internet);
            CountBellSlider.Value = Convert.ToInt32(activeRate.CountMinuts);
            SmsSlider.Value = Convert.ToInt32(activeRate.CountSms);
            LabelSalary.Content = Convert.ToInt32(activeRate.Salary);
        }

        private void TarifComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idActiveRate = Convert.ToInt32(RateCombobox.SelectedValue);
            Console.WriteLine(idActiveRate);
            int internetRate, countMinutesRate, countSMSRate, countSalary;
            foreach(var item in arrayRate)
            {
                if (item.idRate == idActiveRate)
                {
                    internetRate = Convert.ToInt32(item.Internet);
                    countMinutesRate = Convert.ToInt32(item.CountMinuts);
                    countSMSRate = Convert.ToInt32(item.CountSms);
                    countSalary = Convert.ToInt32(item.Salary);
                    
                    InternetSlider.Value=internetRate;
                    SmsSlider.Value = countMinutesRate;
                    SmsSlider.Value = countSMSRate;
                    LabelSalary.Content = countSalary;
                }
            }
        }
    }
}
