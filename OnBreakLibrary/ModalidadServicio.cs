using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreakLibrary
{
    public class ModalidadServicio
    {
        private string _idModalidad;
        private int _idTipoEvento;
        private string _nombre;
        private double _valorBase;
        private int _personalBase;



        public ModalidadServicio(string _idModalidad, int _idTipoEvento, string _nombre, float _valorBase, int _personalBase)
        {
            IdModalidad = _idModalidad;
            IdTipoEvento = _idTipoEvento;
            Nombre = _nombre.Trim();
            ValorBase = _valorBase;
            PersonalBase = _personalBase;

        }

        public ModalidadServicio()
        {

        }

        public string IdModalidad
        {
            get
            {
                return _idModalidad;
            }

            set
            {
                _idModalidad = value;
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

        public string Nombre
        {
            get
            {
                return _nombre.Trim();
            }

            set
            {
                _nombre = value.Trim();
            }
        }

        public double ValorBase
        {
            get
            {
                return _valorBase;
            }

            set
            {
                _valorBase = value;
            }
        }

        public int PersonalBase
        {
            get
            {
                return _personalBase;
            }

            set
            {
                _personalBase = value;
            }
        }
    }
}