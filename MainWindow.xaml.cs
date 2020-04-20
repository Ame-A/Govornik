using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zadaci
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection <Slusaoc> Slusaoci = new ObservableCollection<Slusaoc>();

        Govornik G1 = new Govornik();
        Govornik G2 = new Govornik();

        private string txt1; 
        public string Txt1
        {
            get => txt1;

            set
            {
                txt1 = value;
                G1.Oglasi(G1,txt1);
            }
        }

        private string txt2;
        public string Txt2
        {
            get => txt2;

            set
            {
                txt2 = value;
                G2.Oglasi(G2, txt2);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            DataG.ItemsSource = Slusaoci;
            Slusaoci.Add(new Slusaoc("Test"));
        }
        private void SlusajG1(object sender, RoutedEventArgs e)
        {
            ToggleButton tb = sender as ToggleButton;
            if (tb.IsChecked == true) 
            {
                G1.Govor += (tb.DataContext as Slusaoc).PosZapamtio;
            }
            else
            {
                G1.Govor -= (tb.DataContext as Slusaoc).PosZapamtio;
            }
        }

        private void SlusajG2(object sender, RoutedEventArgs e)
        {
            ToggleButton tb = sender as ToggleButton;
            if (tb.IsChecked == true)
            {
                G2.Govor += (tb.DataContext as Slusaoc).PosZapamtio;
            }
            else
            {
                G2.Govor -= (tb.DataContext as Slusaoc).PosZapamtio;
            }
        }

        private void Izbrisi(object sender, RoutedEventArgs e)
        {
            string ime = ((sender as Button).DataContext as Slusaoc).Ime;
            if (Slusaoci.Remove((sender as Button).DataContext as Slusaoc))
            {
                MessageBox.Show($"Uspesno ste izbacili slusaoca {ime}");
            }
            else
            {
                MessageBox.Show("Greska!");
            }
        }

    }
}
