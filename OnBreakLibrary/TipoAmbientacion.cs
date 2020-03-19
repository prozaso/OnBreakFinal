using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreakLibrary
{
    public class TipoAmbientacion
    {

        private int _idTipoAmbientacion;
        private string _descripcion;


        public TipoAmbientacion()
        {

        }

        public TipoAmbientacion(int idTipoAmbientacion, string descripcion)
        {
            IdTipoAmbientacion = idTipoAmbientacion;
            Descripcion = descripcion;
        }

        public int IdTipoAmbientacion
        {
            get
            {
                return _idTipoAmbientacion;
            }
            set
            {
                _idTipoAmbientacion = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
            }
        }

    }
}
