using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBreak.DALC;

namespace OnBreakLibrary
{
    public class Valorizador
    {

        OnBreakEntities bd = new OnBreakEntities();



        public double CalculoEvento(string idEvento, int cantidadAsistentes, int personalAdicional)
        {

            double valorEvento;


            double valor_b = (from a in this.bd.ModalidadServicio
                              where a.IdModalidad == idEvento
                              select a.ValorBase).First();


            int personal_b = (from b in this.bd.ModalidadServicio
                              where b.IdModalidad == idEvento
                              select b.PersonalBase).First();



            if (cantidadAsistentes < 21)
            {
                valorEvento = 3 + valor_b + personal_b;

                if (personalAdicional == 0)
                {
                    valorEvento = valorEvento + 0;
                }
                else if (personalAdicional == 2)
                {
                    valorEvento = valorEvento + 2;
                }
                else if (personalAdicional == 3)
                {
                    valorEvento = valorEvento + 3;
                }
                else if (personalAdicional == 4)
                {
                    valorEvento = valorEvento + 3.5;
                }
                else
                {
                    valorEvento = (valorEvento + 3.5) + (0.5 * (personalAdicional - 4));
                }

                return valorEvento;

            }
            else if (cantidadAsistentes > 20 && cantidadAsistentes < 51)
            {

                valorEvento = 5 + valor_b + personal_b;

                if (personalAdicional == 0)
                {
                    valorEvento = valorEvento + 0;
                }
                else if (personalAdicional > 0 && personalAdicional < 3)
                {
                    valorEvento = valorEvento + 2;
                }
                else if (personalAdicional == 3)
                {
                    valorEvento = valorEvento + 3;
                }
                else if (personalAdicional == 4)
                {
                    valorEvento = valorEvento + 3.5;
                }
                else
                {
                    valorEvento = (valorEvento + 3.5) + (0.5 * (personalAdicional - 4));
                }

                return valorEvento;
            }
            else if(cantidadAsistentes > 50)
            {

                if ((cantidadAsistentes - 50) > 19)
                {

                    int cantidadAdicionales = ((cantidadAsistentes - 50) / 20);
                }
                else
                {

                    valorEvento = 5 + valor_b + personal_b;

                    if (personalAdicional == 0)
                    {
                        valorEvento = valorEvento + 0;
                    }
                    else if (personalAdicional > 0 && personalAdicional == 2)
                    {
                        valorEvento = valorEvento + 2;
                    }
                    else if (personalAdicional == 3)
                    {
                        valorEvento = valorEvento + 3;
                    }
                    else if (personalAdicional == 4)
                    {
                        valorEvento = valorEvento + 3.5;
                    }
                    else
                    {
                        valorEvento = (valorEvento + 3.5) + (0.5 * (personalAdicional - 4));
                    }

                    return valorEvento;

                }
            }

            return 0;
        }





    }
}
