using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreakLibrary
{
    public class Cliente
    {

        private string _rutCliente;
        private string _razonSocial;
        private string _nombreContacto;
        private string _mailContacto;
        private string _direccion;
        private string _telefono;
        private int _idActividadEmpresa;
        private int _idTipoEmpresa;
        private ActividadEmpresa _actividadEmpresa;
        private TipoEmpresa _tipoEmpresa;




        public Cliente()
        {

        }

        public Cliente(string rutCliente, string razonSocial, string nombreContacto, string mailContacto, string direccion, string telefono, int idActividadEmpresa, int idTipoEmpresa, ActividadEmpresa actividadEmpresa, TipoEmpresa tipoEmpresa)
        {
            RutCliente = rutCliente;
            RazonSocial = razonSocial;
            NombreContacto = nombreContacto;
            MailContacto = mailContacto;
            Direccion = direccion;
            Telefono = telefono;
            IdActividadEmpresa = idActividadEmpresa;
            IdTipoEmpresa = idTipoEmpresa;
            ActividadEmpresa = actividadEmpresa;
            TipoEmpresa = tipoEmpresa;
        }


        public TipoEmpresa TipoEmpresa
        {
            get
            {
                return _tipoEmpresa;
            }
            set
            {
                _tipoEmpresa = value;
            }
        }

        public ActividadEmpresa ActividadEmpresa
        {
            get
            {
                return _actividadEmpresa;
            }
            set
            {
                _actividadEmpresa = value;
            }
        }


        public string RutCliente
        {
            get
            {
                return _rutCliente;
            }

            set
            {
                _rutCliente = value;
            }
        }

        public string RazonSocial
        {
            get
            {
                return _razonSocial;
            }

            set
            {
                _razonSocial = value;
            }
        }

        public string NombreContacto
        {
            get
            {
                return _nombreContacto;
            }

            set
            {
                _nombreContacto = value;
            }
        }

        public string MailContacto
        {
            get
            {
                return _mailContacto;
            }

            set
            {
                _mailContacto = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _direccion;
            }

            set
            {
                _direccion = value;
            }
        }

        public string Telefono
        {
            get
            {
                return _telefono;
            }

            set
            {
                _telefono = value;
            }
        }

        public int IdActividadEmpresa
        {
            get
            {
                return _idActividadEmpresa;
            }

            set
            {
                _idActividadEmpresa = value;
            }
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
    }
}