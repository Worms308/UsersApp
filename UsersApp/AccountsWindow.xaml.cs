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
using UsersApp.Session;

namespace UsersApp
{
    /// <summary>
    /// Interaction logic for AccountsWindow.xaml
    /// </summary>
    public partial class AccountsWindow : Window
    {

        private Window parentWindow;
        public AccountsWindow()
        {
            InitializeComponent();
            UserSession.GetInstance().ReloadAvaiableUsers();
            this.RefillUsernames();
            SetRemoveButtonEnable();
            SetSelectButtonEnable();
        }

        public void SetParent(Window parent)
        {
            parentWindow = parent;
        }

        private void RefillUsernames()
        {
            accountsListBox.ItemsSource = UserSession.GetInstance().GetProfiles().ConvertAll(item => item.username);
        }

        private void accountNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(accountNameTextBox.Text) &&
                IsUsernameAvaiable(accountNameTextBox.Text))
            {
                addButton.IsEnabled = true;
            }
            else
            {
                addButton.IsEnabled = false;
            }
        }

        private bool IsUsernameAvaiable(String username)
        {
            foreach(String item in accountsListBox.Items)
            {
                if (item.Equals(username))
                    return false;
            }
            return true;
        }

        private bool CanRemoveUser()
        {
            return accountsListBox.Items.Count > 1;
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            if (CanRemoveUser())
            {
                UserSession.GetInstance().RemoveUser(accountsListBox.SelectedItem.ToString());
                RefillUsernames();
            }
            SetRemoveButtonEnable();
        }

        private void SetRemoveButtonEnable()
        {
            removeButton.IsEnabled = CanRemoveUser();
        }

        private void SetSelectButtonEnable()
        {
            if (accountsListBox.SelectedItem != null)
            {
                selectButton.IsEnabled = true;
            }
            else
            {
                selectButton.IsEnabled = false;
            }
        }

        private void selectButton_Click(object sender, RoutedEventArgs e)
        {
            UserSession.GetInstance().SelectUserByName(accountsListBox.SelectedItem.ToString());
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            UserSession.GetInstance().CreateUser(accountNameTextBox.Text);
            RefillUsernames();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ((MainWindow)parentWindow).SetActualUserTextBlock();
        }

        private void accountsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetSelectButtonEnable();
        }
    }
}
