using MobileOperator.Controller;
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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        Core db = new Core();
        List<Rate> arrayRate;

        public RegPage()
        {
            InitializeComponent();
            arrayRate = db.context.Rate.ToList();
            RateComboBox.ItemsSource = arrayRate;
            RateComboBox.DisplayMemberPath = "RateName";
            RateComboBox.SelectedValuePath = "idRate";
        }


        private void RegButtonClick(object sender, RoutedEventArgs e)
        {

            if (RateComboBox.SelectedValue != null)
            {
                int selectRate = Convert.ToInt32(RateComboBox.SelectedValue);
                Console.WriteLine($"Пользователь активирует тариф: { selectRate}");

                ClientController newObject = new ClientController();
                bool result = newObject.AddClientInfo(NumberPhoneTextBlock.Text, selectRate, LastnameTextBlock.Text,
                    FirstnameTextBlock.Text, OtherNameTextBlock.Text, Convert.ToDateTime(BirthdayDatePicker.SelectedDate.Value), SeriaTextBox.Text,
                    NumberPassportTextBox.Text, Convert.ToDateTime(PassportDatePicker.SelectedDate.Value), LoginTextBox.Text, PasswordTextBox.Password);
                if (result){
                    MessageBox.Show("Добавление выполнено успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information); 
                }
                //Client newClient = new Client()
                //{
                //    NumberPhone = NumberPhoneTextBlock.Text,
                //    IdRate = selectRate,
                //    LastName = LastnameTextBlock.Text,
                //    FirstName = FirstnameTextBlock.Text,
                //    PatronymicName = OtherNameTextBlock.Text,
                //    DateBirthday = Convert.ToDateTime(BirthdayDatePicker.SelectedDate.Value),
                //    passportSerial = SeriaTextBox.Text,
                //    PassportNumber = NumberPassportTextBox.Text,
                //    DatePassport = Convert.ToDateTime(PassportDatePicker.SelectedDate.Value),
                //    Login = LoginTextBox.Text,
                //    Password = PasswordTextBox.Password
                //};
                //db.context.Client.Add(newClient);
                //db.context.SaveChanges();
                //if (db.context.SaveChanges() == 0)
                //{
                //    MessageBox.Show("Добавление выполнено успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information); 
                //};
            }
            else
            {
                MessageBox.Show("Вы не выбрали тариф");
            }
        }

        public bool AddClientInfo(string phoneClient, int rateClient, string lastNameClient, string firstNameClient, string patronymicNameClient, DateTime birthdayClient, string passportSeriaClient, string passportNumberClient, DateTime passportDateClient, string loginClient, string passwordClient)
        {
            Client newClient = new Client()
            {
                NumberPhone = phoneClient,
                IdRate = rateClient,
                LastName = lastNameClient,
                FirstName = firstNameClient,
                PatronymicName = patronymicNameClient,
                DateBirthday = birthdayClient,
                passportSerial = passportSeriaClient,
                PassportNumber = passportSeriaClient,
                DatePassport = passportDateClient,
                Login = loginClient,
                Password = passwordClient
            };
            db.context.Client.Add(newClient);
            db.context.SaveChanges();
            if (db.context.SaveChanges() == 0)
            {
                return true;
            }
            else
            {
                return true;
            }
        }

        private void RateComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
