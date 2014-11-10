using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;

/*
No Modificar esta Clase.
Cualquier duda comunicarse Con Victor Betancohurt 56912907

INSTRUCCIONES.

Todas las funciones son staticas para no declararlas.
Solo se ingresa el Error con el numero identificador y la descripcion de Error.
	La descripcion de Error es regresada por la Clase de Taro para manejar mejor los Errores.
Cada Error tendra un Texto. Que sera ingresado por la funcion ingresarError
Que estara de la siguiente Manera.
________________________________
|numero|	NombreError  		|
|-------------------------------|
|  1   |	numero Incorrecto	|
|  2   |	id No encontrado	|
|  3   |	No se Guarda		|
|  4   |	No modificacion		|
|  5   |	Error en Coneccion	|

IMPORTANTE MATUL
isActivo() es True si existe Error, de lo contrario regresa un False, Ademas Cuando regresa el True. 
	Automaticamente vuelve a poner el activo en False, tomar en cuenta esta situacion.



*/
namespace MuseoCliente.Connection.Objects
{
    class  Error
    {
    	public static string nombreError { get{return nombre;} }
        public static string descripcionError { get{return descripcion;} }
        private static bool activo=false;
		private static string nombre="";
		private static string descripcion="";
		

        public static void ingresarError(int numero, string error)
        {
            descripcion = error;
            activo = true;
			switch(numero)
			{
				case 1:
					nombre ="Numero Incorrecto";
					break;	
				case 2:
					nombre ="No existe Objeto";
					break;	
				case 3:
					nombre ="Error Guardar";
					break;

                case 4:
                    nombre = "Modificacion Incorrecta";
                    break;

                case 5:
                    nombre = "Error Coneccion";
                    break;
				
				default:
					nombre = "Error";
					descripcion ="Ha ocurrido un error";
				break;
			}
        }
		
		 public static void ingresarError( string nombreError,string error)
        {
            nombre = nombreError;
            descripcion = error;
            activo = true;
            
        }

         public static void ingresarError(string eMessage)
         {
             if (eMessage.Contains("Conexion"))
                 ingresarError("Error de Conexion", "No se puede establecer contacto con el servidor ");
             else if (eMessage.Contains("User")&& eMessage.Contains("does not exist"))
                 ingresarError("Error en Usuario", "No se ha asignado un usuario, autor existente en la base de datos ");
             else if (eMessage.Contains("AutoField") && eMessage.Contains("does not accept 0"))
                 ingresarError("Error Asignacion", "No existe el objeto asignado para la relacion");
             else
                 ingresarError("Error", "hay uno o varios errores "+eMessage);

         }

        public static bool isActivo()
        {
            bool variable = activo;
            activo = false;
            return variable;
        }
		
	}
}
