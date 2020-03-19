using OnBreak.DALC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreakLibrary
{
    public class TipoEmpresaCollection
    {
        OnBreakEntities bd = new OnBreakEntities();

        public List<TipoEmpresa> ListaTipoEmpresa()
        {
            return (from t in this.bd.TipoEmpresa
                    select new TipoEmpresa()
                    {
                        IdTipoEmpresa = t.IdTipoEmpresa,
                        Descripcion = t.Descripcion
                    }).ToList();
        }
    }
}
