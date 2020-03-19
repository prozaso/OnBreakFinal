using OnBreak.DALC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreakLibrary
{
    public class ActividadEmpresaCollection
    {
        OnBreakEntities bd = new OnBreakEntities();

        public List<ActividadEmpresa> ListaActividadEmpresa()
        {
            return (from t in this.bd.ActividadEmpresa
                    select new ActividadEmpresa()
                    {
                        IdActividadEmpresa = t.IdActividadEmpresa,
                        Descripcion = t.Descripcion
                    }).ToList();
        }
    }
}