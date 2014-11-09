using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MuseoCliente.Connection;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MuseoCliente
{
    /// <summary>
    /// Lógica de interacción para WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : UserControl
    {
        public WelcomePage()
        {
            InitializeComponent();
        }


        private async void Grid_Loaded_2(object sender, RoutedEventArgs e)
        {
            Connector conector = new Connector("/api/v1/resumen/");
            Task<string> t = Task<string>.Factory.StartNew(() => conector.fetch());
            await t;
            string content = t.Result;
            Dictionary<string, Dictionary<string, int>> dict = (Dictionary<string, Dictionary<string, int>>)JsonConvert.DeserializeObject(content, typeof(Dictionary<string, Dictionary<string, int>>));
            lblUsers.Content = dict["usuarios"]["registrados"] + " registrados";
            lblVoluntarios.Content = dict["usuarios"]["voluntarios"] + " voluntarios";
            lblPiezas.Content = dict["piezas"]["piezas"] + " piezas";
            lblColecciones.Content = dict["piezas"]["colecciones"] + " colecciones";
            lblClasificaciones.Content = dict["piezas"]["clasificaciones"] + " clasificaciones";
            lblCategorias.Content = dict["piezas"]["categorias"] + " categorias";
            lblEventos.Content = dict["eventos"]["futuros"] + " eventos proximos";
            lblHoy.Content = dict["eventos"]["hoy"] + " hoy";
            lblPasados.Content = dict["eventos"]["pasados"] + " eventos pasados";
            lblInvestigaciones.Content = dict["investigaciones"]["investigaciones"] + " investigaciones";
            lblPublicadas.Content = dict["investigaciones"]["publicadas"] + " investigaciones publicadas";
            lblBorradores.Content = dict["investigaciones"]["borradores"] + " sin publicar";
        }
    }
}
