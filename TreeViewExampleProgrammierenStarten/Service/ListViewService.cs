using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewExampleProgrammierenStarten.Model;

namespace TreeViewExampleProgrammierenStarten.Service
{
    public class ListViewService
    {
        public IEnumerable<ListViewModel> GetList(string path)
        {
            DirectoryInfo info = new DirectoryInfo(path);
           List<ListViewModel> list = new List<ListViewModel>();

            foreach(var files in info.EnumerateFiles())
            {
                list.Add(new ListViewModel()
                {
                    Name = files.Name,
                    CreateTime = files.CreationTime.ToString(),
                    LastModified = files.LastWriteTime.ToString(),
                    Length = files.Length.ToString()+" bytes",
                });
            }
            return list;
        }

    }
}
