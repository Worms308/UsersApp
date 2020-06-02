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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UsersApp.Controller;
using UsersApp.DTO;

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
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Przycisnięcie przycisku!");
            PersonDTO newPerson = new PersonDTO(-1);
            newPerson.firstName = "Jan";
            newPerson.lastName = "Kowalski";
            newPerson.streetName = "Wiejska";
            newPerson.houseNumber = "123a";
            newPerson.apartmentNumber = "a321";
            newPerson.postalCode = "01-001";
            newPerson.town = "Warszawa";
            newPerson.phoneNumber = "123456789";
            newPerson.birthdate = new DateTime(1991, 01, 30);

            PersonController controller = new PersonController();
            controller.Add(newPerson);
            Console.WriteLine("Po operacji dodawania");

            //PersonDTO fromApp = controller.
        }
    }
}
