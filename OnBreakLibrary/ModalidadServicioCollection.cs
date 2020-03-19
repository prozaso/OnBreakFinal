using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBreak.DALC;

namespace OnBreakLibrary
{
    public class ModalidadServicioCollection
    {

        OnBreakEntities bd = new OnBreakEntities();

        public List<ModalidadServicio> ListaModalidadServicio()
        {
            return (from t in this.bd.ModalidadServicio
                    select new ModalidadServicio()
                    {
                        IdTipoEvento = t.IdTipoEvento,
                        Nombre = t.Nombre.Trim()
                    }).ToList();
        }


        public List<ModalidadServicio> BuscarModalidad(int evento)
        {
            return (from t in this.bd.ModalidadServicio
                    where t.IdTipoEvento == evento
                    select new ModalidadServicio()
                    {
                        IdModalidad = t.IdModalidad,
                        Nombre = t.Nombre.Trim()

                    }).ToList();
        }

        public int personalBase(string idMod)
        {

            return (from a in this.bd.ModalidadServicio
                   where a.IdModalidad == idMod
                   select a.PersonalBase).First();
        }

    }
}