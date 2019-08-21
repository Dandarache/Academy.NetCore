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

namespace FirstWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly BitmapImage openEyes = new BitmapImage(new Uri(@"\Images\horse.png", UriKind.Relative));
        readonly BitmapImage closedEyes = new BitmapImage(new Uri(@"\Images\horse-closed.png", UriKind.Relative));

        Horse horse1;
        Horse horse2;

        public MainWindow()
        {
            InitializeComponent();

            dataGrid1.AutoGenerateColumns = true;
            dataGrid1.ItemsSource =
                EmployeeRepository.GetEmployees().Select(a =>
                    new
                    {
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        Gender = a.Gender.ToString()
                    });

            horse1 = new Horse { EyesOpen = true, Image = imageHorse1 };
            horse2 = new Horse { EyesOpen = true, Image = imageHorse2 };
        }

        private void chkbox1_Checked(object sender, RoutedEventArgs e)
        {
            SetImage(horse1);
        }

        private void chkbox1_Unchecked(object sender, RoutedEventArgs e)
        {
            SetImage(horse1);
        }

        private void chkbox2_Checked(object sender, RoutedEventArgs e)
        {
            SetImage(horse2);
        }

        private void chkbox2_Unchecked(object sender, RoutedEventArgs e)
        {
            SetImage(horse2);
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            SetImage(horse1);
            SetImage(horse2);
        }

        private void SetImage(Horse horse)
        {
            horse.Image.Source = horse.EyesOpen ? closedEyes : openEyes;
            horse.EyesOpen = !horse.EyesOpen;
        }

        private void SummarizeButton(object sender, RoutedEventArgs e)
        {
            int.TryParse(Value1.Text, out int val1);
            int.TryParse(Value2.Text, out int val2);

            int sum = val1 + val2;

            SumValue.Text = sum.ToString();
        }
    }
}
