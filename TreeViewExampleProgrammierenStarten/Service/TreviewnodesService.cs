using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TreeViewExampleProgrammierenStarten.Model;

namespace TreeViewExampleProgrammierenStarten.Service
{
    public class TreviewnodesService
    {
             
        public IEnumerable<TreviewModel> GetDirectoryall(string path,List<TreviewModel> models)
        {
            
            loadfolder(path, models);

            return models;

        }


        // Rekursive Liste Holen mit Parent Ordner 
        private void loadfolder(string path, List<TreviewModel> models)
        {
            DirectoryInfo strings = new DirectoryInfo(path);
            var directories = strings.GetDirectories();
           for (int i = 0; i < directories.Count(); i++)
            {
                foreach (var model in directories)
                {
                    
                    models.Add(new TreviewModel()
                    {
                        Name = model.Name,
                        Parent = model.Parent.Name,
                        ImagePath = @"\Image\folder_kl.png"
                    });
                    foreach (var files in model.EnumerateFiles())
                    {
                        models.Add(new TreviewModel()
                        {
                            Name = files.Name,
                            Parent = model.Name,
                            ImagePath = @"\Image\diskette.png"
                        });
                    }
                }

                loadfolder(directories[i].FullName, models);

            }
            
          
            
            

        }

        

    }
}
