using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewExampleProgrammierenStarten.ViewModel
{
    public class TreenodeViewModel : ViewModelBase
    {

        public string Name { get; set; }
        public string Parent { get; set; }

        public ObservableCollection<TreenodeViewModel> Parentnode { get; set; } = new ObservableCollection<TreenodeViewModel>();
        private string imagePath;
        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                if (imagePath != value)
                {
                    imagePath = value;
                    OnProbertyChanged(nameof(ImagePath));
                }
            }
        }
        private bool isSelected;
        public bool IsSelected
        {
            get { return this.isSelected; }
            set
            {
                if (value != this.isSelected)
                {
                    this.isSelected = value;
                    OnProbertyChanged("IsSelected");
                }
            }
        }



    }
}
