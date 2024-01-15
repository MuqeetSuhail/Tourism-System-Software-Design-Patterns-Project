using System;

namespace Tourism_System__Sda_Project_
{
    public class PlatinumPackage : I_TourPackage
    {
        private static int totalPlatinumPackagesSold = 0;
        private static int totalPlatinumRevenue = 0;
        private static int latestPlatinumRevenue = 0;
        private static int oldPlatinumRevenue = 0;

        private string pLocation = "any";
        private int NoofBeds = 04;
        private string FoodIncluded = "Yes";
        private int price = 15000;
        public PlatinumPackage()
        {

        }
        public PlatinumPackage(string tempLoc)
        {
            pLocation = tempLoc;
        }

        public void DisplayPackageDetails()
        {
            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║  Platinum Package: Premium travel experience   ║");
            Console.WriteLine("╚════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("       Travel Destination: " + pLocation);
            Console.WriteLine("       Beds Included: " + NoofBeds);
            Console.WriteLine("       Food Included: " + FoodIncluded);
            Console.WriteLine("       Price of Package: " + price);
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine();
        }
        public void setLocation(string tempLoc)
        {
            pLocation = tempLoc;
        }
        public int getPrice()
        {
            return price;
        }
        public int GetTotalPackagesSent()
        {
            return totalPlatinumPackagesSold;
        }
        public void getOldRev()
        {
            Console.WriteLine("Old Revenue of Platinum Package is: " + oldPlatinumRevenue);
        }

        public void getNewRev()
        {
            Console.WriteLine("New Revenue of Platinum Package is: " + latestPlatinumRevenue);
        }

        public int CalculateOverallRevenue(int platinumPackagesSold)
        {
            oldPlatinumRevenue = totalPlatinumRevenue;
            totalPlatinumPackagesSold += platinumPackagesSold;
            latestPlatinumRevenue = platinumPackagesSold * price;
            totalPlatinumRevenue += latestPlatinumRevenue;
            return totalPlatinumRevenue;
        }
    }
}
