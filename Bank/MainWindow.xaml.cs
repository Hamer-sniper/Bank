using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using LogicForBank_ClassLibrary.Models;
using LogicForBank_ClassLibrary.Interfaces;
using LogicForBank_ClassLibrary.Data;
using static System.Net.Mime.MediaTypeNames;

namespace Bank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DataProvider _dataProvider = new DataProvider();
        private readonly Client _client = new Client();

        public MainWindow()
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
            if (SortByNameRadioButton.IsChecked == true)
                SortByName_Checked(sender, e);
            else
                SortBySurname_Checked(sender, e);
        }

        private void ShowAccountButton_Click(object sender, RoutedEventArgs e)
        {
            AccountsWindow accountWindow = new AccountsWindow();
            accountWindow.SurnameLabelAccount.Content = $"{Surname.Text} {Name.Text} {MiddleName.Text}";

            Subject<Client> universalCounterparty = new Subject<Client>((Client)ClientsList.SelectedItem);
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
            var data = _dataProvider.ReadFromXml();
            data.Sort(Client.SortedBy(Client.SortedCriterion.Surname));
            ClientsList.ItemsSource = data;
            ClientsList.Items.Refresh();
        }

        private void SortByName_Checked(object sender, RoutedEventArgs e)
        {
            var data = _dataProvider.ReadFromXml();
            data.Sort(Client.SortedBy(Client.SortedCriterion.Name));
            ClientsList.ItemsSource = data;
            ClientsList.Items.Refresh();
        }

        private void ChangeInformation_Click(object sender, RoutedEventArgs e)
        {
            _client.Update((Client)ClientsList.SelectedItem);
            if (SortByNameRadioButton.IsChecked == true)
                SortByName_Checked(sender, e);
            else
                SortBySurname_Checked(sender, e);
        }

        private void ChangeAllInformation_Click(object sender, RoutedEventArgs e)
        {
            _dataProvider.WriteToXml((List<Client>)ClientsList.ItemsSource);
        }

        private void CreateInformation_Click(object sender, RoutedEventArgs e)
        {
            _client.Create(Surname.Text, Name.Text, MiddleName.Text, TelephoneNumber.Text, Pasport.Text);
            if (SortByNameRadioButton.IsChecked == true)
                SortByName_Checked(sender, e);
            else
                SortBySurname_Checked(sender, e);
        }

        private void DeleteInformation_Click(object sender, RoutedEventArgs e)
        {
            _client.Delete((Client)ClientsList.SelectedItem);
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

        private void CompanyOpenButton_Click(object sender, RoutedEventArgs e)
        {
            LegalWindow legalWindow = new LegalWindow();
            legalWindow.Show();

        }
    }
}
