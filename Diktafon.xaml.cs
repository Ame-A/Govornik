using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Zadaci_5_ispravka
{
    public partial class Diktafon: Window
    {
        ObservableCollection<string> lista { get; set; }
        public Diktafon(ObservableCollection<string> lista1)
        {
            InitializeComponent();
            lista = lista1;
            Dg.ItemsSource = lista;
        }

        private void Izbrisi(object sender, RoutedEventArgs e)
        {
            if (Dg.SelectedItem != null)
            {
                lista.Remove(Dg.SelectedItem as string);
            }
        }
    }
}
