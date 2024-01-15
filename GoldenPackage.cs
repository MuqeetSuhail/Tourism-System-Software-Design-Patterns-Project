using System;

namespace Tourism_System__Sda_Project_
{
    public class GoldenPackage : I_TourPackage
    {
        private static int totalGoldPackagesSold = 0;
        private static int totalgRevenue = 0;
        private static int latestgRevenue = 0;
        private static int oldgRevenue = 0;
        private string gLocation = "any";
        private int NoofBeds = 2;
        private string FoodIncluded = "No";
        private int price = 10000;

        public GoldenPackage()
        {
        }
        public GoldenPackage(string tempLoc)
        {
            gLocation = tempLoc;
        }
        public void setLocation(string tempLoc)
        {
            gLocation = tempLoc;
        }
        public int getPrice()
        {
            return price;
        }
        public void DisplayPackageDetails()
        {
            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║     Gold Package: Luxury travel experience     ║");
            Console.WriteLine("╚════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("       Travel Destination: " + gLocation);
            Console.WriteLine("       Beds Included: " + NoofBeds);
            Console.WriteLine("       Food Included: " + FoodIncluded);
            Console.WriteLine("       Price of Package: " + price);
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine();
        }
        public void getOldRev()
        {
            Console.WriteLine("Old Revenue of Gold Package is: " + oldgRevenue);
        }
        public void getNewRev()
        {
            Console.WriteLine("New Revenue of Gold Package is: " + latestgRevenue);
        }
        public int GetTotalPackagesSent()
        {
            return totalGoldPackagesSold;
        }
        public int CalculateOverallRevenue(int goldPackagesSold)
        {
            oldgRevenue = totalgRevenue;
            totalGoldPackagesSold += goldPackagesSold;
            latestgRevenue = goldPackagesSold * price;
            totalgRevenue += latestgRevenue;
            return totalgRevenue;
        }

    }
}
