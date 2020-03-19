using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreakLibrary
{
    public class Cocktail
    {

        private string _numero;
        private int _idTipoAmbientacion;
        private Boolean _ambientacion;
        private Boolean _musicaAmbiental;
        private Boolean _musicaCliente;


        public Cocktail(string numero, int idTipoAmbientacion, bool ambientacion, bool musicaAmbiental, bool musicaCliente)
        {
            Numero = numero;
            IdTipoAmbientacion = idTipoAmbientacion;
            Ambientacion = ambientacion;
            MusicaAmbiental = musicaAmbiental;
            MusicaCliente = musicaCliente;
        }

        public Cocktail()
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

        public Boolean Ambientacion
        {
            get
            {
                return _ambientacion;
            }
            set
            {
                _ambientacion = value;
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

        public Boolean MusicaCliente
        {
            get
            {
                return _musicaCliente;
            }
            set
            {
                _musicaCliente = value;
            }
        }
    }
}
