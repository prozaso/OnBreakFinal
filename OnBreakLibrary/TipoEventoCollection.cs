using OnBreak.DALC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreakLibrary
{
    public class TipoEventoCollection
    {

        OnBreakEntities bd = new OnBreakEntities();

        public List<TipoEvento> ListaTipoEvento()
        {
            return (from t in this.bd.TipoEvento
                    select new TipoEvento()
                    {
                        IdTipoEvento = t.IdTipoEvento,
                        Descripcion = t.Descripcion.Trim()
                    }).ToList();
        }

    }
}
