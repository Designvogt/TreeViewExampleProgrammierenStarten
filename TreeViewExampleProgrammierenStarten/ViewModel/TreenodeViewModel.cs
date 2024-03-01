using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewExampleProgrammierenStarten.ViewModel
{
    public class TreenodeViewModel : ViewModelBase
    {

        public string Name { get; set; }
        public string Parent { get; set; }
        public string Path { get; set; }

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

        private static object _selectedItem = null;

        public static object SelectedItem
        {
            get { return _selectedItem; }
            private set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
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
                    if (isSelected)
                    {

                        SelectedItem = this;
                        OnSelectedItemChanged();

                    }
                    this.isSelected = value;
                    OnProbertyChanged("IsSelected");
                }
            }
        }

        public static event EventHandler TreeViewSelect;
        private static void OnSelectedItemChanged()
        {
            var item = SelectedItem as TreenodeViewModel;

           TreeViewSelect?.Invoke(item, EventArgs.Empty);

        }

    }
}
