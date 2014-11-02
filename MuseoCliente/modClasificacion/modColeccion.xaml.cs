﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MuseoCliente
{
	/// <summary>
	/// Lógica de interacción para modColeccion.xaml
	/// </summary>
	public partial class modColeccion : UserControl
	{
        Connection.Objects.Coleccion colec = new Connection.Objects.Coleccion();
        public UserControl anterior;
        public Border borde;
        public bool modificar = false;
        public int id;
        public modColeccion()
		{
			this.InitializeComponent();
		}

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            colec.nombre = txtNombre.Text;
            if (modificar == false)
            {
                colec.guardar();
            }
            else
            {
                colec.modificar();
            }
            if (Connection.Objects.Error.isActivo())
            {
                MessageBox.Show(Connection.Objects.Error.nombreError, Connection.Objects.Error.descripcionError);
            }
            else
            {
                MessageBox.Show("Correcto");
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            borde.Child = anterior;
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            //Cargar datos
            //Si es para modificar
            if (modificar == true)
            {
                lblOperacion.Content = "Nueva Colección";
                txtNombre.Text = "Pendiente";
            }
            else
            {
                lblOperacion.Content = "Nueva Colección";
            }
        }
	}
}