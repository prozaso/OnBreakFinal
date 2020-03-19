using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBreak.DALC;

namespace OnBreakLibrary
{
    public class ClienteCollection
    {

        OnBreakEntities bd = new OnBreakEntities();

        //Listar todo
        public List<Cliente> ReadAll()
        {
            return (from c in this.bd.Cliente

                    select new Cliente()
                    {
                        RutCliente = c.RutCliente,
                        RazonSocial = c.RazonSocial,
                        NombreContacto = c.NombreContacto,
                        MailContacto = c.MailContacto,
                        Direccion = c.Direccion,
                        Telefono = c.Telefono,

                        ActividadEmpresa = new ActividadEmpresa()
                        {
                            IdActividadEmpresa = c.ActividadEmpresa.IdActividadEmpresa,
                            Descripcion = c.ActividadEmpresa.Descripcion
                        },

                        TipoEmpresa = new TipoEmpresa()
                        {
                            IdTipoEmpresa = c.TipoEmpresa.IdTipoEmpresa,
                            Descripcion = c.TipoEmpresa.Descripcion
                        }

                    }).ToList();
        }

        //Gestiones
        public bool AgregarCliente(Cliente cliente)
        {
            try
            {
                OnBreak.DALC.Cliente c = new OnBreak.DALC.Cliente();


                c.RutCliente = cliente.RutCliente;
                c.RazonSocial = cliente.RazonSocial;
                c.NombreContacto = cliente.NombreContacto;
                c.MailContacto = cliente.MailContacto;
                c.Direccion = cliente.Direccion;
                c.Telefono = cliente.Telefono;
                c.IdActividadEmpresa = cliente.IdActividadEmpresa;
                c.IdTipoEmpresa = cliente.IdTipoEmpresa;

                this.bd.Cliente.Add(c);
                this.bd.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ModificarCliente(Cliente cliente)
        {
            try
            {
                OnBreak.DALC.Cliente c = this.bd.Cliente.Find(cliente.RutCliente);
                c.RazonSocial = cliente.RazonSocial;
                c.NombreContacto = cliente.NombreContacto;
                c.MailContacto = cliente.MailContacto;
                c.Direccion = cliente.Direccion;
                c.Telefono = cliente.Telefono;
                c.IdActividadEmpresa = cliente.IdActividadEmpresa;
                c.IdTipoEmpresa = cliente.IdTipoEmpresa;

                this.bd.Entry(c).State = System.Data.Entity.EntityState.Modified;
                this.bd.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool EliminarCliente(string rut)
        {
            try
            {
                OnBreak.DALC.Cliente c = bd.Cliente.Find(rut);
                bd.Cliente.Remove(c);
                bd.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        //Buscadores
        public Cliente BuscarClientePorRut(string rut)
        {
            try
            {
                return (from c in this.bd.Cliente
                        where c.RutCliente == rut

                        select new Cliente()
                        {

                            RutCliente = c.RutCliente,
                            RazonSocial = c.RazonSocial,
                            NombreContacto = c.NombreContacto,
                            MailContacto = c.MailContacto,
                            Direccion = c.Direccion,
                            Telefono = c.Telefono,
                            ActividadEmpresa = new ActividadEmpresa()
                            {
                                IdActividadEmpresa = c.ActividadEmpresa.IdActividadEmpresa,
                                Descripcion = c.ActividadEmpresa.Descripcion
                            },

                            TipoEmpresa = new TipoEmpresa()
                            {
                                IdTipoEmpresa = c.TipoEmpresa.IdTipoEmpresa,
                                Descripcion = c.TipoEmpresa.Descripcion
                            }

                        }).First();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Cliente BuscarClientePorTipo(int tipo)
        {
            try
            {
                return (from c in this.bd.Cliente
                        where c.IdTipoEmpresa == tipo

                        select new Cliente()
                        {

                            RutCliente = c.RutCliente,
                            RazonSocial = c.RazonSocial,
                            NombreContacto = c.NombreContacto,
                            MailContacto = c.MailContacto,
                            Direccion = c.Direccion,
                            Telefono = c.Telefono,
                            ActividadEmpresa = new ActividadEmpresa()
                            {
                                IdActividadEmpresa = c.ActividadEmpresa.IdActividadEmpresa,
                                Descripcion = c.ActividadEmpresa.Descripcion
                            },

                            TipoEmpresa = new TipoEmpresa()
                            {
                                IdTipoEmpresa = c.TipoEmpresa.IdTipoEmpresa,
                                Descripcion = c.TipoEmpresa.Descripcion
                            }

                        }).First();

            }
            catch (Exception)
            {

                return null;
            }
        }

        public Cliente BuscarClientePorActividad(int actividad)
        {
            try
            {
                return (from c in this.bd.Cliente
                        where c.IdActividadEmpresa == actividad
                        select new Cliente()
                        {

                            RutCliente = c.RutCliente,
                            RazonSocial = c.RazonSocial,
                            NombreContacto = c.NombreContacto,
                            MailContacto = c.MailContacto,
                            Direccion = c.Direccion,
                            Telefono = c.Telefono,
                            ActividadEmpresa = new ActividadEmpresa()
                            {
                                IdActividadEmpresa = c.ActividadEmpresa.IdActividadEmpresa,
                                Descripcion = c.ActividadEmpresa.Descripcion
                            },

                            TipoEmpresa = new TipoEmpresa()
                            {
                                IdTipoEmpresa = c.TipoEmpresa.IdTipoEmpresa,
                                Descripcion = c.TipoEmpresa.Descripcion
                            }

                        }).First();
            }
            catch (Exception)
            {

                return null;
            }
        }

        //Filtros
        public List<Cliente> ClienteFiltrarPorRut(string rut)
        {
            try
            {
                return (from c in this.bd.Cliente
                        where c.RutCliente == rut

                        select new Cliente()
                        {
                            RutCliente = c.RutCliente,
                            RazonSocial = c.RazonSocial,
                            NombreContacto = c.NombreContacto,
                            MailContacto = c.MailContacto,
                            Direccion = c.Direccion,
                            Telefono = c.Telefono,
                            ActividadEmpresa = new ActividadEmpresa()
                            {
                                IdActividadEmpresa = c.ActividadEmpresa.IdActividadEmpresa,
                                Descripcion = c.ActividadEmpresa.Descripcion
                            },

                            TipoEmpresa = new TipoEmpresa()
                            {
                                IdTipoEmpresa = c.TipoEmpresa.IdTipoEmpresa,
                                Descripcion = c.TipoEmpresa.Descripcion
                            }

                        }).ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<Cliente> ClienteFiltrarPorTipo(int tipoEmpresa)
        {
            try
            {
                return (from c in this.bd.Cliente
                        where c.IdTipoEmpresa == tipoEmpresa

                        select new Cliente()
                        {
                            RutCliente = c.RutCliente,
                            RazonSocial = c.RazonSocial,
                            NombreContacto = c.NombreContacto,
                            MailContacto = c.MailContacto,
                            Direccion = c.Direccion,
                            Telefono = c.Telefono,
                            ActividadEmpresa = new ActividadEmpresa()
                            {
                                IdActividadEmpresa = c.ActividadEmpresa.IdActividadEmpresa,
                                Descripcion = c.ActividadEmpresa.Descripcion
                            },

                            TipoEmpresa = new TipoEmpresa()
                            {
                                IdTipoEmpresa = c.TipoEmpresa.IdTipoEmpresa,
                                Descripcion = c.TipoEmpresa.Descripcion
                            }

                        }).ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<Cliente> ClienteFiltrarPorActividad(int actividad)
        {
            try
            {
                return (from c in this.bd.Cliente
                        where c.IdActividadEmpresa == actividad

                        select new Cliente()
                        {
                            RutCliente = c.RutCliente,
                            RazonSocial = c.RazonSocial,
                            NombreContacto = c.NombreContacto,
                            MailContacto = c.MailContacto,
                            Direccion = c.Direccion,
                            Telefono = c.Telefono,
                            ActividadEmpresa = new ActividadEmpresa()
                            {
                                IdActividadEmpresa = c.ActividadEmpresa.IdActividadEmpresa,
                                Descripcion = c.ActividadEmpresa.Descripcion
                            },

                            TipoEmpresa = new TipoEmpresa()
                            {
                                IdTipoEmpresa = c.TipoEmpresa.IdTipoEmpresa,
                                Descripcion = c.TipoEmpresa.Descripcion
                            }

                        }).ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }



    }
}