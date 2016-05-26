using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            int nMarcos;
            double tMemoria;
            Hashtable hash = new Hashtable();
            Console.WriteLine("numero de marcos");
            nMarcos = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("tamaño de memoria");
            tMemoria = Convert.ToDouble(Console.ReadLine());

            DataTable marcos = new DataTable();
            marcos = new Marcos().getMarcos(nMarcos,tMemoria);

            foreach (DataRow dr in marcos.Rows)
            {
                Console.WriteLine("" + dr["ID"] + "......" + dr["INICIO"] + " - " + dr["FIN"] + "......" + dr["TAMANIO"]+"....."+dr["ESTADO"]+"....."+dr["PUNTERO"]);
            }
            ColocarPaginaConAlgoritmo paginaConAlgoritmo = ColocarPaginaConAlgoritmo.getInstance();
            paginaConAlgoritmo.PeorAjuste();
            int tipo;
            Console.WriteLine("tipo: ");
            tipo = Convert.ToInt16(Console.ReadLine());

            switch (tipo)
            {
                case 1:
                    paginaConAlgoritmo.PrimerAjuste();
                    break;
                case 2:
                    paginaConAlgoritmo.SiguienteAjuste();
                    break;
                case 3:
                    paginaConAlgoritmo.MejorAjuste();
                    break;
                case 4:
                    paginaConAlgoritmo.PeorAjuste();
                    break;
            }

            int tPagina = 0;
            while (tPagina != -1)
            {
                Console.WriteLine("Tamanio de pagina");
                tPagina = Convert.ToInt16(Console.ReadLine());
               
                marcos = paginaConAlgoritmo.colocarPagina(tPagina, marcos);

                foreach (DataRow dr in marcos.Rows)
                {
                    Console.WriteLine("" + dr["ID"] + "......" + dr["INICIO"] + " - " + dr["FIN"] + "......" + dr["TAMANIO"] + "....." + dr["ESTADO"] + "....." + dr["PUNTERO"]);
                }    
            }

            Console.Read();
        }
    }
}
