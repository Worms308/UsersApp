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
using UsersApp.View;

namespace UsersApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            hasChanges = false;
            dataGrid.ItemsSource = personView.peopleDTOs;
        }

        private PersonView personView = new PersonView();
        public bool hasChanges { get; set; }

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
            ((PersonDTO)dataGrid.SelectedItem).SetEditedTrue();
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
    }
}
