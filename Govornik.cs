using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Zadaci_5_ispravka
{
    public class GovorArgs
    {
        public string Govor;
        public string Ko_salje;
        public GovorArgs() { }
        public GovorArgs(string govor, string ko_salje)
        {
            Govor = govor;
            Ko_salje = ko_salje;
        }
        public GovorArgs(string g) => Govor = g;
    }

    public class Govornik
    {
        public delegate void GovorHandler(object Posiljaoc, GovorArgs govor);
        public event GovorHandler GovornikEvent;

        public void govornik(string govor, string ko_salje) => GovornikEvent?.Invoke(this, new GovorArgs(govor,ko_salje));

    }
}
