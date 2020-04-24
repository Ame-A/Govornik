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

namespace Zadaci_5_ispravka
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Slusaoc> Slusaoci = new ObservableCollection<Slusaoc>();
        public Govornik Govornik1 = new Govornik();
        public diktafonC D1 = new diktafonC();
        private string govor1;

        public string Govor1
        {
            get => govor1;

            set
            {
                govor1 = value;
                Govornik1.govornik(Govor1, "Govornik 1");
            }
        }
        public Govornik Govornik2 = new Govornik();

        private string govor2;

        public string Govor2
        {
            get => govor2;

            set
            {
                govor2 = value;
                Govornik2.govornik(Govor2, "Govornik 2");
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            DataG.ItemsSource = Slusaoci;
            DataContext = this;
        }

        private void Dodaj_slusaoca(object sender, RoutedEventArgs e)
        {
            Dodaj_Slusaoca s = new Dodaj_Slusaoca();
            s.Owner = this;
            if(s.ShowDialog() == true)
            {
                Slusaoci.Add(s.DataContext as Slusaoc);
            }
        }
        private void Izbaci(object sender, RoutedEventArgs e)
        {
            Slusaoc Koga_izbacuje = ((sender as Button).DataContext as Slusaoc);
            if (Slusaoci.Remove(Koga_izbacuje))
            {
                MessageBox.Show($"Izbacili ste slusaoca pod imenom {Koga_izbacuje.Ime}");
                return;
            }
            MessageBox.Show("Doslo je do greske!");
        }


        private void Slusaj(object sender, RoutedEventArgs e)
        {
            ToggleButton tb = (ToggleButton)sender;
            if (tb.Name == "Govornik1" && tb.IsChecked == true)
            {
                Govornik1.GovornikEvent += (tb.DataContext as Slusaoc).Dolazna_Informacija;
                return;
            } else if (tb.Name == "Govornik1" && tb.IsChecked == false)
            {
                Govornik1.GovornikEvent -= (tb.DataContext as Slusaoc).Dolazna_Informacija;
                return;
            }
            if (tb.Name == "Govornik2" && tb.IsChecked == true)
            {
                Govornik2.GovornikEvent += (tb.DataContext as Slusaoc).Dolazna_Informacija;
                return;
            } else if (tb.Name == "Govornik2" && tb.IsChecked == false)
            {
                Govornik1.GovornikEvent -= (tb.DataContext as Slusaoc).Dolazna_Informacija;
                return;
            }
        }
        private void Snimi(object sender, RoutedEventArgs e)
        {
            ToggleButton tb = ((ToggleButton)sender);
            if ((bool)tb.IsChecked)
            {
                Govornik1.GovornikEvent += D1.Snimaj;
                Govornik2.GovornikEvent += D1.Snimaj;
                tb.Content = "Diktafon snima";
            }
            else
            {
                Govornik1.GovornikEvent -= D1.Snimaj;
                Govornik2.GovornikEvent -= D1.Snimaj;
                tb.Content = "Ukljuci diktafon";
            }
        }

        private void Snimato(object sender, RoutedEventArgs e)
        {
            Diktafon df = new Diktafon(D1.lista);
            df.Owner = this;
            df.Show();
        }
    }
}
