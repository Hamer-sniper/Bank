using System.Windows;
using System.Windows.Controls;
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
        //IPerson client = new Client();
        private readonly DataProvider _dataProvider = new DataProvider();

        public MainWindow()
        {
            InitializeComponent();
            ClientsList.ItemsSource = _dataProvider.ReadFromXml();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //EmployeeSelection.Items.Add("Консультант");
            //EmployeeSelection.Items.Add("Менеджер");
            //EmployeeSelection.SelectedIndex = 0;

            //AddButton.IsEnabled = false;
            //DeleteButton.IsEnabled = false;
            //Surname.IsEnabled = false;
            //Name.IsEnabled = false;
            //MiddleName.IsEnabled = false;
            //Pasport.IsEnabled = false;

            //UpdateButton.IsEnabled = false;
        }

        private void EmployeeSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (EmployeeSelection.SelectedIndex == 0)
            //    employee = new Consultant();

            //if (EmployeeSelection.SelectedIndex == 1)
            //    employee = new Manager();

            //ClientsList.ItemsSource = employee.GetAll();
            //EmployeeImage.Source = employee.GetBitmap();

            //if (!string.IsNullOrWhiteSpace(TelephoneNumber.Text))
            //{
            //    AddButton.IsEnabled = EmployeeSelection.SelectedIndex == 1;
            //    UpdateButton.IsEnabled = ClientsList.SelectedItem != null && ClientsList.SelectedItem != null;
            //    DeleteButton.IsEnabled = ClientsList.SelectedItem != null && EmployeeSelection.SelectedIndex == 1 && ClientsList.SelectedItem != null;
            //}

            //Surname.IsEnabled = EmployeeSelection.SelectedIndex == 1;
            //Name.IsEnabled = EmployeeSelection.SelectedIndex == 1;
            //MiddleName.IsEnabled = EmployeeSelection.SelectedIndex == 1;
            //Pasport.IsEnabled = EmployeeSelection.SelectedIndex == 1;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //_dataProvider.Create(Surname.Text, Name.Text, MiddleName.Text, TelephoneNumber.Text, Pasport.Text);
            //ClientsList.ItemsSource = employee.GetAll();
            //ClientsList.Items.Refresh();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            //var emp = (Employee)ClientsList.SelectedItem;            
            //employee.Update(emp);
            //ClientsList.ItemsSource = employee.GetAll();
            //ClientsList.Items.Refresh();
        }

        private void TelephoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
           

            // Не сохранять запись без введеного номера телефона.
            //if (string.IsNullOrWhiteSpace(TelephoneNumber.Text))
            //{
            //    AddButton.IsEnabled = false;
            //    UpdateButton.IsEnabled = false;
            //    DeleteButton.IsEnabled = false;
            //}
            //if (!string.IsNullOrWhiteSpace(TelephoneNumber.Text) && ClientsList.SelectedItem != null)
            //{
            //    UpdateButton.IsEnabled = true;                
                
            //}
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //var emp = (Employee)ClientsList.SelectedItem;
            //_dataProvider.Delete(emp);
            //ClientsList.ItemsSource = employee.GetAll();
            //ClientsList.Items.Refresh();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //ClientsList.ItemsSource = employee.GetAll();
            //ClientsList.Items.Refresh();
        }

        private void SortBySurname_Click(object sender, RoutedEventArgs e)
        {
            //var emp = employee.GetAll();
            //emp.Sort(Employee.SortedBy(Employee.SortedCriterion.Surname));
            //ClientsList.ItemsSource = emp;
            //ClientsList.Items.Refresh();
        }

        private void SortByName_Click(object sender, RoutedEventArgs e)
        {
            //var emp = employee.GetAll();
            //emp.Sort(Employee.SortedBy(Employee.SortedCriterion.Name));
            //ClientsList.ItemsSource = emp;
            //ClientsList.Items.Refresh();
        }

        private void ShowLog_Click(object sender, RoutedEventArgs e)
        {
            //LogWindow logWindow = new LogWindow();
            //logWindow.Show();
        }
    }
}
