using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Transfer;

namespace solucionAmazonS3
{
    public class UtilidadS3
    {
        private static string accessKey = "AKIAJCP7455PN6XSNLGA";
        private static string secretKey = "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";
        private static string BUCKET_NAME = "bicefalo";
        private string url = "http://s3-us-west-2.amazonaws.com/" + BUCKET_NAME;
        private void uploadFile(string KEY_NAME, string rutaArchivo)
        {
            TransferUtility fileTransferUtility = new TransferUtility(new AmazonS3Client(accessKey, secretKey, Amazon.RegionEndpoint.USWest2));
            TransferUtilityUploadRequest fileTransferUtilityRequest = new TransferUtilityUploadRequest
            {
                BucketName = BUCKET_NAME,
                FilePath = rutaArchivo,
                Key = KEY_NAME,
                CannedACL = S3CannedACL.PublicRead
            };
            fileTransferUtility.Upload(fileTransferUtilityRequest);
        }
        public String subirFotoUsuario(string username, string rutaArchivo, string nombreArchivo)
        {
            string KEY_NAME = "media/users/" + username + "/" + nombreArchivo;
            try
            {
                url += "/" + KEY_NAME;
                this.uploadFile(KEY_NAME, rutaArchivo);
            }
            catch
            {
                url = "";
            }
            return url;
        }
        public String subirArchivoPieza(string codigoPieza, string rutaArchivo, string nombreArchivo, Boolean esImagen)
        {
            string KEY_NAME = "media/piezas/" + codigoPieza;
            if (esImagen)
            {
                KEY_NAME += "/imagenes/" + nombreArchivo;
            }
            else
            {
                KEY_NAME += "/archivos/" + nombreArchivo;
            }
            url +=  "/" + KEY_NAME;
            this.uploadFile(KEY_NAME, rutaArchivo);
            return url;
        }
        public String subirSalaoEvento(int id, string rutaArchivo, string nombreArchivo, Boolean esSala)
        {
            string KEY_NAME = "";
            if (esSala)
            {
                KEY_NAME += "media/salas/" + id + "-" + nombreArchivo;
            }
            else
            {
                KEY_NAME += "media/eventos/" + id + "-" + nombreArchivo;
            }
            url += "/" + KEY_NAME;
            this.uploadFile(KEY_NAME, rutaArchivo);
            return url;
        }

    }
}
