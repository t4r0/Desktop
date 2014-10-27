using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MuseoCliente.Estructuras
{
    class Observador
    {
        private Nodo actual = new Nodo(); //Me indica el UserControl Actual
        private Border borde = new Border();

        public Observador(UserControl primero, Border bdr)
        {
            Nodo nuevo = new Nodo(primero);
            actual.setProximo(nuevo);
            borde = bdr;
        }

        public Nodo getActual()
        {
            return actual.getProximo();
        }
        
        public void agregar(UserControl ventana)
        {
            Nodo nuevo = new Nodo(ventana);
            this.getActual().setProximo(nuevo);
            nuevo.setAnterior(this.getActual());
            actual.setProximo(nuevo);
            this.ventanaActual();
        }

        public void anterior()
        {
            Nodo temp = this.getActual().getAnterior();
            temp.setProximo(null);
            actual.setProximo(temp);
            this.ventanaActual();
        }

        public void ventanaActual()
        {
            borde.Child = this.getActual().getVentana();
        }

    }
}
