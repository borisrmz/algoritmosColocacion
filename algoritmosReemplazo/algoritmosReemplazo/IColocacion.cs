using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ConsoleApplication4
{
    public interface IColocacion
    {
        DataTable getColocacionEnMemoria(int tPagina, DataTable marcos);
    }
}
