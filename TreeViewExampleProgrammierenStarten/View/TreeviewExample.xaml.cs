using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TreeViewExampleProgrammierenStarten.Service;

namespace TreeViewExampleProgrammierenStarten.View
{
    /// <summary>
    /// Interaktionslogik für TreeviewExample.xaml
    /// </summary>
    public partial class TreeviewExample : Window
    {
        public TreeviewExample()
        {
            InitializeComponent();
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            TreviewnodesService treviewnodesService = new TreviewnodesService();
            
           
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
