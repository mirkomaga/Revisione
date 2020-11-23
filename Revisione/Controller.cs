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

        public static List<FileInfo> getMostUpdated(List<FileInfo> list) 
        {
            IDictionary<string, List<FileInfo>> tmpDict = new Dictionary<string, List<FileInfo>>();

            foreach (FileInfo fi in list)
            {
                string name = fi.Name;

                if (!tmpDict.ContainsKey(name))
                {
                    tmpDict.Add(name, new List<FileInfo>());
                }

                tmpDict[name].Add(fi);
            }

            List<FileInfo> fileRecenti = new List<FileInfo>();

            foreach (var x in tmpDict)
            {
                if(x.Value.Count > 1)
                {
                    FileInfo fUpdated = x.Value.OrderBy(y => y.LastWriteTime).ToList().Last();
                    fileRecenti.Add(fUpdated);
                }
                else
                {
                    fileRecenti.Add(x.Value.First());
                }
            }

            return fileRecenti;
;
        }

        public static List<FileInfo> trovoRevisioniRecenti(List<FileInfo> listaOld, List<FileInfo> listaNew)
        {
            // ? PER OGNI FILE CON LO STESSO NOME PRENDERE IL PIU RECENTE
            listaNew = getMostUpdated(listaNew);
            listaOld = getMostUpdated(listaOld);

            List<FileInfo> results = new List<FileInfo>();

            //List<FileInfo> listaOldName = listaOld.OrderBy(x => x.LastWriteTime).GroupBy(x => x.Name);
            //listaOldName = (List<string>)listaOld.GroupBy(x => x.Name).ToList();
            //listaOldName = (List<string>)listaOld.Select(x => x.Name);

            //foreach (FileInfo f in listaNew) 
            //{
            //    string nameNew = f.Name;

            //    if (listaOldName.Contains(nameNew))
            //    {
            //        Console.WriteLine(nameNew);
            //    }
            //}

            return results;
        }
    }
}
