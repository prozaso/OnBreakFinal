using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreakLibrary
{
    public class CoffeeBreak
    {

        private string _numero;
        private Boolean _vegetariana;


        public CoffeeBreak(string numero, bool vegetariana)
        {
            Numero = numero;
            Vegetariana = vegetariana;
        }

        public CoffeeBreak()
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

        public Boolean Vegetariana
        {
            get
            {
                return _vegetariana;
            }
            set
            {
                _vegetariana = value;
            }
        }

    }
}
