using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaci_5_ispravka
{
    public class diktafonC
    {
        public ObservableCollection<string> lista = new ObservableCollection<string>();
        public void Snimaj(object posiljaoc, GovorArgs govor) => lista.Add($"{DateTime.Now.ToString("HH:mm:ss")} - {govor.Ko_salje} : {govor.Govor}");
    }
}
