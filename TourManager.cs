using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Tourism_System__Sda_Project_
{
    //// Dependency Injection Implementation
    internal class TourManager
    {
        private I_TourPackage Package;
        public TourManager(I_TourPackage tempPackage)
        {
            this.Package = tempPackage;
        }
        public void PrintaPackinfo()
        {
            Package.DisplayPackageDetails();
        }
        public void DisplayPackageRevIndividual()
        {
            Package.getNewRev();
            Package.getOldRev();
        }
        public int CalculateTripsCount()
        {
            int temppack = Package.GetTotalPackagesSent();
            return temppack;
        }
        public int CalculateTourRevenue(int tempsellcount)
        {
            int temprev=Package.CalculateOverallRevenue(tempsellcount);
            return temprev;
        }
    }
}
