using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism_System__Sda_Project_
{
    internal class Administrator_singelton
    {
        private string name;
        private string Gender;
        private string userType = "Admin";
        private string username = "administrator";
        private string userPassword = "admin123";
        static int TotalOverallRevenue = 0;
        static int TotalTrips = 0;
        private Administrator_singelton()
        {
        }
        
        public bool CheckCredentials(string tempaname, string tempapass)
        {
            if (tempaname == username && tempapass == userPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string getName()
        {
            return name;
        }
        private Administrator_singelton(string tempname, string tempGender)
        {
            name = tempname;
            Gender = tempGender;
        }
        private static Administrator_singelton Admin = null;
        private static int objectCount = 0;
        public static Administrator_singelton getObjectInstance()
        {
            string A_name=null;
            string A_gender=null;
            if (Admin == null)
            {
                Console.WriteLine("Seems Like You Are A New Recruit..!");
                Console.Write("What is your name Admin: ");
                A_name = Console.ReadLine();

                Console.Write("What is your gender Admin: ");
                A_gender = Console.ReadLine();
                Admin = new Administrator_singelton(A_name, A_gender);
                objectCount++;
            }
            else
            {
                Console.WriteLine("Unable to create the 2nd object of singleton class");
            }
            return Admin;
        }
        public int calculateTotalRevenue(int Gcount, int Pcount, int Hcount, GoldenPackage temp_Package1, PlatinumPackage temp_Package2, HoneymoonPackage temp_Package3)
        {
            // Dependency Injection Implementation
            TourManager manager;
            manager = new TourManager(temp_Package1);
            int revpackage1 = manager.CalculateTourRevenue(Gcount);
            manager = new TourManager(temp_Package2);
            int revpackage2 = manager.CalculateTourRevenue(Pcount);
            manager = new TourManager(temp_Package3);
            int revpackage3 = manager.CalculateTourRevenue(Hcount);
            TotalOverallRevenue = revpackage1 + revpackage2 + revpackage3;
            return TotalOverallRevenue;
        }
        public void DisplayRevenueofIndividualPackages(GoldenPackage tempPackage_1, PlatinumPackage tempPackage_2, HoneymoonPackage tempPackage_3)
        {
            // Dependency Injection Implementation
            TourManager manager;
            manager = new TourManager(tempPackage_1);
            manager.DisplayPackageRevIndividual();
            manager = new TourManager(tempPackage_2);
            manager.DisplayPackageRevIndividual();
            manager = new TourManager(tempPackage_3);
            manager.DisplayPackageRevIndividual();
        }
        public int calculateTotalTrips(GoldenPackage temp_Package1, PlatinumPackage temp_Package2, HoneymoonPackage temp_Package3)
        {
            // Dependency Injection Implementation
            TourManager manager;
            manager = new TourManager(temp_Package1);
            int TripCount1 = manager.CalculateTripsCount();
            manager = new TourManager(temp_Package2);
            int TripCount2 = manager.CalculateTripsCount();
            manager = new TourManager(temp_Package3);
            int TripCount3 = manager.CalculateTripsCount();
            TotalTrips = TripCount1 + TripCount2 + TripCount3;
            return TotalTrips;
        }
        public void generateMonthlyReport(int G_count, int P_count, int H_count, GoldenPackage tempPackage1, PlatinumPackage tempPackage2, HoneymoonPackage tempPackage3)
        {
            double Revenue = calculateTotalRevenue(G_count, P_count, H_count, tempPackage1, tempPackage2, tempPackage3);
            int TotalTripsSent = calculateTotalTrips(tempPackage1, tempPackage2, tempPackage3);
            Console.WriteLine("--------- Monthly Report ---------");
            Console.WriteLine("TotalRevenueGenerated: " + Revenue);
            Console.WriteLine("TotalTripsSent: " + TotalTripsSent);
            Console.WriteLine("--------- Revenue Comparison Stats ---------");
            DisplayRevenueofIndividualPackages(tempPackage1, tempPackage2, tempPackage3);
            Console.WriteLine();
        }

    }
}
