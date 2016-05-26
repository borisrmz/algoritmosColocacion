using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class ColocarPaginaConAlgoritmo{

          private static ColocarPaginaConAlgoritmo colocar = null;
        private ColocarPaginaConAlgoritmo() {
        }
        public static ColocarPaginaConAlgoritmo getInstance()
        {
            if (colocar == null)
            {
                colocar = new ColocarPaginaConAlgoritmo();
            }
            return colocar;
        }
        private Contexto contexto = new Contexto();

    

        public void PrimerAjuste()
        {
            IColocacion primerAjuste = new PrimerAjuste();
            contexto.tipoAlgoritmo = primerAjuste;
        }
        public void SiguienteAjuste()
        {
            IColocacion siguienteAjuste = new SiguienteAjuste();
            contexto.tipoAlgoritmo = siguienteAjuste;
        }
        public void MejorAjuste()
        {
            IColocacion mejorAjuste = new MejorAjuste();
            contexto.tipoAlgoritmo = mejorAjuste;
        }
        public void PeorAjuste()
        {
            IColocacion peorAjuste = new PeorAjuste();
            contexto.tipoAlgoritmo = peorAjuste;
        }

        public System.Data.DataTable colocarPagina(int tPagina, System.Data.DataTable marcos)
        {
            return contexto.getColocacionEnMemoria(tPagina, marcos);
        }
    }

}
