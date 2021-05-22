using KIT206_GroupWork.Researcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        //KIT206_GroupWork.Control.ResearcherController R_Controller;
        KIT206_GroupWork.Control.PublicationsController P_Controller = new KIT206_GroupWork.Control.PublicationsController();
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

            if (e.AddedItems.Count != 0)
            {
                R_Controller.LoadResearcherDetails(((KIT206_GroupWork.Researcher.Researcher)e.AddedItems[0]).ID);
                P_Controller.loadPublications((KIT206_GroupWork.Researcher.Researcher)e.AddedItems[0]);
                if (R_Controller.isStaff)
                {
                    P_Controller.loadPublications(R_Controller.staff);
                    R_Controller.staff.calculateThreeYearAverage(P_Controller);
                    R_Controller.staff.Performance(P_Controller);
                    DetailsPanel.DataContext = R_Controller.staff;

                    //https://stackoverflow.com/questions/18435829/showing-image-in-wpf-using-the-url-link-from-database
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(R_Controller.staff.Photo, UriKind.Absolute);
                    bitmap.EndInit();

                    ResearcherPicture.Source = bitmap;
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
            }
            else
            {
                DetailsPanel.DataContext = null;
                ListOfPublications.ItemsSource = null;
                PublicationCount.DataContext = null;
            }


            }
        

            private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                
                if (filterComboBox.SelectedItem.Equals(EmploymentLevel.A))
                {
                    R_Controller.FilterBy(EmploymentLevel.A);
                    return;
                }
                else if (filterComboBox.SelectedItem.Equals(EmploymentLevel.B)) {
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

            private void ListOfPublications_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {

            }

        /*private void ListOfPublications_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var currentRowIndex = ListOfPublications.Items.IndexOf(ListOfPublications.SelectedItem);

           

            PublicationDetails pdetails = new PublicationDetails();

            pdetails.ShowDialog();


        }*/

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            //https://stackoverflow.com/questions/22790181/wpf-datagrid-row-double-click-event-programmatically
            DataGridRow row = sender as DataGridRow;
            //MessageBox.Show("" + row.DataContext.GetType());

            PublicationDetails pdetails = new PublicationDetails(KIT206_GroupWork.Adapters.ERDAdapter.completePublicationDetails((Publication) row.DataContext));

            pdetails.ShowDialog();

            // Some operations with this row
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

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            
            filterComboBox.SelectedIndex = 6;
            R_Controller.reset();

        }

        private void FilterPublications_Click(object sender, RoutedEventArgs e)
        {
            Regex num = new Regex("^[0-9]+$");
            
            if (StartYear.Text != null && EndYear.Text != null && StartYear.Text.Length == 4 && EndYear.Text.Length == 4 && num.IsMatch(StartYear.Text) && num.IsMatch(EndYear.Text) && P_Controller.displayList!=null)
            {
                int startYear = int.Parse(StartYear.Text);
                int endYear = int.Parse(EndYear.Text);
                P_Controller.filterByYear(startYear, endYear);
            }
            else if (StartYear.Text == "" && EndYear.Text == "" && P_Controller.displayList!= null)
            {
                P_Controller.reset();
            }
            else
            {
                MessageBox.Show("Please enter two years properly formatted years, after selecting a researcher");
            }

           
        }
    }
    } 

