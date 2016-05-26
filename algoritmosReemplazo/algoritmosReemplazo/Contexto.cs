using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    public class Contexto
    {
        private IColocacion colocacion;

        public IColocacion tipoAlgoritmo
        {
            get { return colocacion; }
            set { this.colocacion = value; }
        }

        public System.Data.DataTable getColocacionEnMemoria(int tPagina, System.Data.DataTable marcos)
        {
            return colocacion.getColocacionEnMemoria(tPagina, marcos);
        }

    }
}
