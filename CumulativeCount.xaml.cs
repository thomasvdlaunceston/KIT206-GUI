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
using System.Collections.ObjectModel;


namespace KIT206_GUI
{
    /// <summary>
    /// Interaction logic for CumulativeCount.xaml
    /// </summary>
    public partial class CumulativeCount : Window
    {
        public CumulativeCount(ObservableCollection<KIT206_GroupWork.Researcher.CumulativeCount> count)
        {
            InitializeComponent();
            CumulativeCountDGrid.ItemsSource = count;
        }
    }
}
