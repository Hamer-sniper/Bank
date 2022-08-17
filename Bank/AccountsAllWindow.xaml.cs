using Bank.Data;
using Bank.Models;
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
using System.Windows.Shapes;

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class AccountsAllWindow : Window
    {
        private readonly DataProvider _dataProvider = new DataProvider();
        private readonly Account _account = new Account();

        public AccountsAllWindow()
        {
            InitializeComponent();
        }

        private void AccountToButton_Click(object sender, RoutedEventArgs e)
        {
            AccountTo.Text = Account.Text;
        }

        private void TransactButton_Click(object sender, RoutedEventArgs e)
        {
            _account.Transact(Account.Text, AccountTo.Text, Sum.Text);
            AccountList.ItemsSource = _dataProvider.ReadFromXmLAccounts();
            AccountList.Items.Refresh();
        }

        private void Sum_TextChanged(object sender, TextChangedEventArgs e)
        {
            TransactButton.IsEnabled = !string.IsNullOrWhiteSpace(AccountTo.Text) &&
                !string.IsNullOrWhiteSpace(Sum.Text) &&
                !string.IsNullOrWhiteSpace(Account.Text) &&
                (Account.Text != AccountTo.Text);
        }

        private void AccountTo_TextChanged(object sender, TextChangedEventArgs e)
        {
            TransactButton.IsEnabled = !string.IsNullOrWhiteSpace(AccountTo.Text) &&
                !string.IsNullOrWhiteSpace(Sum.Text) &&
                !string.IsNullOrWhiteSpace(Account.Text) &&
                (Account.Text != AccountTo.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TransactButton.IsEnabled = false;
        }

        private void Account_TextChanged(object sender, TextChangedEventArgs e)
        {
            TransactButton.IsEnabled = !string.IsNullOrWhiteSpace(AccountTo.Text) &&
               !string.IsNullOrWhiteSpace(Sum.Text) &&
               !string.IsNullOrWhiteSpace(Account.Text) &&
               (Account.Text != AccountTo.Text);
        }
    }
}
