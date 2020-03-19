using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreakLibrary
{
    public class TipoEvento
    {

        private int _idTipoEvento;
        private string _descripcion;


        public TipoEvento(int _idTipoEvento, string _descripcion)
        {
            IdTipoEvento = _idTipoEvento;
            Descripcion = _descripcion.Trim();
        }

        public TipoEvento()
        {

        }

        public string Descripcion
        {
            get
            {
                return _descripcion.Trim();
            }
            set
            {
                _descripcion = value.Trim();
            }
        }

        public int IdTipoEvento
        {
            get
            {
                return _idTipoEvento;
            }
            set
            {
                _idTipoEvento = value;
            }
        }
    }
}
