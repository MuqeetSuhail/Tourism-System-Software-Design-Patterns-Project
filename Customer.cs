using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism_System__Sda_Project_
{
    internal class Customer
    {
        private string C_username = null;
        private string C_password = null;
        private string gender = null;
        private string name = null;
        private int balance = 40000;
        public Customer() { }

        public string GetName()
        {
            return name;
        }
        public void CreateAccount(string tempname, string tempgender, string tempusername, string temppass)
        {
            name = tempname;
            gender = tempgender;
            C_username = tempusername;
            C_password = temppass;
        }
        public int getBalance()
        {
            return balance;
        }
        public bool Transaction(int tempmoney)
        {
         
            if (balance >= tempmoney)
            {
                balance -= tempmoney;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckCredentials(string tempuname, string tempupass)
        {
            if (tempuname==C_username && tempupass==C_password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DisplayPackageList(GoldenPackage tempPackage_1, PlatinumPackage tempPackage_2, HoneymoonPackage tempPackage_3, string tempLoc)
        {
            // Dependency Injection Implementation
            TourManager manager;
            manager = new TourManager(tempPackage_1);
            manager.PrintaPackinfo();
            Console.WriteLine();
            manager = new TourManager(tempPackage_2);
            manager.PrintaPackinfo();
            Console.WriteLine();
            manager = new TourManager(tempPackage_3);
            manager.PrintaPackinfo();
            Console.WriteLine();
        }

        public void DisplayPurchasedPackage(TourManager manager)
        { 
            manager.PrintaPackinfo();
            Console.WriteLine();
        }

    }
}
