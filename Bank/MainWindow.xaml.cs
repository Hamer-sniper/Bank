using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using Bank.Models;
using Bank.Interfaces;
using Bank.Data;

namespace Bank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DataProvider _dataProvider = new DataProvider();
        private readonly Employee _employee = new Employee();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SortBySurnameRadioButton.IsChecked = true;
            CreateInformation.IsEnabled = false;
            ChangeInformation.IsEnabled = false;
            ShowAccountButton.IsEnabled = false;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ClientsList.ItemsSource = _dataProvider.ReadFromXml();
            ClientsList.Items.Refresh();
        }

        private void ShowAccountButton_Click(object sender, RoutedEventArgs e)
        {
            OpenedAccountsWindow openedAccountWindow = new OpenedAccountsWindow();
            openedAccountWindow.SurnameLabelAccount.Content = $"{Surname.Text} {Name.Text} {MiddleName.Text}";
            openedAccountWindow.AccountList.ItemsSource = _dataProvider.ReadFromXmlOpenedAccounts().FindAll(a => a.CounterpartyID == IdClient.Text);
            openedAccountWindow.AccountList.Items.Refresh();

            openedAccountWindow.Show();
        }

        private void SortBySurname_Checked(object sender, RoutedEventArgs e)
        {
            var data = _dataProvider.ReadFromXml();
            data.Sort(Employee.SortedBy(Employee.SortedCriterion.Surname));
            ClientsList.ItemsSource = data;
            ClientsList.Items.Refresh();
        }

        private void SortByName_Checked(object sender, RoutedEventArgs e)
        {
            var data = _dataProvider.ReadFromXml();
            data.Sort(Employee.SortedBy(Employee.SortedCriterion.Name));
            ClientsList.ItemsSource = data;
            ClientsList.Items.Refresh();
        }

        private void ChangeInformation_Click(object sender, RoutedEventArgs e)
        {
            _employee.Update((Client)ClientsList.SelectedItem);
        }

        private void ChangeAllInformation_Click(object sender, RoutedEventArgs e)
        {
            _dataProvider.WriteToXml((List<Client>)ClientsList.ItemsSource);
        }

        private void CreateInformation_Click(object sender, RoutedEventArgs e)
        {
            _employee.Create(Surname.Text, Name.Text, MiddleName.Text, TelephoneNumber.Text, Pasport.Text);
            if (SortByNameRadioButton.IsChecked == true)
                SortByName_Checked(sender, e);
            else
                SortBySurname_Checked(sender, e);
        }

        private void Surname_TextChanged(object sender, TextChangedEventArgs e)
        {
            CreateInformation.IsEnabled = !string.IsNullOrWhiteSpace(Surname.Text);
            ChangeInformation.IsEnabled = !string.IsNullOrWhiteSpace(Surname.Text);
            ShowAccountButton.IsEnabled = !string.IsNullOrWhiteSpace(Surname.Text);
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            CreateInformation.IsEnabled = !string.IsNullOrWhiteSpace(Name.Text);
            ChangeInformation.IsEnabled = !string.IsNullOrWhiteSpace(Name.Text);
            ShowAccountButton.IsEnabled = !string.IsNullOrWhiteSpace(Name.Text);
        }

        private void MiddleName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CreateInformation.IsEnabled = !string.IsNullOrWhiteSpace(MiddleName.Text);
            ChangeInformation.IsEnabled = !string.IsNullOrWhiteSpace(MiddleName.Text);
            ShowAccountButton.IsEnabled = !string.IsNullOrWhiteSpace(MiddleName.Text);
        }

        private void TelephoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            CreateInformation.IsEnabled = !string.IsNullOrWhiteSpace(TelephoneNumber.Text);
            ChangeInformation.IsEnabled = !string.IsNullOrWhiteSpace(TelephoneNumber.Text);
            ShowAccountButton.IsEnabled = !string.IsNullOrWhiteSpace(TelephoneNumber.Text);
        }

        private void Pasport_TextChanged(object sender, TextChangedEventArgs e)
        {
            CreateInformation.IsEnabled = !string.IsNullOrWhiteSpace(Pasport.Text);
            ChangeInformation.IsEnabled = !string.IsNullOrWhiteSpace(Pasport.Text);
            ShowAccountButton.IsEnabled = !string.IsNullOrWhiteSpace(Pasport.Text);
        }
    }
}
