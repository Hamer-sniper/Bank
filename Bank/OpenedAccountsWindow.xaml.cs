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
    public partial class OpenedAccountsWindow : Window
    {
        private readonly DataProvider _dataProvider = new DataProvider();
        private readonly OpenedAccounts _openedAccount = new OpenedAccounts();

        public OpenedAccountsWindow()
        {
            InitializeComponent();
        }

        private void ShowConcreteAccountButton_Click(object sender, RoutedEventArgs e)
        {
            AccountsWindow accountWindow = new AccountsWindow();
            accountWindow.SurnameLabelAccount.Content = SurnameLabelAccount.Content;
            accountWindow.AccountList.ItemsSource = _dataProvider.ReadFromXmLAccounts().FindAll(a => a.Id == Account.Text);
            accountWindow.AccountList.Items.Refresh();

            accountWindow.Show();
        }

        private void OpenAccountButton_Click(object sender, RoutedEventArgs e)
        {
            _openedAccount.Open(,Sum.Text);
        }
    }
}
