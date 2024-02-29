using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeViewExampleProgrammierenStarten.Model;
using TreeViewExampleProgrammierenStarten.Service;

namespace TreeViewExampleProgrammierenStarten.ViewModel
{
    public class TreeviewExampleViewModel : ViewModelBase
    {

        TreviewnodesService service = new TreviewnodesService();
        public ObservableCollection<TreenodeViewModel> RootNodes { get; set; } = new ObservableCollection<TreenodeViewModel>();

        public TreeviewExampleViewModel() 
        { 
        
         LoadData();
        }
        public void LoadData()
        {
            string path = @"D:\6-IH\01-Public\vcServerfolder\VersionsCatcher\Rohbau 1\G1X\G1XAS\SPS\G1XAS";
            List<TreviewModel> models = new List<TreviewModel>();
            

          var nodesRoot = service.GetDirectoryall(path, models);
            
            var rootNode = new TreenodeViewModel {Name = nodesRoot.First().Parent,ImagePath = nodesRoot.First().ImagePath };

            ChildNodesLoad(rootNode.Name, rootNode, nodesRoot);
             this.RootNodes.Add(rootNode);




        }

        private void ChildNodesLoad(string parent, TreenodeViewModel rootNode, IEnumerable<TreviewModel> childNodes)
        {


            foreach (var item in childNodes.Where(x => x.Parent == parent))
            {

                var childNode = new TreenodeViewModel { Name = item.Name, Parent = item.Parent,ImagePath = item.ImagePath };


                rootNode.Parentnode.Add(childNode);
                ChildNodesLoad(item.Name, childNode, childNodes);
            }
        }
    





    }
}
