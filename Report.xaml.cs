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
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        public Report(ObservableCollection<KIT206_GroupWork.Researcher.Staff> list)
        {
            InitializeComponent();
            ReportList.ItemsSource = list;
        }

        private void CopyEmail_Click(object sender, RoutedEventArgs e)
        {
            if (ReportList.SelectedItem == null)
            {
                MessageBox.Show("Please select a researcher");
            }
            else
            {
                Clipboard.SetText(((KIT206_GroupWork.Researcher.Staff)ReportList.SelectedItem).Email);
            }


            //MessageBox.Show(""+ ReportList.SelectedItem);

        }
    }
}
