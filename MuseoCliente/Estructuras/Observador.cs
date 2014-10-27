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
        private Nodo actual; //Me indica el UserControl Actual

        public Observador(UserControl primero)
        {
            Nodo nuevo = new Nodo(primero);
            actual.setProximo(nuevo);
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
        }

        public void anterior()
        {
            Nodo temp = this.getActual().getAnterior();
            temp.setProximo(null);
            actual.setProximo(temp);
        }

        public UserControl ventanaActual()
        {
            return this.getActual().getVentana();
        }

    }
}
