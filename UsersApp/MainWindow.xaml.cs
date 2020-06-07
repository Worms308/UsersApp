using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UsersApp.Session;
using UsersApp.View;

namespace UsersApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PersonView personView = new PersonView();
        public bool hasChanges { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            hasChanges = false;
            dataGrid.ItemsSource = personView.peopleDTOs;
            SetActualUserTextBlock();
            personView.ReloadUserData();
        }

        public void SetActualUserTextBlock()
        {
            actualUserTextBlock.Text = UserSession.GetInstance().currentUser.username;
        }

        private void button_Click(object sender, RoutedEventArgs e) // save button
        {
            personView.SaveChanges();
            hasChanges = false;
            changeButtonDisability();
        }

        private void dataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {

        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int indexInTable = dataGrid.SelectedIndex;
            personView.SetEditedPersonId(indexInTable);
            hasChanges = true;
            changeButtonDisability();
        }

        private void dataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            hasChanges = true;
            changeButtonDisability();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            personView.CancelChanges();
            hasChanges = false;
            changeButtonDisability();
        }

        private void changeButtonDisability()
        {
            saveButton.IsEnabled = hasChanges;
            cancelButton.IsEnabled = hasChanges;
        }

        private void dataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                int indexInTable = dataGrid.SelectedIndex;
                personView.SetRemovePersonId(indexInTable);
                hasChanges = true;
                changeButtonDisability();
            }
        }

        private void accounts_Click(object sender, RoutedEventArgs e)
        {
            personView.SaveUserData();
            AccountsWindow accountsWindow = new AccountsWindow();
            accountsWindow.SetParent(this);
            accountsWindow.ShowDialog();
            personView.ReloadUserData();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            personView.SaveUserData();
        }
    }
}
