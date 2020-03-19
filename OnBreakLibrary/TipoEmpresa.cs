using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreakLibrary
{
    public class TipoEmpresa
    {

        private int _idTipoEmpresa;
        private string _descripcion;


        public TipoEmpresa(int _idTipoEmpresa, string _descripcion)
        {
            IdTipoEmpresa = _idTipoEmpresa;
            Descripcion = _descripcion;
        }

        public TipoEmpresa()
        {

        }

        public int IdTipoEmpresa
        {
            get
            {
                return _idTipoEmpresa;
            }
            set
            {
                _idTipoEmpresa = value;
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
