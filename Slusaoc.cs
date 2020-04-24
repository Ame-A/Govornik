using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Zadaci_5_ispravka
{
    public class Slusaoc : INotifyPropertyChanged
    {
        public string Ime { get; set; }
        private string infromacija;
        public string Informacija 
        { 
            get => infromacija;
            set
            {
                infromacija = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Informacija"));
            }      
        }
        public bool sel1 { get; set; }
        public bool sel2 { get; set; }

        public Slusaoc (string ime)
        {
            Ime = ime;
        }
        public Slusaoc() { }
        public void Dolazna_Informacija(object Posiljaoc, GovorArgs args)
        {
            Informacija = args.Govor;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
