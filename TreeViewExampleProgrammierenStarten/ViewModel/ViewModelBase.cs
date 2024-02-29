using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewExampleProgrammierenStarten.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnProbertyChanged([CallerMemberName] string probertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(probertyName));
        }
    }
}
