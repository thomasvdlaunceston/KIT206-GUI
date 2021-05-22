using KIT206_GroupWork.Researcher;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KIT206_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KIT206_GroupWork.Control.ResearcherController R_Controller = new KIT206_GroupWork.Control.ResearcherController();
        public MainWindow()
        {
            InitializeComponent();
            filterComboBox.ItemsSource = Enum.GetValues(typeof(EmploymentLevel));
            R_Controller.LoadReseachers();
            ResearcherList.ItemsSource = R_Controller.GetViewableList();//gets list of researchers

            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //EmploymentLevel x=EmploymentLevel.A;

            // EmploymentLevel.;

            //switch(filterComboBox.SelectedItem){
            //    case filterComboBox(EmploymentLevel.A): 
            //        x = EmploymentLevel.A;
            //        break;
            //    case filterComboBox.SelectedItem.Equals(EmploymentLevel.B):
            //        x = EmploymentLevel.B;
            //        break;
            //}

            if (filterComboBox.SelectedItem.Equals(EmploymentLevel.A))
            {
                R_Controller.FilterBy(EmploymentLevel.A);
                return;
            }
            else if(filterComboBox.SelectedItem.Equals(EmploymentLevel.B)){
                R_Controller.FilterBy(EmploymentLevel.B);
                return;

            }
            else if (filterComboBox.SelectedItem.Equals(EmploymentLevel.C))
            {
                R_Controller.FilterBy(EmploymentLevel.C);
                return;
            }
            else if (filterComboBox.SelectedItem.Equals(EmploymentLevel.D))
            {
                R_Controller.FilterBy(EmploymentLevel.D);
                return;
            }
            else if (filterComboBox.SelectedItem.Equals(EmploymentLevel.E))
            {
                R_Controller.FilterBy(EmploymentLevel.E);
                return;
            }
            else if (filterComboBox.SelectedItem.Equals(EmploymentLevel.Student))
            {
                R_Controller.FilterBy(EmploymentLevel.Student);
                return;

            }
            else
            {
                R_Controller.reset();
            }

        }


        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchBox.Text!= ("")) {
            R_Controller.FilterByName(SearchBox.Text);
                return;
            }
            else {
                R_Controller.reset();
            }

        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            


        }
    }
}
