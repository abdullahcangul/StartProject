using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace StartProject.Api.util
{
    public class ImageHelper
    {

        // internal const string TempFolder = "~/Temp";
        internal const string FileFolder = "~/Files";

        public string add(string fileName, byte[] file, string origin)
        {
            string extension = Path.GetExtension(fileName);

            if (!(extension == ".jpg" || extension == ".png"))
            {
                return "uzanti";
            }

            if (file.Length > 100000000)
            {
                return "boyut";
            }

            string FileName = Guid.NewGuid() + extension;
            var fileFolderPath = System.Web.Hosting.HostingEnvironment.MapPath(FileFolder);
            var fileFullPath = Path.Combine(fileFolderPath, FileName);
            File.WriteAllBytes(fileFullPath, file);
            string dowloadLink = origin + FileFolder.TrimStart('~') + "/" + FileName;

            return dowloadLink;
        }

        public string delete(string fileName)
        {
            string yol = HttpContext.Current.Server.MapPath(FileFolder.TrimStart('~') + "/" + fileName);
            if (System.IO.File.Exists(yol))
            {
                System.IO.File.Delete(yol);
            }
            else
            {
                return "Bulunamadı";
            }
            return "Silindi";
        }
    }
}