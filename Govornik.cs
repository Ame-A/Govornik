using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaci
{
    class Govornik
    {
        public string Informacija { get; set; }
        public delegate void Govori(object pos, Govornik nesto, string info); 
        public event Govori Govor;
        public void Oglasi(Govornik informacija, string info)
        {
            Govor?.Invoke(this, informacija ,  Informacija = info);  
        }
    }
}
