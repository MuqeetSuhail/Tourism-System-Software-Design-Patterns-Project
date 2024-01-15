using System.Net;
using System.Security.Principal;
using Tourism_System__Sda_Project_;

// To Use For Displaying and Admin Tasks
GoldenPackage Goldpackageobj = new GoldenPackage();
PlatinumPackage platinumPackageobj = new PlatinumPackage();
HoneymoonPackage honeymoonPackageobj = new HoneymoonPackage();

// Main:
int choice;
int CountGoldObjectnew = 0;
int CountPlatinumObjectnew = 0;
int CountHoneymoonObjectnew = 0;
int CountGoldObjectOld = 0;
int CountPlatinumObjectOld = 0;
int CountHoneymoonObjectOld = 0;
TourManager Manager;
Customer customer1 = null;
Administrator_singelton Administrator = null;
Start:
Console.Clear();
Console.WriteLine("╔════════════════════╗");
Console.WriteLine("║      Welcome       ║");
Console.WriteLine("╚════════════════════╝");
Console.WriteLine();
Console.WriteLine("Are You an Admin or User..?");
Console.WriteLine("1. Admin");
Console.WriteLine("2. Customer");
Console.WriteLine("3. Enter any other key to exit");
Console.WriteLine();

Console.Write("Enter Choice: ");
int.TryParse(Console.ReadLine(), out choice);
Console.WriteLine();



switch (choice)
{
    case 1:
        Console.WriteLine("╔═══════════════════════════╗");
        Console.WriteLine("║           Login           ║");
        Console.WriteLine("╚═══════════════════════════╝");
        Console.WriteLine();
        string enteredusername;
        string enteredpassword;
        Administrator = Administrator_singelton.getObjectInstance();
        Console.Clear();       // cleared screen for removing just created account info from screen
        Console.WriteLine("╔═══════════════════════════╗");
        Console.WriteLine("║       Welcome Admin       ║");
        Console.WriteLine("╚═══════════════════════════╝");
        Console.WriteLine();
    Credentials:
        Console.WriteLine("Enter Credentials:");
        Console.Write("Username: ");
        enteredusername = Console.ReadLine();
        Console.Write("Password: ");
        enteredpassword = Console.ReadLine();

        bool aResult = Administrator.CheckCredentials(enteredusername, enteredpassword);

        if (aResult == true)
        {
            int LoopCounter = 0;
            Console.WriteLine();
            Console.WriteLine("------------ Welcome Back " + Administrator.getName() + "------------");
            Console.WriteLine();
            while (LoopCounter != 1)
            {
                Console.WriteLine("╔═══════════════════════════╗");
                Console.WriteLine("║           Index           ║");
                Console.WriteLine("║---------------------------║");
                Console.WriteLine("║  1. Get Total Revenue     ║");
                Console.WriteLine("║  2. Enter any key to exit ║");
                Console.WriteLine("╚═══════════════════════════╝");
                Console.WriteLine();
                Console.Write("Enter Choice: ");
                int AdminChoice;
                int.TryParse(Console.ReadLine(), out AdminChoice);

                switch (AdminChoice)
                {
                    case 1:
                        Console.WriteLine("╔═══════════════════════════╗");
                        Console.WriteLine("║    Calculating Revenue    ║");
                        Console.WriteLine("╚═══════════════════════════╝");
                        Console.WriteLine();
                        Administrator.generateMonthlyReport(CountGoldObjectnew, CountPlatinumObjectnew, CountHoneymoonObjectnew, Goldpackageobj, platinumPackageobj, honeymoonPackageobj);
                        CountGoldObjectOld += CountGoldObjectnew;
                        CountHoneymoonObjectOld += CountHoneymoonObjectnew;
                        CountPlatinumObjectOld += CountPlatinumObjectnew;
                        CountPlatinumObjectnew = 0;
                        CountHoneymoonObjectnew = 0;
                        CountGoldObjectnew = 0;
                        break;

                    default:
                        Console.WriteLine("Existing Admin Mode..!");
                        LoopCounter = 1;
                        goto Start;    
                }
            }
        }
        else
        {
            Console.WriteLine("Incorrect Credentials, Plz Try Again..!");
            Console.Write("Do you want to try again...? (1 For yes and 0 For No): ");
            int UserInput = -1;
            int.TryParse(Console.ReadLine(), out UserInput);
            Console.WriteLine();

            if (UserInput == 1)
            {
                goto Credentials;
            }
        }
        break;

    case 2:
        Console.WriteLine("╔═══════════════════════════╗");
        Console.WriteLine("║     Welcome Customer      ║");
        Console.WriteLine("╚═══════════════════════════╝");
        Console.WriteLine();
    AccountCreate:
        Console.WriteLine("Do you have an account..?");
        Console.Write("Ans: ");
        string ans = Console.ReadLine();
        Console.WriteLine();
        int custchoice;

        if (ans.ToLower() == "yes")
        {
            custchoice = 1;
        }
        else
        {
            custchoice = 2;
        }

        switch (custchoice)
        {
            case 1:
            checkCredentials:
                if (customer1 != null)
                {
                    Console.WriteLine("╔═══════════════════════════╗");
                    Console.WriteLine("║           Login           ║");
                    Console.WriteLine("╚═══════════════════════════╝");
                    Console.WriteLine();
                    Console.Write("Enter Username: ");
                    string iusernamecust = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    string ipasscust = Console.ReadLine();
                    bool result = customer1.CheckCredentials(iusernamecust, ipasscust);
                    Console.WriteLine();
                    if (result == true)
                    {
                        Console.WriteLine("╔══════════════════════════════════╗");
                        Console.WriteLine("║        Purchasing Package        ║");
                        Console.WriteLine("╚══════════════════════════════════╝");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("------------ Welcome Back "+ customer1.GetName() + " ------------");
                        Console.WriteLine();
                        Purchase:
                        Console.WriteLine("  Lets Find A Package That Suits You..!              ");
                        Console.WriteLine();
                        Console.Write("Enter The Location You Want to Go to: ");
                        string custLocation = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("-------------- Available Packages ----------------");
                        Console.WriteLine();
                        customer1.DisplayPackageList(Goldpackageobj, platinumPackageobj, honeymoonPackageobj, custLocation);
                        Console.WriteLine();
                        Console.Write("Select The Package You Want: ");
                        Console.WriteLine();
                        Console.WriteLine("╔═══════════════════════════╗");
                        Console.WriteLine("║           Index           ║");
                        Console.WriteLine("║---------------------------║");
                        Console.WriteLine("║  1. Gold Package          ║");
                        Console.WriteLine("║  2. Platinum Package      ║");
                        Console.WriteLine("║  3. HoneyMoon Package     ║");
                        Console.WriteLine("║  4. Enter any key to exit ║");
                        Console.WriteLine("╚═══════════════════════════╝");
                        Console.WriteLine();
                        Console.Write("Enter Choice: ");
                        int PackChoice;
                        int.TryParse(Console.ReadLine(), out PackChoice);
                        Console.WriteLine();
                        if (PackChoice==1)
                        {
                            int gQuantity = 1;
                            int gprice = Goldpackageobj.getPrice();
                            Console.WriteLine("------- Proceeding With Gold Package ------");
                            Console.WriteLine();
                            // Factory Pattern Implementation
                            Console.Write("Number of This Package You Require: ");
                            int.TryParse(Console.ReadLine(), out gQuantity);
                            gprice *= gQuantity;
                            bool resultT=customer1.Transaction(gprice);
                            if(resultT==true)
                            {
                                Console.WriteLine("╔══════════════════════════════════╗");
                                Console.WriteLine("║      Transaction Successful      ║");
                                Console.WriteLine("╚══════════════════════════════════╝");
                                Console.WriteLine();
                                Console.WriteLine("Purchased Packages: ");
                                Console.WriteLine();
                                for (int loopCounter = 0; loopCounter < gQuantity; loopCounter++)
                                {
                                    TourManager JourneyHubLtdObject = JourneyHubLtd.CreateObject("gold", custLocation);
                                    if (JourneyHubLtdObject != null)
                                    {
                                        customer1.DisplayPurchasedPackage(JourneyHubLtdObject);
                                        CountGoldObjectnew++;
                                    }
                                }
                                Console.Write("Do you want to purchase more packages...? (1 For yes and 0 For No): ");
                                int custgInput = -1;
                                int.TryParse(Console.ReadLine(), out custgInput);
                                Console.WriteLine("Loading.....!");
                                if (custgInput==1)
                                {
                                    Console.Clear();
                                    goto Purchase;
                                }
                                else
                                {
                                    goto Start;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Opps..!,Insufficient Balance");
                                Console.WriteLine("Required Balance: " + gprice);
                                Console.WriteLine("Customer Balance: " + customer1.getBalance());
                                Console.WriteLine("Loading.....!");
                                Console.Write("Do you want to Continue Using Software...? (1 For yes and 0 For No): ");
                                int cust_Input = -1;
                                int.TryParse(Console.ReadLine(), out cust_Input);
                                if (cust_Input == 1)
                                {    
                                    Console.WriteLine("Existing Customer Mode...!");
                                    goto Start;
                                }
                               
                            }
                        }
                        else if (PackChoice==2)
                        {
                            int pQuantity = 1;
                            int pprice = platinumPackageobj.getPrice();
                            Console.WriteLine("------- Proceeding With Platinum Package ------");
                            Console.WriteLine();
                            // Factory Pattern Implementation
                            Console.Write("Number of This Package You Require: ");
                            int.TryParse(Console.ReadLine(), out pQuantity);
                            pprice *= pQuantity;
                            bool resultT = customer1.Transaction(pprice);
                            if (resultT == true)
                            {
                                Console.WriteLine("╔══════════════════════════════════╗");
                                Console.WriteLine("║      Transaction Successful      ║");
                                Console.WriteLine("╚══════════════════════════════════╝");
                                Console.WriteLine();
                                Console.WriteLine("Purchased Packages: ");
                                Console.WriteLine();
                                for (int loopCounter = 0; loopCounter < pQuantity; loopCounter++)
                                {
                                    TourManager JourneyHubLtdObject = JourneyHubLtd.CreateObject("platinum", custLocation);
                                    if (JourneyHubLtdObject != null)
                                    {
                                        customer1.DisplayPurchasedPackage(JourneyHubLtdObject);
                                        CountPlatinumObjectnew++;
                                    }
                                }
                                Console.Write("Do you want to purchase more packages...? (1 For yes and 0 For No): ");
                                int custpInput = -1;
                                int.TryParse(Console.ReadLine(), out custpInput);
                                Console.WriteLine("Loading.....!");
                                if (custpInput == 1)
                                {
                                    Console.Clear();
                                    goto Purchase;
                                }
                                else
                                {
                                    goto Start;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Opps..!,Insufficient Balance");
                                Console.WriteLine("Required Balance: " + pprice);
                                Console.WriteLine("Customer Balance: " + customer1.getBalance());
                                Console.WriteLine("Loading.....!");
                                Console.Write("Do you want to Continue Using Software...? (1 For yes and 0 For No): ");
                                int cust_Input = -1;
                                int.TryParse(Console.ReadLine(), out cust_Input);
                                if (cust_Input == 1)
                                {
                                    Console.WriteLine("Existing Customer Mode...!");
                                    goto Start;
                                }

                            }
                        }
                        else if (PackChoice==3)
                        {
                            int hQuantity = 1;
                            int hprice = honeymoonPackageobj.getPrice();
                            Console.WriteLine("------- Proceeding With Honeymoon Package ------");
                            Console.WriteLine();
                            // Factory Pattern Implementation
                            Console.Write("Number of This Package You Require: ");
                            int.TryParse(Console.ReadLine(), out hQuantity);
                            hprice *= hQuantity;
                            bool resultT = customer1.Transaction(hprice);
                            if (resultT == true)
                            {
                                Console.WriteLine("╔══════════════════════════════════╗");
                                Console.WriteLine("║      Transaction Successful      ║");
                                Console.WriteLine("╚══════════════════════════════════╝");
                                Console.WriteLine();
                                Console.WriteLine("Purchased Packages: ");
                                Console.WriteLine();
                                for (int loopCounter = 0; loopCounter < hQuantity; loopCounter++)
                                {
                                    TourManager JourneyHubLtdObject = JourneyHubLtd.CreateObject("honeymoon", custLocation);
                                    if (JourneyHubLtdObject != null)
                                    {
                                        customer1.DisplayPurchasedPackage(JourneyHubLtdObject);
                                        CountHoneymoonObjectnew++;
                                    }
                                }
                                Console.Write("Do you want to purchase more packages...? (1 For yes and 0 For No): ");
                                int custpInput = -1;
                                int.TryParse(Console.ReadLine(), out custpInput);
                                Console.WriteLine("Loading.....!");
                                if (custpInput == 1)
                                {
                                    Console.Clear();
                                    goto Purchase;
                                }
                                else
                                {
                                    goto Start;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Opps..!,Insufficient Balance");
                                Console.WriteLine("Required Balance: " + hprice);
                                Console.WriteLine("Customer Balance: " + customer1.getBalance());
                                Console.WriteLine("Loading.....!");
                                Console.Write("Do you want to Continue Using Software...? (1 For yes and 0 For No): ");
                                int CustInput = -1;
                                int.TryParse(Console.ReadLine(), out CustInput);
                                if (CustInput == 1)
                                {
                                    Console.WriteLine("Existing Customer Mode...!");
                                    goto Start;
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("Sorry No Package Suits Your Interest, please visit again, Existing....!");
                            Console.WriteLine();
                            Console.Write("Do you want to Continue Using Software...? (1 For yes and 0 For No): ");
                            int CustInput = -1;
                            int.TryParse(Console.ReadLine(), out CustInput);
                            if (CustInput == 1)
                            {
                                Console.WriteLine("Existing Customer Mode...!");
                                goto Start;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Incorrect Credentials, Plz Try Again..!");
                        Console.Write("Do you want to try again...? (1 For yes and 0 For No): ");
                        int custInput = -1;
                        int.TryParse(Console.ReadLine(), out custInput);
                        Console.WriteLine();

                        if (custInput == 1)
                        {
                            goto checkCredentials;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No Account Found, Plz Create One First..!");
                    goto AccountCreate;
                }
                break;

            case 2:
                Console.WriteLine("╔══════════════════════════════════╗");
                Console.WriteLine("║         Account Creation         ║");
                Console.WriteLine("╚══════════════════════════════════╝");
                Console.WriteLine();
                Console.Write("Thanks For Joining Us, What is Your Name: ");
                string inputnamecust = Console.ReadLine();
                Console.Write("Great, Now What is Your Gender: ");
                string inputgendercust = Console.ReadLine();
                Console.Write("Enter Username: ");
                string inputusernamecust = Console.ReadLine();
                Console.Write("Enter Password: ");
                string inputpasscust = Console.ReadLine();
                customer1 = new Customer();
                customer1.CreateAccount(inputnamecust, inputgendercust, inputusernamecust, inputpasscust);
                Console.WriteLine();
                Console.WriteLine("--- Proceeding Forward ---");
                Console.WriteLine("1. To Purchase Package");
                Console.WriteLine("2. Enter any other key to exit");
                Console.Write("Enter Choice: ");
                int.TryParse(Console.ReadLine(), out custchoice);
                Console.WriteLine();
                if (custchoice == 1)
                {
                    Console.Clear();
                    goto case 1;
                }
                break;

            default:
                Console.WriteLine("Existing....!");
                break;
        }
        break;

    default:
        Console.WriteLine("Existing....!");
        break;
}

return 0;



