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
using KIT206_GroupWork.Researcher;



namespace KIT206_GUI
{
    /// <summary>
    /// Interaction logic for PublicationDetails.xaml
    /// </summary>
    public partial class PublicationDetails : Window
    {

        KIT206_GroupWork.Control.PublicationsController P_Controller = new KIT206_GroupWork.Control.PublicationsController();

        public PublicationDetails()
        {
            InitializeComponent();

            P_Controller = new KIT206_GroupWork.Control.PublicationsController();

            // Pass parameter to loadPublicationDetails();

           // P_Controller.loadPublicationDetails();

            

        }
    }
}
