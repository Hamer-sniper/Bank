﻿using Bank.Data;
using Bank.Interfaces;
using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
    public partial class AccountsWindow : Window
    {
        private readonly DataProvider _dataProvider = new DataProvider();
        private readonly Account _account = new Account();

        public AccountsWindow()
        {
            InitializeComponent();
        }

        private void OpenAccountButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)CurrencyList.SelectedItem;
            string currency = selectedItem.Content.ToString();

            _account.Open(currency, Sum.Text, CounterpartyID.Text);
            AccountList.ItemsSource = _dataProvider.ReadFromXmLAccounts().FindAll(a => a.CounterpartyID == CounterpartyID.Text);
            AccountList.Items.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OpenAccountButton.IsEnabled = false;
            CloseAccountButton.IsEnabled = false;
        }

        private void CounterpartyID_TextChanged(object sender, TextChangedEventArgs e)
        {
            CloseAccountButton.IsEnabled = !string.IsNullOrWhiteSpace(CounterpartyID.Text);
        }

        private void Sum_TextChanged(object sender, TextChangedEventArgs e)
        {
            OpenAccountButton.IsEnabled = CurrencyList.SelectedIndex > 0 && !string.IsNullOrWhiteSpace(Sum.Text);
        }

        private void CloseAccountButton_Click(object sender, RoutedEventArgs e)
        {
            _account.Close(AccountID.Text, CounterpartyID.Text);
            AccountList.ItemsSource = _dataProvider.ReadFromXmLAccounts().FindAll(a => a.CounterpartyID == CounterpartyID.Text);
            AccountList.Items.Refresh();
        }

        private void CurrencyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OpenAccountButton.IsEnabled = CurrencyList.SelectedIndex > 0 && !string.IsNullOrWhiteSpace(Sum.Text);
        }
    }
}