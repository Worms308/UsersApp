using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UsersApp.Controller;
using UsersApp.DTO;
using UsersApp.Model.XML;
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
            personView.EditedPerson(indexInTable);
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
                personView.RemovePerson(indexInTable);
                hasChanges = true;
                changeButtonDisability();
            }
        }

        private void accounts_Click(object sender, RoutedEventArgs e)
        {
            AccountsWindow accountsWindow = new AccountsWindow();
            accountsWindow.SetParent(this);
            accountsWindow.ShowDialog();
        }
    }
}
