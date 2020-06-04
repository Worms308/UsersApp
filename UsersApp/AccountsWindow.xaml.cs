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
        public AccountsWindow()
        {
            InitializeComponent();
            UserSession.GetInstance().ReloadAvaiableUsers();
            this.FillUsernames();
        }

        private void FillUsernames()
        {
            accountsListBox.ItemsSource = UserSession.GetInstance().GetProfiles().ConvertAll(item => item.username);
        }

        private void accountNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(accountNameTextBox.Text))
            {
                addButton.IsEnabled = true;
            }
            else
            {
                addButton.IsEnabled = false;
            }
        }

        private bool CanRemoveUser()
        {
            return accountsListBox.Items.Count > 1;
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            if (CanRemoveUser())
            {

            }
        }

        private void selectButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
