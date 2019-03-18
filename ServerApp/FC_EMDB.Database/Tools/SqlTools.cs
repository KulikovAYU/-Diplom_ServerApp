using System;
using System.Diagnostics;
using System.IO;

namespace FC_EMDB.Database.Tools
{
    public static class SqlTools
    {
        /// <summary>
        /// Метод конвертирует изображение в массив битов для последующего сохранения его в базе данных
        /// </summary>
        /// <returns>byte[]</returns>
        public static byte[] ConvertImageToByteArray(string fileName,string humanFileName, string additionalPath = "\\InitializeData\\EmployeePhoto\\")
        {
            if (string.IsNullOrEmpty(fileName))
                return null;

            string strDirectory = fileName + additionalPath;
            fileName += additionalPath + humanFileName;

            DirectoryInfo dir = new DirectoryInfo(strDirectory);

            if (!dir.Exists)
            {
                return null;
            }
            byte[] byteRes = null;
            try
            {
                byteRes = File.ReadAllBytes(Path.GetFullPath(fileName));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                //throw;
            }

            return byteRes;
        }

        public static string GetPath()
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //Для выделения пути к каталогу, воспользуйтесь `System.IO.Path`:
            var path = Path.GetDirectoryName(location);

            return path;
        }
    }
}
