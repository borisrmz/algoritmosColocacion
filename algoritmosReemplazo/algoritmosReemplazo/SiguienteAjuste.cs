using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ConsoleApplication4
{
    class SiguienteAjuste : IColocacion
    {
        public DataTable getColocacionEnMemoria(int tPagina, DataTable marcos)
        {
            DataTable result = new DataTable();
            DataRow dr;
            result.Columns.Add(new DataColumn("ID", System.Type.GetType("System.Int16")));
            result.Columns.Add(new DataColumn("INICIO", System.Type.GetType("System.Int32")));
            result.Columns.Add(new DataColumn("FIN", System.Type.GetType("System.Int32")));
            result.Columns.Add(new DataColumn("TAMANIO", System.Type.GetType("System.Int32")));
            result.Columns.Add(new DataColumn("ESTADO", System.Type.GetType("System.String")));
            result.Columns.Add(new DataColumn("PUNTERO", System.Type.GetType("System.Int16")));

            int count = 0;
            int marcoAnterior = 0;
            bool ingresada = false;
            bool puntero = false;
            if (marcos.AsEnumerable().Where(m => Convert.ToInt16(m["PUNTERO"]) == 1).Count() == 0)
            {
                foreach (DataRow m in marcos.Rows)
                {
                    m["PUNTERO"] = 1;
                }
            }
            foreach (DataRow marco in marcos.Rows)
            {
                if (tPagina <= Convert.ToInt32(marco["TAMANIO"]) && marco["ESTADO"].ToString() == "H" && !ingresada && Convert.ToInt16(marco["PUNTERO"]) == 1)
                {
                    dr = result.NewRow();
                    dr["ID"] = count;
                    dr["INICIO"] = count == 0 ? 0 : marcoAnterior + 1;
                    dr["FIN"] = Convert.ToInt32(dr["INICIO"]) + tPagina - 1;
                    dr["TAMANIO"] = tPagina;
                    dr["ESTADO"] = "O";
                    dr["PUNTERO"] = 0;
                    result.Rows.Add(dr);
                    count++;
                    marcoAnterior = Convert.ToInt32(dr["FIN"]);
                    puntero = true;
                    if (Convert.ToInt32(marco["TAMANIO"]) != tPagina)
                    {
                        dr = result.NewRow();
                        dr["ID"] = count;
                        dr["INICIO"] = Convert.ToInt32(marcoAnterior) + 1;
                        dr["FIN"] = Convert.ToInt32(dr["INICIO"]) + (Convert.ToInt32(marco["TAMANIO"]) - tPagina) - 1;
                        dr["TAMANIO"] = Convert.ToInt32(marco["TAMANIO"]) - tPagina;
                        dr["ESTADO"] = "H";
                        dr["PUNTERO"] = 1;
                        result.Rows.Add(dr);
                        count++;
                        marcoAnterior = Convert.ToInt32(dr["FIN"]);
                    }
                    ingresada = true;   
                }
                else
                {
                    dr = result.NewRow();
                    dr["ID"] = count;
                    dr["INICIO"] = count == 0 ? 0 : Convert.ToInt32(marcoAnterior) + 1;
                    dr["FIN"] = Convert.ToInt32(dr["INICIO"]) + Convert.ToInt32(marco["TAMANIO"]) - 1;
                    dr["TAMANIO"] = Convert.ToInt32(marco["TAMANIO"]);
                    dr["ESTADO"] = marco["ESTADO"].ToString();
                    dr["PUNTERO"] = puntero ? 1 : 0;
                    result.Rows.Add(dr);
                    count++;
                    marcoAnterior = Convert.ToInt32(dr["FIN"]);

                }
            }

            return result;
        }
    }
}
