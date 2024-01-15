using System;

namespace Tourism_System__Sda_Project_
{
    public class HoneymoonPackage : I_TourPackage
    {
        private static int totalHoneymoonPackagesSold = 0;
        private static int totalHoneymoonRevenue = 0;
        private static int latestHoneymoonRevenue = 0;
        private static int oldHoneymoonRevenue = 0;

        private string hLocation = "any";
        private int NoofBeds = 01;
        private string FoodIncluded = "Yes";
        private int price = 17000;
        public HoneymoonPackage()
        {

        }
        public HoneymoonPackage(string tempLoc)
        {
            hLocation = tempLoc;
        }
        public void setLocation(string tempLoc)
        {
            hLocation = tempLoc;
        }
        public int getPrice()
        {
            return price;
        }
        public void DisplayPackageDetails()
        {
            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║ Honeymoon Package: Romantic travel experience  ║");
            Console.WriteLine("╚════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("       Travel Destination: " + hLocation);
            Console.WriteLine("       Beds Included: " + NoofBeds);
            Console.WriteLine("       Food Included: " + FoodIncluded);
            Console.WriteLine("       Price of Package: " + price);
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine();
        }
        public int GetTotalPackagesSent()
        {
            return totalHoneymoonPackagesSold;
        }
        public void getOldRev()
        {
            Console.WriteLine("Old Revenue of Honeymoon Package is: " + oldHoneymoonRevenue);
        }

        public void getNewRev()
        {
            Console.WriteLine("New Revenue of Honeymoon Package is: " + latestHoneymoonRevenue);
        }

        public int CalculateOverallRevenue(int honeymoonPackagesSold)
        {
            oldHoneymoonRevenue = totalHoneymoonRevenue;
            totalHoneymoonPackagesSold += honeymoonPackagesSold;
            latestHoneymoonRevenue = honeymoonPackagesSold * price;
            totalHoneymoonRevenue += latestHoneymoonRevenue;
            return totalHoneymoonRevenue;
        }
    }
}
