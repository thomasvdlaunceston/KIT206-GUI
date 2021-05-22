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
        KIT206_GroupWork.Control.ResearcherController R_Controller;
        KIT206_GroupWork.Control.PublicationsController P_Controller;
        public MainWindow()
        {
            InitializeComponent();

            R_Controller = new KIT206_GroupWork.Control.ResearcherController();
            P_Controller = new KIT206_GroupWork.Control.PublicationsController();
            R_Controller.LoadReseachers();
            ResearcherList.ItemsSource = R_Controller.GetViewableList();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            R_Controller.LoadResearcherDetails(((KIT206_GroupWork.Researcher.Researcher)e.AddedItems[0]).ID);
            P_Controller.loadPublications((KIT206_GroupWork.Researcher.Researcher)e.AddedItems[0]);
            if (R_Controller.isStaff)
            {
                P_Controller.loadPublications(R_Controller.staff);
                R_Controller.staff.calculateThreeYearAverage(P_Controller);
                R_Controller.staff.Performance(P_Controller);
                DetailsPanel.DataContext = R_Controller.staff;
                //ResearcherList.ItemsSource = P_Controller.
                //List_of_Publications.DataContext = P_Controller.displayList;
                ListOfPublications.ItemsSource = P_Controller.getPublicationList();

            }
            else
            {
                DetailsPanel.DataContext = R_Controller.student;
                P_Controller.loadPublications(R_Controller.student);
                ListOfPublications.ItemsSource = P_Controller.getPublicationList();
            }
            PublicationCount.DataContext = P_Controller;


            //MessageBox.Show("" + e.AddedItems[0]);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListOfPublications_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void List_of_Publications_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
