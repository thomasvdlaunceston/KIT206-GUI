using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace KIT206_GUI
{
    /// <summary>
    /// Interaction logic for Supervisions.xaml
    /// </summary>
    public partial class Supervisions : Window
    {
        public Supervisions(ObservableCollection<KIT206_GroupWork.Researcher.Student> sup)
        {
            InitializeComponent();
            SupervisionNames.ItemsSource = sup;
        }
    }
}
