using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Revisione
{
    class Controller
    {
        public static List<FileInfo> getFolderFile(string path)
        {
            List<FileInfo> fileInfoList = new List<FileInfo>();

            string[] allfiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            foreach (string f in allfiles)
            {
                FileInfo info = new FileInfo(f);

                fileInfoList.Add(info);
            }

            return fileInfoList;
        }

        public static List<FileInfo> trovoRevisioniRecenti(List<FileInfo> listaOld, List<FileInfo> listaNew)
        {
            List<FileInfo> results = new List<FileInfo>();

            List<string> listaOldName = (List<string>)listaOld.Select(x => x.Name);

            foreach (FileInfo f in listaNew) 
            {
                string nameNew = f.Name;

                if (listaOldName.Contains(nameNew))
                {
                    Console.WriteLine(nameNew);
                }
            }

            return results;
        }
    }
}
