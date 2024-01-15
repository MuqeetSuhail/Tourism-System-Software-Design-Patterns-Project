using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism_System__Sda_Project_
{
    // Dependency Injection Implementation
    internal interface I_TourPackage
    {
        int GetTotalPackagesSent();
        void getOldRev();
        void getNewRev();
        void DisplayPackageDetails();
        int CalculateOverallRevenue(int goldPackagesSold);
    }
}
