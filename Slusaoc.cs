using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaci
{
    class Slusaoc : INotifyPropertyChanged
    {
        public string Ime { get; set; }
        public bool Selektovan { get; set; }
        private string zapamtio;
        public string Zapamtio 
        {
            get => zapamtio;
            set
            {
                zapamtio = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Zapamtio"));
            }
        } 

        public Slusaoc(string i)
        {
            Ime = i;    
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void PosZapamtio(object kosalje, Govornik g, string x)
        {
            Zapamtio = g.Informacija;
        }
    }
}
