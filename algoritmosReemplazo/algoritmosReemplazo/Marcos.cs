using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
namespace ConsoleApplication4
{
    class Marcos
    {
        private Hashtable getTamanioMarcos(int nMarcos, double tamanioMemoria)
        {
            Hashtable marcos = new Hashtable();
            tamanioMemoria += nMarcos;
            int n = 0;
            double tamanio = 0;
            int signo;
            int contMarcos = nMarcos;
            
            while (n <= nMarcos-1)
            {
                if(nMarcos-1 != n)
                {
                signo =   new Random().Next(1, 3);
                double tamanioMarcos = tamanioMemoria / contMarcos;
                tamanio = signo == 1 ? tamanioMarcos + new Random().Next(2, Convert.ToInt16(tamanioMarcos-1)) : (tamanioMarcos - new Random().Next(2, Convert.ToInt16(tamanioMarcos-1)));
                }
                else
                {
                    tamanio = Math.Round(tamanioMemoria,0,MidpointRounding.AwayFromZero)+1;
                }
                 marcos.Add(n,Math.Round(tamanio-1,0));
               tamanioMemoria -= tamanio;
               contMarcos--;
               n++;
            }
            return marcos;
        }

        public DataTable getMarcos(int nMarcos, double tamanioMemoria)
        {
            Hashtable tamanioMarcos = new Hashtable();
            DataTable marcos = new DataTable();
            DataRow dr;
            tamanioMarcos = getTamanioMarcos(nMarcos, tamanioMemoria);

            marcos.Columns.Add(new DataColumn("ID", System.Type.GetType("System.Int16")));
            marcos.Columns.Add(new DataColumn("INICIO",System.Type.GetType("System.Int32")));
            marcos.Columns.Add(new DataColumn("FIN",System.Type.GetType("System.Int32")));
            marcos.Columns.Add(new DataColumn("TAMANIO", System.Type.GetType("System.Int32")));
            marcos.Columns.Add(new DataColumn("ESTADO", System.Type.GetType("System.String")));
            marcos.Columns.Add(new DataColumn("PUNTERO", System.Type.GetType("System.Int16")));
            IDictionaryEnumerator mMarcos = tamanioMarcos.GetEnumerator();
            int count = 0;
            int marcoAnterior = 0;
            while (mMarcos.MoveNext())
            {
                dr = marcos.NewRow();
                dr["ID"] = count; ;
                dr["INICIO"] = count == 0 ? 0: marcoAnterior+1;
                dr["FIN"] = Convert.ToInt32(dr["INICIO"]) + Convert.ToInt32(mMarcos.Value)-1;
                dr["TAMANIO"] = mMarcos.Value;
                dr["ESTADO"] = "H";
                dr["PUNTERO"] = 1;
                marcoAnterior =Convert.ToInt32(dr["FIN"]);
                marcos.Rows.Add(dr);
                count++;
            }
        //    return marcos.AsEnumerable().OrderBy(c => c["ID"]).CopyToDataTable();
            return marcos;
        }


    }
}
