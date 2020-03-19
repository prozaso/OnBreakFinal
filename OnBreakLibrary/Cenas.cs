using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreakLibrary
{
    public class Cenas
    {

        private string _numero;
        private int _idTipoAmbientacion;
        private Boolean _musicaAmbiental;
        private Boolean _localOnBreak;
        private Boolean _otroLocalOnBreak;
        private double _valorArriendo;


        public Cenas(string numero, int idTipoAmbientacion, bool musicaAmbiental, bool localOnBreak, bool otroLocalOnBreak, double valorArriendo)
        {
            Numero = numero;
            IdTipoAmbientacion = idTipoAmbientacion;
            MusicaAmbiental = musicaAmbiental;
            LocalOnBreak = localOnBreak;
            OtroLocalOnBreak = otroLocalOnBreak;
            ValorArriendo = valorArriendo;
        }

        public Cenas()
        {

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

        public Boolean MusicaAmbiental
        {
            get
            {
                return _musicaAmbiental;
            }
            set
            {
                _musicaAmbiental = value;
            }
        }

        public Boolean LocalOnBreak
        {
            get
            {
                return _localOnBreak;
            }
            set
            {
                _localOnBreak = value;
            }
        }

        public Boolean OtroLocalOnBreak
        {
            get
            {
                return _otroLocalOnBreak;
            }
            set
            {
                _otroLocalOnBreak = value;
            }
        }

        public double ValorArriendo
        {
            get
            {
                return _valorArriendo;
            }
            set
            {
                _valorArriendo = value;
            }
        }
    }
}
