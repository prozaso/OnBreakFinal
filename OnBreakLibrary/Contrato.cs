using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreakLibrary
{
    public class Contrato
    {

        private string _numero;
        private DateTime _creacion;
        private DateTime _termino;
        private string _rutCliente;
        private string _idModalidad;
        private int _idTipoEvento;
        private DateTime _fechaHoraInicio;
        private DateTime _fechaHoraTermino;
        private int _asistentes;
        private int _personalAdicional;
        private bool _realizado;
        private double _valorTotalContrato;
        private string _observaciones;
        private TipoEvento _tipoEvento;
        private ModalidadServicio _modalidadServicio;





        public Contrato()
        {

        }

        public Contrato(string numero, DateTime creacion, DateTime termino, string rutCliente, string idModalidad, int idTipoEvento, DateTime fechaHoraInicio, DateTime fechaHoraTermino, int asistentes, int personalAdicional, bool realizado, double valorTotalContrato, string observaciones, TipoEvento tipoEvento, ModalidadServicio modalidadServicio)
        {
            Numero = numero;
            Creacion = creacion;
            Termino = termino;
            RutCliente = rutCliente;
            IdModalidad = idModalidad;
            IdTipoEvento = idTipoEvento;
            FechaHoraInicio = fechaHoraInicio;
            FechaHoraTermino = fechaHoraTermino;
            Asistentes = asistentes;
            PersonalAdicional = personalAdicional;
            Realizado = realizado;
            ValorTotalContrato = valorTotalContrato;
            Observaciones = observaciones;
            _tipoEvento = tipoEvento;
            _modalidadServicio = modalidadServicio;
        }


        public ModalidadServicio ModalidadServicio
        {
            get
            {
                return _modalidadServicio;
            }
            set
            {
                _modalidadServicio = value;
            }
        }

        public TipoEvento TipoEvento
        {
            get
            {
                return _tipoEvento;
            }
            set
            {
                _tipoEvento = value;
            }
        }

        public string Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                _numero = value;
            }
        }


        public DateTime Creacion
        {
            get
            {
                return _creacion;
            }
            set
            {
                _creacion = value;
            }
        }

        public DateTime Termino
        {
            get
            {
                return _termino;
            }
            set
            {
                _termino = value;
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

        public DateTime FechaHoraInicio
        {
            get
            {
                return _fechaHoraInicio;
            }
            set
            {
                _fechaHoraInicio = value;
            }
        }

        public DateTime FechaHoraTermino
        {
            get
            {
                return _fechaHoraTermino;
            }
            set
            {
                _fechaHoraTermino = value;
            }
        }

        public int Asistentes
        {
            get
            {
                return _asistentes;
            }
            set
            {
                _asistentes = value;
            }
        }

        public int PersonalAdicional
        {
            get
            {
                return _personalAdicional;
            }
            set
            {
                _personalAdicional = value;
            }
        }

        public bool Realizado
        {
            get
            {
                return _realizado;
            }
            set
            {
                _realizado = value;
            }
        }

        public double ValorTotalContrato
        {
            get
            {
                return _valorTotalContrato;
            }
            set
            {
                _valorTotalContrato = value;
            }
        }

        public string Observaciones
        {
            get
            {
                return _observaciones;
            }
            set
            {
                _observaciones = value;
            }
        }

    }
}
