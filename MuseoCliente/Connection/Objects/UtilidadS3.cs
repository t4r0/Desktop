using System;
using Amazon.S3;
using Amazon.S3.Transfer;
using System.Collections;
using System.Collections.Generic;

namespace MuseoCliente.Connection.Objects
{
    public static class Extensions
    {
        /// <summary>
        /// Convert ArrayList to List.
        /// </summary>
        public static List<T> ToList<T>(this ArrayList arrayList)
        {
            List<T> list = new List<T>(arrayList.Count);
            foreach (T instance in arrayList)
            {
                list.Add(instance);
            }
            return list;
        }
    }
    public class UtilidadS3
    {
        private static string accessKey = Environment.GetEnvironmentVariable( "AWS_ACCESS_KEY_ID", EnvironmentVariableTarget.Machine );
        private static string secretKey = Environment.GetEnvironmentVariable( "AWS_SECRET_ACCESS_KEY", EnvironmentVariableTarget.Machine );
        private static string BUCKET_NAME = "bicefalo-api";
        private string url = "http://s3-us-west-2.amazonaws.com/" + BUCKET_NAME;
        private void uploadFile( string KEY_NAME, string rutaArchivo )
        {
            TransferUtility fileTransferUtility = new TransferUtility( new AmazonS3Client( accessKey, secretKey, Amazon.RegionEndpoint.USWest2 ) );
            TransferUtilityUploadRequest fileTransferUtilityRequest = new TransferUtilityUploadRequest
            {
                BucketName = BUCKET_NAME,
                FilePath = rutaArchivo,
                Key = KEY_NAME
            };
            fileTransferUtility.Upload( fileTransferUtilityRequest );
        }
        public String subirFotoUsuario( string username, string rutaArchivo, string nombreArchivo )
        {
            string KEY_NAME = "media/users/" + username + "/" + nombreArchivo;
            try
            {
                url += "/" + KEY_NAME;
                this.uploadFile( KEY_NAME, rutaArchivo );
            }
            catch
            {
                url = "";
            }
            return url;
        }
        public String subirArchivoPieza( string codigoPieza, string rutaArchivo, string nombreArchivo, Boolean esImagen )
        {
            string KEY_NAME = "media/piezas/" + codigoPieza;
            if( esImagen )
            {
                KEY_NAME += "/imagenes/" + nombreArchivo;
            }
            else
            {
                KEY_NAME += "/archivos/" + nombreArchivo;
            }
            url += "/" + KEY_NAME;
            try
            {
                this.uploadFile( KEY_NAME, rutaArchivo );
            }
            catch
            {
                url = "";
            }
            return url;
        }
        public String subirSalaoEvento( string id, string rutaArchivo, string nombreArchivo, Boolean esSala )
        {
            string KEY_NAME = "";
            if( esSala )
            {
                KEY_NAME += "media/salas/" + id + "-" + nombreArchivo;
            }
            else
            {
                KEY_NAME += "media/eventos/" + id + "-" + nombreArchivo;
            }
            url += "/" + KEY_NAME;
            try
            {
                this.uploadFile( KEY_NAME, rutaArchivo );
            }
            catch
            {
                url = "";
            }

            return url;
        }
        public String subirImagenFicha(string nombre, string rutaArchivo)
        {
            string KEY_NAME = "";
            KEY_NAME += "media/fichas/" + nombre;
            url += "/" + KEY_NAME;
            try
            {
                this.uploadFile(KEY_NAME, rutaArchivo);
            }
            catch
            {
                url = "";
            }
            return url;
        }

    }
}
