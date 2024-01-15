using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourism_System__Sda_Project_
{
    internal class JourneyHubLtd
    {
        // Factory Pattern Implementation Basically Factory (Our Company's Customer Office We Can Assume) Goes to TourManager to Make Object 
        public static TourManager CreateObject(string typeofobject, string Location)
        {
            TourManager factoryassistantmanager = null;
            if (typeofobject.ToLower() == "gold")
            {
                // Dependency Injection Implementation
                GoldenPackage GoldPackage = new GoldenPackage(Location);
                factoryassistantmanager = new TourManager(GoldPackage);
            }
            else if (typeofobject.ToLower() == "platinum")
            {
                // Dependency Injection Implementation
                PlatinumPackage PlatPackage = new PlatinumPackage(Location);
                factoryassistantmanager = new TourManager(PlatPackage);
            }
            else if (typeofobject.ToLower() == "honeymoon")
            {
                // Dependency Injection Implementation
                HoneymoonPackage HoneymoonPackage = new HoneymoonPackage(Location);
                factoryassistantmanager = new TourManager(HoneymoonPackage); ;
            }
            if (factoryassistantmanager != null)
            {
                return factoryassistantmanager;
            }
            else
            {
                Console.WriteLine("No Object Made..!");
                return factoryassistantmanager;
            }
        }
    }
}
