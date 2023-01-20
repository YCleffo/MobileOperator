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
using MobileOperator.Model;

namespace MobileOperator.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServiceHelp.xaml
    /// </summary>
    public partial class ServiceHelp : Page
    {
        Core db = new Core();
        List<Services> arrayServices;
        public ServiceHelp()
        {
            InitializeComponent();
            ShowTable();
        }
        public void ShowTable()
        {
            arrayServices = db.context.Services.ToList();
            if(SortCombobox.SelectedIndex == 0)
            {
                arrayServices = arrayServices.OrderBy(x => x.SalaryService).ToList();
            }
            if(SortCombobox.SelectedIndex == 1)
            {
                arrayServices = arrayServices.OrderByDescending(x => x.SalaryService).ToList();
            }
            if (!String.IsNullOrEmpty(FilterTextBox.Text))
            {
                arrayServices = arrayServices.Where(x => x.ServiceName.Contains(FilterTextBox.Text)).ToList();
            }
            ServiceListView.ItemsSource = arrayServices;
        }

        private void FilterTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            ShowTable();
        }


        private void SortComboboxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
