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
    public partial class LegalWindow : Window
    {
        private readonly DataProvider _dataProvider = new DataProvider();
        private readonly Company _company = new Company();

        public LegalWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SortBySurnameRadioButton.IsChecked = true;
            CreateInformation.IsEnabled = false;
            ChangeInformation.IsEnabled = false;
            DeleteInformation.IsEnabled = false;
            ShowAccountButton.IsEnabled = false;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ClientsList.ItemsSource = _dataProvider.ReadFromXmlLegal();
            ClientsList.Items.Refresh();
        }

        private void ShowAccountButton_Click(object sender, RoutedEventArgs e)
        {
            AccountsWindow accountWindow = new AccountsWindow();
            accountWindow.SurnameLabelAccount.Content = $"{Surname.Text} {Name.Text} {MiddleName.Text}";

            Subject<Company> universalCounterparty = new Subject<Company>((Company)ClientsList.SelectedItem);
            var counterpartyIDText = universalCounterparty.GetSubjectID();

            accountWindow.CounterpartyID.Text = counterpartyIDText;
            accountWindow.AccountList.ItemsSource = _dataProvider.ReadFromXmLAccounts().FindAll(a => a.CounterpartyID == counterpartyIDText);
            accountWindow.AccountList.Items.Refresh();

            accountWindow.Show();
        }


        private void ShowAllAccountButton_Click(object sender, RoutedEventArgs e)
        {
            AccountsAllWindow accountAllWindow = new AccountsAllWindow();

            accountAllWindow.AccountList.ItemsSource = _dataProvider.ReadFromXmLAccounts();
            accountAllWindow.AccountList.Items.Refresh();

            accountAllWindow.Show();
        }

        private void SortBySurname_Checked(object sender, RoutedEventArgs e)
        {
            var data = _dataProvider.ReadFromXmlLegal();
            data.Sort(Company.SortedBy(Company.SortedCriterion.Surname));
            ClientsList.ItemsSource = data;
            ClientsList.Items.Refresh();
        }

        private void SortByName_Checked(object sender, RoutedEventArgs e)
        {
            var data = _dataProvider.ReadFromXmlLegal();
            data.Sort(Company.SortedBy(Company.SortedCriterion.Name));
            ClientsList.ItemsSource = data;
            ClientsList.Items.Refresh();
        }

        private void ChangeInformation_Click(object sender, RoutedEventArgs e)
        {
            _company.Update((Company)ClientsList.SelectedItem);
            if (SortByNameRadioButton.IsChecked == true)
                SortByName_Checked(sender, e);
            else
                SortBySurname_Checked(sender, e);
        }

        private void ChangeAllInformation_Click(object sender, RoutedEventArgs e)
        {
            _dataProvider.WriteToXmlLegal((List<Company>)ClientsList.ItemsSource);
        }

        private void CreateInformation_Click(object sender, RoutedEventArgs e)
        {
            _company.Create(Surname.Text, Name.Text, MiddleName.Text, TelephoneNumber.Text, Pasport.Text, OGRN.Text, Type.Text);
            if (SortByNameRadioButton.IsChecked == true)
                SortByName_Checked(sender, e);
            else
                SortBySurname_Checked(sender, e);
        }

        private void DeleteInformation_Click(object sender, RoutedEventArgs e)
        {
            _company.Delete((Company)ClientsList.SelectedItem);
            if (SortByNameRadioButton.IsChecked == true)
                SortByName_Checked(sender, e);
            else
                SortBySurname_Checked(sender, e);
        }

        private void ClientsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CreateInformation.IsEnabled = ClientsList.SelectedItems.Count != 0;
            ChangeInformation.IsEnabled = ClientsList.SelectedItems.Count != 0;
            DeleteInformation.IsEnabled = ClientsList.SelectedItems.Count != 0;
            ShowAccountButton.IsEnabled = ClientsList.SelectedItems.Count != 0;

        }
    }
}
