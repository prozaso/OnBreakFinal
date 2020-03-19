using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OnBreak.DALC;
using System.Windows;

namespace OnBreakLibrary
{
    public class ContratoCollection
    {

        OnBreakEntities bd = new OnBreakEntities();

        private List<int> _asistentes = new List<int>();
        private List<int> _personalAdicional = new List<int>();

        //Listar todo
        public List<Contrato> ReadAll()
        {
            return (from a in this.bd.Contrato

                    select new Contrato()
                    {
                        Numero = a.Numero,
                        Creacion = a.Creacion,
                        Termino = a.Termino,
                        RutCliente = a.RutCliente,

                        ModalidadServicio = new ModalidadServicio()
                        {
                            IdModalidad = a.ModalidadServicio.IdModalidad,
                            Nombre = a.ModalidadServicio.Nombre

                        },

                        TipoEvento = new TipoEvento()
                        {
                            IdTipoEvento = a.ModalidadServicio.TipoEvento.IdTipoEvento,
                            Descripcion = a.ModalidadServicio.TipoEvento.Descripcion
                        },

                        FechaHoraInicio = a.FechaHoraInicio,
                        FechaHoraTermino = a.FechaHoraTermino,
                        Asistentes = a.Asistentes,
                        PersonalAdicional = a.PersonalAdicional,
                        Realizado = a.Realizado,
                        ValorTotalContrato = a.ValorTotalContrato,
                        Observaciones = a.Observaciones

                    }).ToList();
        }

        //Gestiones
        public bool CrearContrato(Contrato contrato)
        {
            try
            {
                OnBreak.DALC.Contrato c = new OnBreak.DALC.Contrato();


                c.Numero = contrato.Numero;
                c.Creacion = contrato.Creacion;
                c.Termino = contrato.Termino;
                c.RutCliente = contrato.RutCliente;
                c.IdModalidad = contrato.IdModalidad;
                c.IdTipoEvento = contrato.IdTipoEvento;
                c.FechaHoraInicio = contrato.FechaHoraInicio;
                c.FechaHoraTermino = contrato.FechaHoraTermino;
                c.Asistentes = contrato.Asistentes;
                c.PersonalAdicional = contrato.PersonalAdicional;
                c.Realizado = contrato.Realizado;
                c.ValorTotalContrato = contrato.ValorTotalContrato;
                c.Observaciones = contrato.Observaciones;


                this.bd.Contrato.Add(c);
                this.bd.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ModificarContrato(Contrato contrato)
        {
            try
            {
                OnBreak.DALC.Contrato c = this.bd.Contrato.Find(contrato.Numero);
                c.Numero = contrato.Numero;
                c.Creacion = contrato.Creacion;
                c.Termino = contrato.Termino;
                c.IdModalidad = contrato.IdModalidad;
                c.IdTipoEvento = contrato.IdTipoEvento;
                c.FechaHoraInicio = contrato.FechaHoraInicio;
                c.FechaHoraTermino = contrato.FechaHoraTermino;
                c.Asistentes = contrato.Asistentes;
                c.PersonalAdicional = contrato.PersonalAdicional;
                c.ValorTotalContrato = contrato.ValorTotalContrato;
                c.Observaciones = contrato.Observaciones;

                this.bd.Entry(c).State = System.Data.Entity.EntityState.Modified;
                this.bd.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool TerminarContrato(Contrato contrato)
        {
            try
            {
                OnBreak.DALC.Contrato c = this.bd.Contrato.Find(contrato.Numero);
                c.Realizado = contrato.Realizado;

                this.bd.Entry(c).State = System.Data.Entity.EntityState.Modified;
                this.bd.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        //buscadores
        public Contrato BuscarContratoPorRut(string rut)
        {
            try
            {
                return (from c in this.bd.Contrato
                        where c.RutCliente == rut

                        select new Contrato()
                        {
                            Numero = c.Numero,
                            Creacion = c.Creacion,
                            Termino = c.Termino,
                            RutCliente = c.RutCliente,

                            ModalidadServicio = new ModalidadServicio()
                            {
                                IdModalidad = c.ModalidadServicio.IdModalidad,
                                Nombre = c.ModalidadServicio.Nombre

                            },

                            TipoEvento = new TipoEvento()
                            {
                                IdTipoEvento = c.ModalidadServicio.TipoEvento.IdTipoEvento,
                                Descripcion = c.ModalidadServicio.TipoEvento.Descripcion
                            },

                            FechaHoraInicio = c.FechaHoraInicio,
                            FechaHoraTermino = c.FechaHoraTermino,
                            Asistentes = c.Asistentes,
                            PersonalAdicional = c.PersonalAdicional,
                            Realizado = c.Realizado,
                            ValorTotalContrato = c.ValorTotalContrato,
                            Observaciones = c.Observaciones

                        }).First();

            }
            catch (Exception)
            {
                return null;
            }
        }

        public Contrato BuscarContratoPorNumero(string numero)
        {
            try
            {
                return (from a in this.bd.Contrato
                        where a.Numero == numero

                        select new Contrato()
                        {
                            Numero = a.Numero,
                            Creacion = a.Creacion,
                            Termino = a.Termino,
                            RutCliente = a.RutCliente,

                            ModalidadServicio = new ModalidadServicio()
                            {
                                IdModalidad = a.ModalidadServicio.IdModalidad,
                                Nombre = a.ModalidadServicio.Nombre

                            },

                            TipoEvento = new TipoEvento()
                            {
                                IdTipoEvento = a.ModalidadServicio.TipoEvento.IdTipoEvento,
                                Descripcion = a.ModalidadServicio.TipoEvento.Descripcion
                            },

                            FechaHoraInicio = a.FechaHoraInicio,
                            FechaHoraTermino = a.FechaHoraTermino,
                            Asistentes = a.Asistentes,
                            PersonalAdicional = a.PersonalAdicional,
                            Realizado = a.Realizado,
                            ValorTotalContrato = a.ValorTotalContrato,
                            Observaciones = a.Observaciones

                        }).First();

            }
            catch (Exception)
            {
                return null;
            }
        }

        public Contrato BuscarContratoPorTipo(int tipoEvento)
        {
            try
            {
                return (from c in this.bd.Contrato

                        select new Contrato()
                        {
                            Numero = c.Numero,
                            Creacion = c.Creacion,
                            Termino = c.Termino,
                            RutCliente = c.RutCliente,
                            IdModalidad = c.IdModalidad,
                            IdTipoEvento = c.IdTipoEvento,
                            FechaHoraInicio = c.FechaHoraInicio,
                            FechaHoraTermino = c.FechaHoraTermino,
                            Asistentes = c.Asistentes,
                            PersonalAdicional = c.PersonalAdicional,
                            Realizado = c.Realizado,
                            ValorTotalContrato = c.ValorTotalContrato,
                            Observaciones = c.Observaciones

                        }).First();

            }
            catch (Exception)
            {
                return null;
            }
        }

        //filtros
        public List<Contrato> ContratoListarFiltroNumero(string numero)
        {
            try
            {
                return (from a in this.bd.Contrato
                        where a.Numero == numero


                        select new Contrato()
                        {
                            Numero = a.Numero,
                            Creacion = a.Creacion,
                            Termino = a.Termino,
                            RutCliente = a.RutCliente,

                            ModalidadServicio = new ModalidadServicio()
                            {
                                IdModalidad = a.ModalidadServicio.IdModalidad,
                                Nombre = a.ModalidadServicio.Nombre

                            },

                            TipoEvento = new TipoEvento()
                            {
                                IdTipoEvento = a.ModalidadServicio.TipoEvento.IdTipoEvento,
                                Descripcion = a.ModalidadServicio.TipoEvento.Descripcion
                            },

                            FechaHoraInicio = a.FechaHoraInicio,
                            FechaHoraTermino = a.FechaHoraTermino,
                            Asistentes = a.Asistentes,
                            PersonalAdicional = a.PersonalAdicional,
                            Realizado = a.Realizado,
                            ValorTotalContrato = a.ValorTotalContrato,
                            Observaciones = a.Observaciones

                        }).ToList();

            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Contrato> ContratoListarFiltroRutCliente(string rutCliente)
        {
            try
            {
                return (from a in this.bd.Contrato
                        where a.RutCliente == rutCliente


                        select new Contrato()
                        {
                            Numero = a.Numero,
                            Creacion = a.Creacion,
                            Termino = a.Termino,
                            RutCliente = a.RutCliente,

                            ModalidadServicio = new ModalidadServicio()
                            {
                                IdModalidad = a.ModalidadServicio.IdModalidad,
                                Nombre = a.ModalidadServicio.Nombre

                            },

                            TipoEvento = new TipoEvento()
                            {
                                IdTipoEvento = a.ModalidadServicio.TipoEvento.IdTipoEvento,
                                Descripcion = a.ModalidadServicio.TipoEvento.Descripcion
                            },

                            FechaHoraInicio = a.FechaHoraInicio,
                            FechaHoraTermino = a.FechaHoraTermino,
                            Asistentes = a.Asistentes,
                            PersonalAdicional = a.PersonalAdicional,
                            Realizado = a.Realizado,
                            ValorTotalContrato = a.ValorTotalContrato,
                            Observaciones = a.Observaciones

                        }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Contrato> ContratoListarFiltroTipoEvento(int tipoEvento)
        {
            try
            {
                return (from a in this.bd.Contrato
                        where a.IdTipoEvento == tipoEvento


                        select new Contrato()
                        {
                            Numero = a.Numero,
                            Creacion = a.Creacion,
                            Termino = a.Termino,
                            RutCliente = a.RutCliente,

                            ModalidadServicio = new ModalidadServicio()
                            {
                                IdModalidad = a.ModalidadServicio.IdModalidad,
                                Nombre = a.ModalidadServicio.Nombre

                            },

                            TipoEvento = new TipoEvento()
                            {
                                IdTipoEvento = a.ModalidadServicio.TipoEvento.IdTipoEvento,
                                Descripcion = a.ModalidadServicio.TipoEvento.Descripcion
                            },

                            FechaHoraInicio = a.FechaHoraInicio,
                            FechaHoraTermino = a.FechaHoraTermino,
                            Asistentes = a.Asistentes,
                            PersonalAdicional = a.PersonalAdicional,
                            Realizado = a.Realizado,
                            ValorTotalContrato = a.ValorTotalContrato,
                            Observaciones = a.Observaciones

                        }).ToList();

            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Contrato> ContratoListarPorRut(string rut)
        {
            try
            {
                return (from a in this.bd.Contrato
                        where a.RutCliente == rut


                        select new Contrato()
                        {
                            Numero = a.Numero,
                            Creacion = a.Creacion,
                            Termino = a.Termino,
                            RutCliente = a.RutCliente,

                            ModalidadServicio = new ModalidadServicio()
                            {
                                IdModalidad = a.ModalidadServicio.IdModalidad,
                                Nombre = a.ModalidadServicio.Nombre

                            },

                            TipoEvento = new TipoEvento()
                            {
                                IdTipoEvento = a.ModalidadServicio.TipoEvento.IdTipoEvento,
                                Descripcion = a.ModalidadServicio.TipoEvento.Descripcion
                            },

                            FechaHoraInicio = a.FechaHoraInicio,
                            FechaHoraTermino = a.FechaHoraTermino,
                            Asistentes = a.Asistentes,
                            PersonalAdicional = a.PersonalAdicional,
                            Realizado = a.Realizado,
                            ValorTotalContrato = a.ValorTotalContrato,
                            Observaciones = a.Observaciones

                        }).ToList();

            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}
