using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MuseoCliente.Estructuras
{
    class Nodo
    {
        private Nodo Anterior;
        private UserControl Ventana;
        private Nodo Proximo;

        public Nodo(UserControl Nuevo)
        {
            Ventana = Nuevo;
            Anterior = null;
            Proximo = null;
        }

        public Nodo() { }

        public void setAnterior(Nodo ant)
        {
            Anterior = ant;
        }

        public Nodo getAnterior()
        {
            return Anterior;
        }

        public void setProximo(Nodo prox)
        {
            Proximo = prox;
        }

        public Nodo getProximo()
        {
            return Proximo;
        }

        public UserControl getVentana()
        {
            return Ventana;
        }

    }
}
