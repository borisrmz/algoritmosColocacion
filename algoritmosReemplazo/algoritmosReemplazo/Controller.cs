using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConsoleApplication4
{
    class Controller
    {
        private static Controller controller = null;
        private Controller() { }
        public static Controller getInstance()
        {
            if (controller == null)
            {
                controller = new Controller();
            }
            return controller;
        }
        public bool marcosDisponibles;
        public DataTable generarMarcos(int nMarcos, int tMemoria)
        {
            return new Marcos().getMarcos(nMarcos, tMemoria);
        }

        public DataTable ingresarPaginasAuto(DataTable marcos)
        {
            ColocarPaginaConAlgoritmo paginaConAlgoritmo = ColocarPaginaConAlgoritmo.getInstance();
            DataTable result = new DataTable();
            int paginaRandom;
            int tamanioMax = marcos.AsEnumerable().Max(m => Convert.ToInt16(m["TAMANIO"]));
            marcosDisponibles = true;
          
            paginaRandom = new Random().Next(1, tamanioMax);
            result = paginaConAlgoritmo.colocarPagina(paginaRandom, marcos);

            return result;
        }



    }
}
