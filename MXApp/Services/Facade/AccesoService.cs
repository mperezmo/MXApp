using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Services.Logic.AccesoLogic;

namespace Services.Facade
{
    public static class AccesoService
    {
        // Configurar acceso solo para menús
        public static void ConfigureMenuItems(ToolStripMenuItem AsignarRolItem,
    ToolStripMenuItem CrearUsuarioItem,
    ToolStripMenuItem ModificarUsuarioItem,
    ToolStripMenuItem BackupItem,
    ToolStripMenuItem MostrarUsuarioItem,
    ToolStripMenuItem CrearRolItem,
    ToolStripMenuItem CrearAccesoItem,
    ToolStripMenuItem ReportesItem,
    ToolStripMenuItem ReporteClienteItem,
    //ToolStripMenuItem ReporteOcupacionDiariaItem,
    //ToolStripMenuItem ReporteReservasCanceladasItem,
    ToolStripMenuItem ReciboItem,
    ToolStripMenuItem ConsultarReciboItem,
    ToolStripMenuItem GestionReservaItem,
    ToolStripMenuItem GenerarReservaItem,
    ToolStripMenuItem ModificarReservaItem,
    ToolStripMenuItem GestionTarifaItem,
    ToolStripMenuItem AgregarTarifaItem,
    ToolStripMenuItem EditarTarifaItem,
    //ToolStripMenuItem DeshabilitarTarifaItem,
    ToolStripMenuItem GestionClienteItem,
    ToolStripMenuItem VehiculoItem,
    ToolStripMenuItem ClientesItem,
    ToolStripMenuItem GestionEstacionamientoItem,
    ToolStripMenuItem AgregarEstacionamientoItem,
    ToolStripMenuItem ModificarEstacionamientoItem,
    ToolStripMenuItem PaneladministradorItem,
    List<Patente> patentesUsuario)
        {

            //Gestion Estacionamiento
            var GestionEstacionamiento = new MenuItemDecorator(GestionEstacionamientoItem, "GestionEstacionamiento");
            var AgregarEstacionamiento = new MenuItemDecorator(AgregarEstacionamientoItem, "AgregarEstacionamiento");
            var ModificarEstacionamiento = new MenuItemDecorator(ModificarEstacionamientoItem, "ModificarEstacionamiento");
            // Menú de administración de usuarios
            var PanelAdministrador = new MenuItemDecorator(PaneladministradorItem, "PanelAdministrador");
            var crearUsuario = new MenuItemDecorator(CrearUsuarioItem, "CrearUsuario");
            var modificarUsuario = new MenuItemDecorator(ModificarUsuarioItem, "ModificarUsuario");
            var asignarRol = new MenuItemDecorator(AsignarRolItem, "AsignarRol");
            var backup = new MenuItemDecorator(BackupItem, "Backup");
            var mostrarUsuario = new MenuItemDecorator(MostrarUsuarioItem, "MostrarUsuario");
            var crearRol = new MenuItemDecorator(CrearRolItem, "CrearRol");
            var crearAcceso = new MenuItemDecorator(CrearAccesoItem, "CrearAcceso");

            // Menú de reportes
            var reportes = new MenuItemDecorator(ReportesItem, "Reportes");
            var reporteCliente = new MenuItemDecorator(ReporteClienteItem, "ReporteCliente");
            //var reporteOcupacionDiaria = new MenuItemDecorator(ReporteOcupacionDiariaItem, "ReporteOcupacionDiaria");
            //var reporteReservasCanceladas = new MenuItemDecorator(ReporteReservasCanceladasItem, "ReporteReservasCanceladas");

            // Menú de recibos
            var recibo = new MenuItemDecorator(ReciboItem, "Recibo");
            var consultarRecibo = new MenuItemDecorator(ConsultarReciboItem, "ConsultarRecibo");

            // Menú de reservas
            var gestionReserva = new MenuItemDecorator(GestionReservaItem, "GestionReserva");
            var generarReserva = new MenuItemDecorator(GenerarReservaItem, "GenerarReserva");
            var modificarReserva = new MenuItemDecorator(ModificarReservaItem, "ModificarReserva");

            // Menú de tarifas
            var gestionTarifa = new MenuItemDecorator(GestionTarifaItem, "GestionTarifa");
            var agregarTarifa = new MenuItemDecorator(AgregarTarifaItem, "AgregarTarifa");
            var editarTarifa = new MenuItemDecorator(EditarTarifaItem, "EditarTarifa");
            //var deshabilitarTarifa = new MenuItemDecorator(DeshabilitarTarifaItem, "DeshabilitarTarifa");

            // Menú de clientes
            var gestionCliente = new MenuItemDecorator(GestionClienteItem, "GestionCliente");
            var vehiculo = new MenuItemDecorator(VehiculoItem, "Vehiculo");
            var clientes = new MenuItemDecorator(ClientesItem, "Clientes");

            // Aplicar acceso a los menús
            PanelAdministrador.SetAccess(patentesUsuario);
            crearUsuario.SetAccess(patentesUsuario);
            modificarUsuario.SetAccess(patentesUsuario);
            asignarRol.SetAccess(patentesUsuario);
            backup.SetAccess(patentesUsuario);
            mostrarUsuario.SetAccess(patentesUsuario);
            crearRol.SetAccess(patentesUsuario);
            crearAcceso.SetAccess(patentesUsuario);

            GestionEstacionamiento.SetAccess(patentesUsuario);
            AgregarEstacionamiento.SetAccess(patentesUsuario);
            ModificarEstacionamiento.SetAccess(patentesUsuario);

            reportes.SetAccess(patentesUsuario);
            reporteCliente.SetAccess(patentesUsuario);
            //reporteOcupacionDiaria.SetAccess(patentesUsuario);
            //reporteReservasCanceladas.SetAccess(patentesUsuario);

            recibo.SetAccess(patentesUsuario);
            consultarRecibo.SetAccess(patentesUsuario);

            gestionReserva.SetAccess(patentesUsuario);
            generarReserva.SetAccess(patentesUsuario);
            modificarReserva.SetAccess(patentesUsuario);

            gestionTarifa.SetAccess(patentesUsuario);
            agregarTarifa.SetAccess(patentesUsuario);
            editarTarifa.SetAccess(patentesUsuario);
            //deshabilitarTarifa.SetAccess(patentesUsuario);

            gestionCliente.SetAccess(patentesUsuario);
            vehiculo.SetAccess(patentesUsuario);
            clientes.SetAccess(patentesUsuario);



        }
        //Configurar acceso solo para controles (sin uso actualmente)
        public static void ConfigureControls(Button button1, List<Patente> patentesUsuario)
        {


            // Crear decoradores para los controles
            //var CerrarSessionAccess = new ControlDecorator(button1, "BotonAcceso");

            // Aplicar accesos a los controles
            //CerrarSessionAccess.SetAccess(patentesUsuario);

        }
    }
}
