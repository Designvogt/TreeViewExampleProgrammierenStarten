using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;
using TreeViewExampleProgrammierenStarten.Model;
using TreeViewExampleProgrammierenStarten.Service;

namespace TreeViewExampleProgrammierenStarten.ViewModel
{
    public class TreeviewExampleViewModel : ViewModelBase
    {

        TreviewnodesService service = new TreviewnodesService();
        public ObservableCollection<TreenodeViewModel> RootNodes { get; set; } = new ObservableCollection<TreenodeViewModel>();

        private ObservableCollection<ListViewModel> fileList = new ObservableCollection<ListViewModel>();
        public ObservableCollection<ListViewModel> FileList
        {
            get => fileList;
            set
            {
                if (fileList != value)
                {
                    fileList = value;
                    this.OnProbertyChanged(nameof(FileList));
                }
            }
        }






        public TreeviewExampleViewModel() 
        {
            TreenodeViewModel.TreeViewSelect += TreenodeViewModel_TreeViewSelect;
            
            LoadData();
        }

        private void TreenodeViewModel_TreeViewSelect(object sender, EventArgs e)

        {
            FileList.Clear();
            ListViewService listservice = new ListViewService();
           var treeview = sender as TreenodeViewModel;
            var list = listservice.GetList(treeview.Path);

         

            foreach (var items in list)
            {
                var item = new ListViewModel { Name = items.Name, CreateTime = items.CreateTime, LastModified = items.LastModified, Length = items.Length };
                FileList.Add(item);
            }
        }

        public async void LoadData()
        {
            string path = @"D:\SPSProjekte";
            List<TreviewModel> models = new List<TreviewModel>();
            

          var nodesRoot = service.GetDirectoryall(path, models);
            
            var rootNode = new TreenodeViewModel {Name = nodesRoot.First().Parent,ImagePath = nodesRoot.First().ImagePath , Path = nodesRoot.First().Path};

            await Task.Run(() => ChildNodesLoad(rootNode.Name, rootNode, nodesRoot));
             this.RootNodes.Add(rootNode);




        }

        private void ChildNodesLoad(string parent, TreenodeViewModel rootNode, IEnumerable<TreviewModel> childNodes)
        {


            foreach (var item in childNodes.Where(x => x.Parent == parent))
            {

                var childNode = new TreenodeViewModel { Name = item.Name, Parent = item.Parent,ImagePath = item.ImagePath ,Path = item.Path};


                rootNode.Parentnode.Add(childNode);
                ChildNodesLoad(item.Name, childNode, childNodes);
            }
        }
    
       




    }
}
