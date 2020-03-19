using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OnBreakLibrary;
using Microsoft.VisualBasic;
using System.Windows.Interactivity;
using System.Runtime.Caching;
using System.Threading;
using OnBreakApp.clases;

namespace OnBreakApp
{
    public partial class MainWindow : Window
    {

        private ClienteCollection _clienteCollection = new ClienteCollection();
        private ContratoCollection _contratoCollection = new ContratoCollection();
        private TipoEmpresaCollection _tipoEmpresaCollection = new TipoEmpresaCollection();
        private ActividadEmpresaCollection _actividadEmpresaCollection = new ActividadEmpresaCollection();
        private TipoEventoCollection _tipoEventoCollection = new TipoEventoCollection();
        private ModalidadServicioCollection _modalidadServicioCollection = new ModalidadServicioCollection();
        private Validadores _validadores = new Validadores();
        private Valorizador _valorizador = new Valorizador();

        public ClienteCollection ClienteCollection
        {
            get
            {
                return _clienteCollection;
            }

            set
            {
                _clienteCollection = value;
            }
        }

        public ContratoCollection ContratoCollection
        {
            get
            {
                return _contratoCollection;
            }

            set
            {
                _contratoCollection = value;
            }
        }

        public TipoEmpresaCollection TipoEmpresaCollection
        {
            get
            {
                return _tipoEmpresaCollection;
            }
            set
            {
                _tipoEmpresaCollection = value;
            }
        }

        public ActividadEmpresaCollection ActividadEmpresaCollection
        {
            get
            {
                return _actividadEmpresaCollection;
            }
            set
            {
                _actividadEmpresaCollection = value;
            }
        }

        public TipoEventoCollection TipoEventoCollection
        {
            get
            {
                return _tipoEventoCollection;
            }
            set
            {
                _tipoEventoCollection = value;
            }
        }

        public ModalidadServicioCollection ModalidadServicioCollection
        {
            get
            {
                return _modalidadServicioCollection;
            }
            set
            {
                _modalidadServicioCollection = value;
            }
        }

        public Validadores Validadores
        {
            get
            {
                return _validadores;
            }
            set
            {
                _validadores = value;
            }
        }

        public Valorizador Valorizador
        {
            get
            {
                return _valorizador;
            }
            set
            {
                _valorizador = value;
            }
        }


        //*********************************************************************************************//


        public MainWindow()
        {
            InitializeComponent();

            //Task tarea = new Task(() =>
            //{
            //    while (true)
            //    {
            //        Thread.Sleep(300000);
            //        RespaldarFormularioContrato();
            //    }
            //});
            //tarea.Start();


            VentanaGestionClienteVisible();

            //Gestion Clientes
            cboActividad.ItemsSource = null;
            cboActividad.ItemsSource = ActividadEmpresaCollection.ListaActividadEmpresa();

            cboTipo.ItemsSource = null;
            cboTipo.ItemsSource = TipoEmpresaCollection.ListaTipoEmpresa();

            //Lista Clientes

            cboFiltrarActividadCliente.ItemsSource = ActividadEmpresaCollection.ListaActividadEmpresa();
            cboFiltrarTipoCliente.ItemsSource = TipoEmpresaCollection.ListaTipoEmpresa();

            //Gestion Contrato
            cboTipoEventoContrato.ItemsSource = null;
            cboTipoEventoContrato.ItemsSource = TipoEventoCollection.ListaTipoEvento();

            //Gestion Contrato - Esconder boton "comida vegetariana"
            btnVegetariana.Visibility = Visibility.Hidden;
            lblVegetariana.Visibility = Visibility.Hidden;

            //Lista Contratos

            cboFiltrarTipoEvento.ItemsSource = null;
            cboFiltrarTipoEvento.ItemsSource = TipoEventoCollection.ListaTipoEvento();

            //Cargar listas
            CargarGrillas();

            //nos suscribimos a un evento para ser notificados
            Clases.NotificationCenter.Subscribe("gestion_contrato", CargarGrillas);

            //cache
            FileCache fileCache = new FileCache(new ObjectBinder());

            if (fileCache["fecha_respaldo"] != null)
            {
                DateTime fechaRespaldo = (DateTime)fileCache["fecha_respaldo"];
                txtfechaCache.Text = fechaRespaldo.ToString("dd-MM-yyyy HH:mm:ss");
            }
            else
            {
                txtfechaCache.Text = "No existe respaldo";
            }

        }


        private void CargarGrillas()
        {

            Dispatcher.Invoke(() =>
            {
                CargarListaClientes();
                CargarListaContratos();
            });
        }


        //*********************************************************************************************//

        //Menu
        private void BtnCerrarVentanaMain_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMaxVentanaMain_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState == System.Windows.WindowState.Normal)
            {

                //Application.Current.MainWindow.SizeToContent = System.Windows.SizeToContent.Manual;
                Application.Current.MainWindow.WindowState = System.Windows.WindowState.Maximized;

            }
            else
            {
                Application.Current.MainWindow.WindowState = System.Windows.WindowState.Normal;
            }
        }

        private void BtnMinVentanaMain_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized;
        }

        //Mover ventana desde barra titulo
        private void BarraTitulo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        //Contraste
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {

            Application.Current.Resources.MergedDictionaries[2].Source = new Uri("/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml", UriKind.RelativeOrAbsolute);
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {

            Application.Current.Resources.MergedDictionaries[2].Source = new Uri("/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml", UriKind.RelativeOrAbsolute);
            //txtRut.Foreground = Brushes.Black;


        }


        //Botones menu
        private void BtnGestionCliente_Click(object sender, RoutedEventArgs e)
        {
            VentanaGestionClienteVisible();
        }

        private void BtnListaClientes_Click(object sender, RoutedEventArgs e)
        {
            VentanaListaClientesVisible();
            //btnClienteToGestionCliente.Visibility = Visibility.Hidden;

        }

        private void BtnGestionContrato_Click(object sender, RoutedEventArgs e)
        {
            VentanaGestionContratoVisible();
        }

        private void BtnListaContratos_Click(object sender, RoutedEventArgs e)
        {
            VentanaListaContratosVisible();
        }



        //Visibilidad ventanas
        private void VentanaGestionClienteVisible()
        {
            gridGestionCliente.Visibility = System.Windows.Visibility.Visible;
            gridListaClientes.Visibility = System.Windows.Visibility.Collapsed;
            gridGestionContrato.Visibility = System.Windows.Visibility.Collapsed;
            gridListaContratos.Visibility = System.Windows.Visibility.Collapsed;

            btnClienteToGestionCliente.Visibility = Visibility.Hidden;
            btnContratoToGestion.Visibility = Visibility.Hidden;
            boxAmbientacionBasica.IsEnabled = false;
            boxAmientacionPersonalizada.IsEnabled = false;
            chkAmbientacionBasica.IsChecked = false;
            chkAmbientacionPersonalizada.IsChecked = false;

        }

        private void VentanaListaClientesVisible()
        {

            gridGestionCliente.Visibility = System.Windows.Visibility.Collapsed;
            gridListaClientes.Visibility = System.Windows.Visibility.Visible;
            gridGestionContrato.Visibility = System.Windows.Visibility.Collapsed;
            gridListaContratos.Visibility = System.Windows.Visibility.Collapsed;
            btnContratoToGestion.Visibility = Visibility.Hidden;
            boxAmbientacionBasica.IsEnabled = false;
            boxAmientacionPersonalizada.IsEnabled = false;
            chkAmbientacionBasica.IsChecked = false;
            chkAmbientacionPersonalizada.IsChecked = false;
        }

        private void VentanaGestionContratoVisible()
        {
            gridGestionCliente.Visibility = System.Windows.Visibility.Collapsed;
            gridListaClientes.Visibility = System.Windows.Visibility.Collapsed;
            gridGestionContrato.Visibility = System.Windows.Visibility.Visible;
            gridListaContratos.Visibility = System.Windows.Visibility.Collapsed;

            btnClienteToGestionCliente.Visibility = Visibility.Hidden;
            btnContratoToGestion.Visibility = Visibility.Hidden;
            boxAmbientacionBasica.IsEnabled = false;
            boxAmientacionPersonalizada.IsEnabled = false;

            stackAmbientacionBasica.IsEnabled = false;
            stackAmbientacionPersonalizada.IsEnabled = false;

        }

        private void VentanaListaContratosVisible()
        {
            gridGestionCliente.Visibility = System.Windows.Visibility.Collapsed;
            gridListaClientes.Visibility = System.Windows.Visibility.Collapsed;
            gridGestionContrato.Visibility = System.Windows.Visibility.Collapsed;
            gridListaContratos.Visibility = System.Windows.Visibility.Visible;

            btnClienteToGestionCliente.Visibility = Visibility.Hidden;
            boxAmbientacionBasica.IsEnabled = false;
            boxAmientacionPersonalizada.IsEnabled = false;
            chkAmbientacionBasica.IsChecked = false;
            chkAmbientacionPersonalizada.IsChecked = false;
        }


        //*********************************************************************************************//


        private void CargarListaContratos()
        {
            dgListaContratos.ItemsSource = null;
            dgListaContratos.ItemsSource = ContratoCollection.ReadAll();
        }

        private void CargarListaClientes()
        {
            //Lista Clientes
            dgClientes.ItemsSource = null;
            dgClientes.ItemsSource = ClienteCollection.ReadAll();
        }


        //*********************************************************************************************//



        //Gestion Clientes
        private void BtnBuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            string rut = txtRut.Text.ToString().Replace(".", "");
            rut = rut.Replace(" ", "");


            Cliente cliente = this.ClienteCollection.BuscarClientePorRut(rut);

            try
            {
                if (rut == "")
                {
                    MessageBox.Show("Por favor ingrese un RUT");
                }
                else if (cliente == null)
                {
                    MessageBox.Show("Cliente no existe");
                }
                else
                {
                    txtRut.Text = cliente.RutCliente;
                    txtRazon.Text = cliente.RazonSocial;
                    txtNombre.Text = cliente.NombreContacto;
                    txtMail.Text = cliente.MailContacto;
                    txtDireccion.Text = cliente.Direccion;
                    txtTelefono.Text = cliente.Telefono;
                    cboActividad.SelectedIndex = cliente.IdActividadEmpresa;
                    cboTipo.SelectedIndex = cliente.IdTipoEmpresa;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error buscando cliente");
            }
        }

        private void BtnGuardarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string rut = txtRut.Text.ToString().Replace(".", "");
                rut = rut.Replace(" ", "");

                string correo = txtMail.Text;

                Cliente cliente = new Cliente();

                if (rut == "")
                {
                    MessageBox.Show("Por favor ingrese un RUT");
                }
                else if (ClienteCollection.BuscarClientePorRut(rut) != null)
                {
                    MessageBox.Show("Este cliente/Rut ya se encuentra en sistema");
                }
                else
                {

                    if (!Validadores.validarRut(rut))
                    {
                        MessageBox.Show("Rut incorrecto");
                        return;
                    }
                    else if (!Validadores.validarCorreo(correo))
                    {
                        MessageBox.Show("Correo incorrecto");
                        return;
                    }
                    else
                    {

                        cliente.RutCliente = rut.Replace(".", "");
                        cliente.RazonSocial = txtRazon.Text;
                        cliente.NombreContacto = txtNombre.Text;
                        cliente.MailContacto = txtMail.Text;
                        cliente.Direccion = txtDireccion.Text;
                        cliente.Telefono = txtTelefono.Text;
                        cliente.IdActividadEmpresa = int.Parse(cboActividad.SelectedValue.ToString());
                        cliente.IdTipoEmpresa = int.Parse(cboTipo.SelectedValue.ToString());

                        if (ClienteCollection.AgregarCliente(cliente))
                        {
                            MessageBox.Show("Cliente agregado correctamente");
                            dgClientes.ItemsSource = ClienteCollection.ReadAll();
                        }
                        else
                        {
                            MessageBox.Show("Cliente no se pudo agregar");
                        }
                    }
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Error al guardar");
            }
        }

        private void BtnActualizarCliente_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            string rut = txtRut.Text.ToString().Replace(".", "");
            rut = rut.Replace(" ", "");

            try
            {
                if (rut == "")
                {
                    MessageBox.Show("Por favor ingrese un RUT");
                }
                else if (ClienteCollection.BuscarClientePorRut(rut) == null)
                {
                    MessageBox.Show("Cliente no existe");
                    return;
                }
                else if (txtRazon.Equals(cliente.RazonSocial) || txtNombre.Equals(cliente.NombreContacto) ||
                         txtMail.Equals(cliente.MailContacto) || txtDireccion.Equals(cliente.Direccion) ||
                         txtTelefono.Equals(cliente.Telefono) || int.Parse(cboActividad.SelectedValue.ToString()) == cliente.IdActividadEmpresa ||
                         int.Parse(cboTipo.SelectedValue.ToString()) == cliente.IdTipoEmpresa)
                {
                    MessageBox.Show("No hay cambios");
                    return;
                }
                else
                {

                    cliente.RutCliente = rut;
                    cliente.RazonSocial = txtRazon.Text;
                    cliente.NombreContacto = txtNombre.Text;
                    cliente.MailContacto = txtMail.Text;
                    cliente.Direccion = txtDireccion.Text;
                    cliente.Telefono = txtTelefono.Text;
                    cliente.IdActividadEmpresa = int.Parse(cboActividad.SelectedValue.ToString());
                    cliente.IdTipoEmpresa = int.Parse(cboTipo.SelectedValue.ToString());

                    if (ClienteCollection.ModificarCliente(cliente))
                    {
                        MessageBox.Show("Cliente modificado correctamente");
                        dgClientes.ItemsSource = ClienteCollection.ReadAll();
                    }
                    else
                    {
                        MessageBox.Show("Este cliente no se pudo modificar");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al modificar");
            }
        }

        private void btnEliminarCliente_Click(object sender, RoutedEventArgs e)
        {

            Cliente cliente = ClienteCollection.BuscarClientePorRut(txtRut.Text);
            Contrato contrato = ContratoCollection.BuscarContratoPorRut(txtRut.Text);

            try
            {
                if (cliente != null)
                {

                    if (contrato != null)
                    {
                        MessageBox.Show("Cliente posee contratos, no se puede eliminar");
                    }
                    else
                    {
                        ClienteCollection.EliminarCliente(txtRut.Text);
                        MessageBox.Show("Cliente eliminado correctamente");
                    }
                }
                else
                {
                    MessageBox.Show("Cliente no existe");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error eliminando cliente");
            }




        }

        private void BtnListadoClientes_Click(object sender, RoutedEventArgs e)
        {

            VentanaListaClientesVisible();

            if (btnListadoClientes.IsPressed)
            {
                btnClienteToGestionCliente.Visibility = Visibility.Hidden;
            }
            else
            {
                btnClienteToGestionCliente.Visibility = Visibility.Visible;
            }
        }
        
        private void BtnLimpiarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtRut.Text = "";
                txtRazon.Text = "";
                txtNombre.Text = "";
                txtMail.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";

                cboActividad.SelectedIndex = -1;
                cboTipo.SelectedIndex = -1;
            }
            catch (Exception)
            {

                MessageBox.Show("Error limpiando campos");
            }
        }


        //Lista Clientes
        private void BtnFiltrarRutCliente_Click(object sender, RoutedEventArgs e)
        {
            string rut = txtBuscarRutCliente.Text.Replace(" ", "");
            rut = rut.Replace(".", "");

            if (rut == "")
            {
                MessageBox.Show("Para buscar un cliente debe ingresar un RUT");
                CargarListaClientes();
            }
            else if (rut.Length < 9 || rut.Length > 12)
            {
                MessageBox.Show("Por favor ingrese un RUT valido");
            }
            else if (ClienteCollection.BuscarClientePorRut(rut) == null)
            {

                MessageBox.Show("Cliente no existe");
                CargarListaClientes();
                txtBuscarRutCliente.Text = "";
            }
            else
            {

                dgClientes.ItemsSource = null;
                dgClientes.ItemsSource = ClienteCollection.ClienteFiltrarPorRut(rut);
                txtBuscarRutCliente.Text = "";
            }
        }

        private void BtnFiltrarActividadCliente_Click(object sender, RoutedEventArgs e)
        {

            if (cboFiltrarActividadCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Para filtrar por actividad primero debe seleccionarla");
                CargarListaClientes();
            }
            else if (ClienteCollection.BuscarClientePorActividad(int.Parse(cboFiltrarActividadCliente.SelectedValue.ToString())) == null)
            {

                MessageBox.Show("No existen Clientes con la actividad seleccionada");
                CargarListaClientes();
                cboFiltrarActividadCliente.SelectedIndex = -1;
            }
            else
            {

                dgClientes.ItemsSource = null;
                dgClientes.ItemsSource = ClienteCollection.ClienteFiltrarPorActividad(int.Parse(cboFiltrarActividadCliente.SelectedValue.ToString()));
                cboFiltrarActividadCliente.SelectedIndex = -1;
            }
        }

        private void BtnFiltrarTipoCliente_Click(object sender, RoutedEventArgs e)
        {
            if (cboFiltrarTipoCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Para filtrar por tipo primero debe seleccionarlo");
                CargarListaClientes();
            }
            else if (ClienteCollection.BuscarClientePorTipo(int.Parse(cboFiltrarTipoCliente.SelectedValue.ToString())) == null)
            {

                MessageBox.Show("No existen Contratos con el tipo de Cliente seleccionado");
                CargarListaClientes();
                cboFiltrarTipoCliente.SelectedIndex = -1;
            }
            else
            {

                dgClientes.ItemsSource = null;
                dgClientes.ItemsSource = ClienteCollection.ClienteFiltrarPorTipo(int.Parse(cboFiltrarTipoCliente.SelectedValue.ToString()));
                cboFiltrarTipoCliente.SelectedIndex = -1;
            }
        }

        private void btnClienteToGestionCliente_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = (Cliente)dgClientes.SelectedItem;

                txtRut.Text = cliente.RutCliente;
                txtRazon.Text = cliente.RazonSocial;
                txtNombre.Text = cliente.NombreContacto;
                txtMail.Text = cliente.MailContacto;
                txtDireccion.Text = cliente.Direccion;
                txtTelefono.Text = cliente.Telefono;
                cboActividad.SelectedIndex = cliente.IdActividadEmpresa;
                cboTipo.SelectedIndex = cliente.IdTipoEmpresa;

            VentanaGestionClienteVisible();

        }

        private void btnClienteToListaContratos_Click(object sender, RoutedEventArgs e)
        {

            Cliente cliente = (Cliente)dgClientes.SelectedItem;
            string rut = cliente.RutCliente;

            Contrato contrato = ContratoCollection.BuscarContratoPorRut(rut);

            if (contrato != null)
            {
                dgListaContratos.ItemsSource = ContratoCollection.ContratoListarPorRut(rut);
                VentanaListaContratosVisible();
            }
            else
            {
                MessageBox.Show("No existen contratos asociados a este cliente");
            }

        }


        //Gestion Contratos
        private void CargarDatosVentanaContrato(Contrato contrato)
        {

            txtNumeroDeContrato.Text = contrato.Numero;
            txtRutClienteContrato.Text = contrato.RutCliente;
            txtNombreClienteContrato.Text = ClienteCollection.BuscarClientePorRut(contrato.RutCliente).NombreContacto;

            /********************************************************************************************************/
            cboTipoEventoContrato.SelectedValue = int.Parse(contrato.ModalidadServicio.IdTipoEvento.ToString());
            cboModalidadEventoContrato.SelectedValue = contrato.ModalidadServicio.IdModalidad.ToString();
            /********************************************************************************************************/

            txtAsistentes.Text = contrato.Asistentes.ToString();
            txtPersonalAdicional.Text = contrato.PersonalAdicional.ToString();

            fechaInicioPicker.SelectedDate = contrato.Creacion;
            fechaTerminoPicker.SelectedDate = contrato.Termino;
            horaInicioPicker.SelectedTime = contrato.FechaHoraInicio;
            horaTerminoPicker.SelectedTime = contrato.FechaHoraTermino;
            txtAsistentes.Text = contrato.Asistentes.ToString();
            txtObservaciones.Text = contrato.Observaciones;


            VentanaGestionContratoVisible();
        }

        private void CamposVentanaContratoDisable()
        {
            txtNumeroDeContrato.IsEnabled = false;
            txtRutClienteContrato.IsEnabled = false;
            txtNombreClienteContrato.IsEnabled = false;
            cboTipoEventoContrato.IsEnabled = false;
            cboModalidadEventoContrato.IsEnabled = false;
            txtAsistentes.IsEnabled = false;
            txtPersonalAdicional.IsEnabled = false;
            txtValorEvento.IsEnabled = false;
            fechaInicioPicker.IsEnabled = false;
            fechaTerminoPicker.IsEnabled = false;
            horaInicioPicker.IsEnabled = false;
            horaTerminoPicker.IsEnabled = false;
            txtObservaciones.IsEnabled = false;
            popGestionContrato.IsEnabled = false;
            btnValorEvento.IsEnabled = false;
        }

        private void SelectionChangedTipoEvento()
        {
            if (cboTipoEventoContrato.SelectedIndex == -1)
            {
                cboModalidadEventoContrato.ItemsSource = null;
                btnVegetariana.Visibility = Visibility.Hidden;
                lblVegetariana.Visibility = Visibility.Hidden;
            }
            else
            {
                int evento = int.Parse(cboTipoEventoContrato.SelectedValue.ToString());
                cboModalidadEventoContrato.ItemsSource = null;
                cboModalidadEventoContrato.ItemsSource = ModalidadServicioCollection.BuscarModalidad(evento);

                if (int.Parse(cboTipoEventoContrato.SelectedValue.ToString()) == 10)
                {
                    btnVegetariana.Visibility = Visibility.Visible;
                    lblVegetariana.Visibility = Visibility.Visible;
                }
                else
                {
                    btnVegetariana.Visibility = Visibility.Hidden;
                    lblVegetariana.Visibility = Visibility.Hidden;
                }
            }

        }
        private void SelectionChangedModalidad()
        {
            if (cboModalidadEventoContrato.SelectedIndex == -1)
            {

                txtAsistentes.Text = null;
                txtPersonalAdicional.Text = null;
            }
            else
            {

                string evento = cboModalidadEventoContrato.SelectedValue.ToString();

                txtPersonalBase.Text = ModalidadServicioCollection.personalBase(evento).ToString();

            }
        }

        private void BtnBuscarNumeroDeContrato_Click(object sender, RoutedEventArgs e)
        {
            Contrato contrato = this.ContratoCollection.BuscarContratoPorNumero(txtNumeroDeContrato.Text.ToString());
            txtNumeroDeContrato.IsEnabled = false;
            txtRutClienteContrato.IsEnabled = false;

            try
            {
                if (contrato == null)
                {

                    MessageBox.Show("Contrato no existe");
                }
                else
                {
                    if (contrato.Realizado == false)
                    {
                        MessageBox.Show("Este contrato se encuentra terminado");
                        CamposVentanaContratoDisable();
                        CargarDatosVentanaContrato(contrato);
                        return;

                    }
                    else if (contrato.FechaHoraTermino < DateTime.Today)
                    {
                        MessageBox.Show("Los contratos con fecha de termino posterior a la actual se encuentran bloqueados");
                        CamposVentanaContratoDisable();
                        CargarDatosVentanaContrato(contrato);
                        return;
                    }
                    else
                    {

                        CargarDatosVentanaContrato(contrato);
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error buscando contrato");
            }
        }

        private void BtnBuscarRutContrato_Click(object sender, RoutedEventArgs e)
        {
            String rut = txtRutClienteContrato.Text.Replace(".", "");
            rut = rut.Replace(" ", "");

            Cliente cliente = this.ClienteCollection.BuscarClientePorRut(rut);

            try
            {
                if (rut == "")
                {
                    MessageBox.Show("Por favor ingrese un RUT");
                }
                else if (cliente == null)
                {
                    MessageBox.Show("Cliente no existe");
                }
                else
                {
                    txtNombreClienteContrato.Text = cliente.NombreContacto;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error buscando cliente");
            }
        }

        private void BtnLimpiarContrato_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtNumeroDeContrato.Text = "";
                txtRutClienteContrato.Text = "";
                txtNombreClienteContrato.Text = "";
                txtValorEvento.Text = "";
                txtObservaciones.Text = "";
                txtPersonalBase.Text = "";

                cboTipoEventoContrato.SelectedIndex = -1;
                txtAsistentes.Text = "";
                txtPersonalAdicional.Text = "";
                cboModalidadEventoContrato.SelectedIndex = -1;

                fechaInicioPicker.SelectedDate = null;
                fechaTerminoPicker.SelectedDate = null;
                horaInicioPicker.SelectedTime = null;
                horaTerminoPicker.SelectedTime = null;


                txtNumeroDeContrato.IsEnabled = true;
                txtRutClienteContrato.IsEnabled = true;
                cboTipoEventoContrato.IsEnabled = true;
                cboModalidadEventoContrato.IsEnabled = true;
                txtAsistentes.IsEnabled = true;
                txtPersonalAdicional.IsEnabled = true;
                txtValorEvento.IsEnabled = true;
                fechaInicioPicker.IsEnabled = true;
                fechaTerminoPicker.IsEnabled = true;
                horaInicioPicker.IsEnabled = true;
                horaTerminoPicker.IsEnabled = true;
                txtObservaciones.IsEnabled = true;
                popGestionContrato.IsEnabled = true;
            }
            catch (Exception)
            {

                MessageBox.Show("Error limpiando campos");
            }
        }

        private void BtnListaContratosGestion_Click(object sender, RoutedEventArgs e)
        {

            VentanaListaContratosVisible();

            if (btnListaContratosGestion.IsPressed)
            {
                btnContratoToGestion.Visibility = Visibility.Hidden;
            }
            else
            {
                btnContratoToGestion.Visibility = Visibility.Visible;
            }
        }

        private void BtnValorEvento_Click(object sender, RoutedEventArgs e)
        {
            Contrato contrato = new Contrato();

            try
            {
                string e_Calculo = cboModalidadEventoContrato.SelectedValue.ToString();
                int cantidadAsistentes = int.Parse(txtAsistentes.Text.ToString());
                int personalAdicional = int.Parse(txtPersonalAdicional.Text.ToString());

                txtValorEvento.Text = Valorizador.CalculoEvento(e_Calculo, cantidadAsistentes, personalAdicional).ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Error calculando valor");
            }
        }

        private void PopCrearContrato_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Contrato contrato = new Contrato();
                ModalidadServicio modalidadServicio = new ModalidadServicio();

                contrato.Numero = DateTime.Now.ToString("yyyyMMddHHmm");


                //guardamos fecha de creacion de contrato con formato dia/mes/año
                string fechaCreacion = DateTime.Now.ToString("dd/MM/yyyy");
                contrato.Creacion = DateTime.Parse(fechaCreacion);

                //guardamos la fecha de creacion en fecha termino para cuando el usuario termne el contrato esta fecha sea reemplazada
                string fechaTerminoUsuario = DateTime.Now.ToString("dd/MM/yyyy");
                contrato.Termino = DateTime.Parse(fechaTerminoUsuario);

                //Guardamos rut sin puntos ni espacios
                string rut = txtRutClienteContrato.Text.Replace(".", "");
                rut = rut.Replace(" ", "");
                contrato.RutCliente = rut;

                contrato.IdTipoEvento = int.Parse(cboTipoEventoContrato.SelectedValue.ToString());
                contrato.IdModalidad = cboModalidadEventoContrato.SelectedValue.ToString().Trim();

                //guardamos la fecha y hora de inicio del evento
                string fechaInicio = fechaInicioPicker.SelectedDate.Value.ToString("dd/MM/yyyy");
                string horaInicio = horaInicioPicker.SelectedTime.Value.ToString("HH:mm");
                //contrato.FechaHoraInicio = DateTime.Parse(fechaInicio + " " + horaInicio);

                //guardamos la fecha y hora del termino del evento
                string fechaTermino = fechaTerminoPicker.SelectedDate.Value.ToString("dd/MM/yyyy");
                //contrato.FechaHoraTermino = horaTerminoPicker.SelectedTime.Value;



                string hoy = DateTime.Today.ToString("dd/MM/yyyy");
                string ahora = DateTime.Now.ToString("HH:mm");

                if (DateTime.Parse(fechaInicio) < DateTime.Parse(hoy) || DateTime.Parse(horaInicio) < DateTime.Parse(ahora))
                {
                    MessageBox.Show("El evento no puede ser anterior al dia de hoy");
                    return;
                }
                else if (DateTime.Parse(fechaInicio) > DateTime.Parse(hoy).AddMonths(10))
                {
                    MessageBox.Show("La fecha de evento no puede exceder a 10 meses de la fecha actual");
                    return;
                }
                else if (DateTime.Parse(fechaTermino) > DateTime.Parse(fechaInicio).AddHours(24))
                {
                    MessageBox.Show("El evento no puede exceder las 24 horas");
                    return;
                }
                else
                {
                    contrato.FechaHoraInicio = DateTime.Parse(fechaInicio + " " + horaInicio);
                    contrato.FechaHoraTermino = horaTerminoPicker.SelectedTime.Value;
                }


                contrato.Asistentes = int.Parse(txtAsistentes.Text.ToString());
                contrato.PersonalAdicional = int.Parse(txtPersonalAdicional.Text.ToString());

                contrato.Observaciones = txtObservaciones.Text.ToString();
                contrato.Realizado = false;

                //calculamos valor del contrato para guardarlo
                string e_Calculo = cboModalidadEventoContrato.SelectedValue.ToString();
                int cantidadAsistentes = int.Parse(txtAsistentes.Text.ToString());
                int personalAdicional = int.Parse(txtPersonalAdicional.Text.ToString());
                contrato.ValorTotalContrato = Valorizador.CalculoEvento(e_Calculo, cantidadAsistentes, personalAdicional);

                if (this.ContratoCollection.CrearContrato(contrato))
                {
                    txtNumeroDeContrato.Text = DateTime.Now.ToString("ddMMyyyyHHmm");
                    MessageBox.Show("Contrato creado correctamente");
                    dgListaContratos.ItemsSource = null;
                    dgListaContratos.ItemsSource = ContratoCollection.ReadAll();
                }
                else
                {
                    MessageBox.Show("Contrato no se pudo crear, no pueden quedar campos vacios");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Error al crear contrato");
            }
        }

        private void PopActualizarContrato_Click(object sender, RoutedEventArgs e)
        {
            Contrato contrato = new Contrato();


            try
            {
                if (ContratoCollection.BuscarContratoPorNumero(txtNumeroDeContrato.Text.ToString()) == null)
                {

                    MessageBox.Show("Numero de contrato no existe");
                    return;
                }
                else
                { 

                    contrato.Creacion = fechaInicioPicker.SelectedDate.Value;

                    contrato.Termino = fechaTerminoPicker.SelectedDate.Value;

                    contrato.Numero = txtNumeroDeContrato.Text.ToString();

                    contrato.IdTipoEvento = int.Parse(cboTipoEventoContrato.SelectedValue.ToString());
                    contrato.IdModalidad = cboModalidadEventoContrato.SelectedValue.ToString();

                    contrato.FechaHoraInicio = horaInicioPicker.SelectedTime.Value;
                    contrato.FechaHoraTermino = horaTerminoPicker.SelectedTime.Value;

                    contrato.Asistentes = int.Parse(txtAsistentes.Text.ToString());
                    contrato.PersonalAdicional = int.Parse(txtPersonalAdicional.Text.ToString());

                    contrato.Observaciones = txtObservaciones.Text.ToString();
                    //contrato.Realizado = false;

                    string e_Calculo = cboModalidadEventoContrato.SelectedValue.ToString();
                    int cantidadAsistentes = int.Parse(txtAsistentes.Text.ToString());
                    int personalAdicional = int.Parse(txtPersonalAdicional.Text.ToString());
                    contrato.ValorTotalContrato = Valorizador.CalculoEvento(e_Calculo, cantidadAsistentes, personalAdicional);


                    if (ContratoCollection.ModificarContrato(contrato))
                    {
                        MessageBox.Show("Contrato actualizado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Contrato no se pudo actualizar");
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al actualizar contrato");
            }
        }

        private void PopTerminarContrato_Click(object sender, RoutedEventArgs e)
        {
            string numero = txtNumeroDeContrato.Text.ToString();
            Contrato contrato = ContratoCollection.BuscarContratoPorNumero(numero);


            try
            {
                if (contrato == null)
                {
                    MessageBox.Show("Contrato no existe");
                }
                else if (contrato.Realizado == false)
                {
                    MessageBox.Show("Este contrato ya se encuentra terminado");
                    return;
                }
                else
                {

                    if (MessageBox.Show("¿Desea terminar este contrato?", "Confirme", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    {

                            if (ContratoCollection.TerminarContrato(contrato))
                            {

                                contrato.Realizado = false;
                                contrato.Termino = DateTime.Now;
                                MessageBox.Show("Contrato terminado correctamente");
                                dgListaContratos.ItemsSource = null;
                                dgListaContratos.ItemsSource = ContratoCollection.ReadAll();
                            }
                            else
                            {

                                MessageBox.Show("Error Terminando contrato");
                            }
                    }
                    else
                    {

                        return;
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error Terminando contrato");
            }
        }

        private void CboTipoEventoContrato_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            SelectionChangedTipoEvento();

            if (cboTipoEventoContrato.SelectedIndex == -1)
            {
                stackAmbientacionBasica.IsEnabled = false;
                stackAmbientacionPersonalizada.IsEnabled = false;
            }
            else if (int.Parse(cboTipoEventoContrato.SelectedValue.ToString()) == 10)
            {
                stackAmbientacionBasica.IsEnabled = false;
                stackAmbientacionPersonalizada.IsEnabled = false;
            }
            else if (int.Parse(cboTipoEventoContrato.SelectedValue.ToString()) == 20)
            {
                stackAmbientacionBasica.IsEnabled = true;
                stackAmbientacionPersonalizada.IsEnabled = true;
            }
            else
            {
                stackAmbientacionBasica.IsEnabled = true;
                stackAmbientacionPersonalizada.IsEnabled = true;
            }

        }

        private void CboModalidadEventoContrato_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectionChangedModalidad();
        }

        private void chkAmbientacionBasica_Checked(object sender, RoutedEventArgs e)
        {

            boxAmbientacionBasica.IsEnabled = true;
            stackAmbientacionPersonalizada.IsEnabled = false;


            if (cboTipoEventoContrato.SelectedIndex == -1)
            {

                stackAmbientacionBasica.IsEnabled = false;
                stackAmbientacionPersonalizada.IsEnabled = false;
            }
            else if (int.Parse(cboTipoEventoContrato.SelectedValue.ToString()) == 10)
            {

                stackAmbientacionBasica.IsEnabled = false;
                stackAmbientacionPersonalizada.IsEnabled = false;
            }
            else if (int.Parse(cboTipoEventoContrato.SelectedValue.ToString()) == 20)
            {

                stackAmbientacionPersonalizada.IsEnabled = false;
            }
            else
            {

                stackAmbientacionPersonalizada.IsEnabled = false;
            }

        }

        private void chkAmbientacionBasica_Unchecked(object sender, RoutedEventArgs e)
        {

            boxAmbientacionBasica.IsEnabled = false;

            if (cboTipoEventoContrato.SelectedIndex == -1)
            {
                stackAmbientacionBasica.IsEnabled = false;
                stackAmbientacionPersonalizada.IsEnabled = false;
            }
            else if (int.Parse(cboTipoEventoContrato.SelectedValue.ToString()) == 10)
            {
                stackAmbientacionBasica.IsEnabled = false;
                stackAmbientacionPersonalizada.IsEnabled = false;
            }
            else if (int.Parse(cboTipoEventoContrato.SelectedValue.ToString()) == 20)
            {
                stackAmbientacionBasica.IsEnabled = true;
                stackAmbientacionPersonalizada.IsEnabled = true;
            }
            else
            {
                stackAmbientacionBasica.IsEnabled = true;
                stackAmbientacionPersonalizada.IsEnabled = true;
                chkAmbientacionPersonalizada.IsChecked = true;
            }

        }

        private void chkAmbientacionPersonalizada_Checked(object sender, RoutedEventArgs e)
        {

            boxAmientacionPersonalizada.IsEnabled = true;
            stackAmbientacionBasica.IsEnabled = false;


            if (cboTipoEventoContrato.SelectedIndex == -1)
            {

                stackAmbientacionBasica.IsEnabled = false;
                stackAmbientacionPersonalizada.IsEnabled = false;
            }
            else if (int.Parse(cboTipoEventoContrato.SelectedValue.ToString()) == 10)
            {

                stackAmbientacionBasica.IsEnabled = false;
                stackAmbientacionPersonalizada.IsEnabled = false;
            }
            else if (int.Parse(cboTipoEventoContrato.SelectedValue.ToString()) == 20)
            {

                stackAmbientacionBasica.IsEnabled = false;
            }
            else
            {

                stackAmbientacionPersonalizada.IsEnabled = true;
                chkAmbientacionBasica.IsChecked = false;
            }



        }

        private void chkAmbientacionPersonalizada_Unchecked(object sender, RoutedEventArgs e)
        {

            boxAmientacionPersonalizada.IsEnabled = false;

            if (cboTipoEventoContrato.SelectedIndex == -1)
            {

                stackAmbientacionBasica.IsEnabled = false;
                stackAmbientacionPersonalizada.IsEnabled = false;
            }
            else if (int.Parse(cboTipoEventoContrato.SelectedValue.ToString()) == 10)
            {

                stackAmbientacionBasica.IsEnabled = false;
                stackAmbientacionPersonalizada.IsEnabled = false;
            }
            else if (int.Parse(cboTipoEventoContrato.SelectedValue.ToString()) == 20)
            {

                stackAmbientacionBasica.IsEnabled = true;
                stackAmbientacionPersonalizada.IsEnabled = true;
            }
            else
            {

                stackAmbientacionBasica.IsEnabled = true;
                stackAmbientacionPersonalizada.IsEnabled = true;
                chkAmbientacionBasica.IsChecked = true;
            }
        }


        //Lista Contratos
        private void BtnFiltrarNumeroContrato_Click(object sender, RoutedEventArgs e)
        {
            string numero = txtBuscarNumeroContrato.Text.Replace(" ", "");

            if (numero == "")
            {
                MessageBox.Show("Porfavor ingrese numero de contrato");
                CargarListaContratos();
            }
            else if (numero.Length < 12)
            {
                MessageBox.Show("Por favor ingrese un numero de contrato valido");
                CargarListaContratos();
            }
            else if (ContratoCollection.BuscarContratoPorNumero(numero) == null)
            {

                MessageBox.Show("No existe Contrato con numero ingresado");
                CargarListaContratos();

            }
            else
            {

                dgListaContratos.ItemsSource = null;
                dgListaContratos.ItemsSource = ContratoCollection.ContratoListarFiltroNumero(numero);
                txtBuscarNumeroContrato.Text = "";
            }
        }

        private void BtnFiltrarRutContrato_Click(object sender, RoutedEventArgs e)
        {
            string rut = txtBuscarRutContrato.Text.Replace(" ", "");
            rut = txtBuscarRutContrato.Text.Replace(".", "");

            if (rut.Length < 9)
            {
                MessageBox.Show("Por favor ingrese un RUT valido");
                CargarListaContratos();
            }
            else if (rut == "")
            {
                MessageBox.Show("Por favor ingrese un RUT");
                CargarListaContratos();
            }
            else if (ContratoCollection.BuscarContratoPorRut(rut) != null)
            {
                dgListaContratos.ItemsSource = null;
                dgListaContratos.ItemsSource = ContratoCollection.ContratoListarFiltroRutCliente(rut);
                txtBuscarRutContrato.Text = "";
            }
            else
            {
                MessageBox.Show("No existen contratos asociados a este RUT");
                CargarListaContratos();
            }
        }

        private void BtnFiltrarTipoEventoContrato_Click(object sender, RoutedEventArgs e)
        {
            if (cboFiltrarTipoEvento.SelectedIndex == -1)
            {
                MessageBox.Show("Para filtrar por tipo primero debe seleccionarlo");
                CargarListaContratos();
            }
            else if (ContratoCollection.BuscarContratoPorTipo(int.Parse(cboFiltrarTipoEvento.SelectedValue.ToString())) == null)
            {

                MessageBox.Show("No existen Contratos con el tipo seleccionado");
                CargarListaContratos();
                cboFiltrarTipoEvento.SelectedIndex = -1;
            }
            else
            {

                dgListaContratos.ItemsSource = null;
                dgListaContratos.ItemsSource = ContratoCollection.ContratoListarFiltroTipoEvento(int.Parse(cboFiltrarTipoEvento.SelectedValue.ToString()));
                cboFiltrarTipoEvento.SelectedIndex = -1;
            }
        }

        private void btnContratoToGestion_Click(object sender, RoutedEventArgs e)
        {

            Contrato contrato = (Contrato)dgListaContratos.SelectedItem;

            CargarDatosVentanaContrato(contrato);

            if (contrato.Realizado == false)
            {
                CamposVentanaContratoDisable();
                MessageBox.Show("Este contrato se encuentra terminado");
            }
        }

        
        //Caché
        private void RespaldarFormularioContrato()
        {

            Dispatcher.Invoke(() =>
            {

                Contrato contrato = new Contrato();

                contrato.Numero = txtNumeroDeContrato.Text;
                contrato.RutCliente = txtRutClienteContrato.Text;

                if (cboTipoEventoContrato.SelectedValue != null)
                {
                    contrato.IdTipoEvento = int.Parse(cboTipoEventoContrato.SelectedValue.ToString());
                }

                if (cboModalidadEventoContrato.SelectedValue != null)
                {
                    contrato.IdModalidad = cboModalidadEventoContrato.SelectedValue.ToString();
                }

                if (fechaInicioPicker.SelectedDate != null)
                {
                    contrato.FechaHoraInicio = DateTime.Parse(fechaInicioPicker.SelectedDate.Value.ToString());
                }

                if (fechaTerminoPicker.SelectedDate != null)
                {
                    contrato.FechaHoraTermino = DateTime.Parse(horaTerminoPicker.SelectedTime.Value.ToString());
                }


                //if (txtAsistentes.Text != null)
                //{

                //    contrato.Asistentes = int.Parse(txtAsistentes.Text.ToString());
                //}


                //if (txtPersonalAdicional.Text != null)
                //{
                //    contrato.PersonalAdicional = int.Parse(txtPersonalAdicional.Text.ToString());
                //}

                

                contrato.Observaciones = txtObservaciones.Text.ToString();

                //contrato.ValorTotalContrato = int.Parse(txtValorEvento.Text.ToString());


                FileCache fileCache = new FileCache(new ObjectBinder());

                fileCache["contrato"] = contrato;
                DateTime ahora = DateTime.Now;
                fileCache["fecha_respaldo"] = ahora;
                txtfechaCache.Text = ahora.ToString("dd-MM-yyyy HH:mm:ss");
            });

        }

        private void btnRespaldo_Click(object sender, RoutedEventArgs e)
        {
            RespaldarFormularioContrato();
        }
    }
}