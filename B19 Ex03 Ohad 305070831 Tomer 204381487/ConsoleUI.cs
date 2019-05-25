using System;
using System.Collections.Generic;
using Ex03_GarageLogic;

namespace Ex03_ConsoleUI
{
    public static class ConsoleUI
    {
        public static void GarageManagingProgram() // main method //
        {
            Garage myGarage = new Garage();
            bool programContinue = true;
            VehicleCreator.InitializeVehicleTypeList();

            while (programContinue)
            {
                PrintGarageMenu();

                try
                {
                    ManageUserChoiseOfAction(myGarage, Console.ReadLine(), ref programContinue);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

                System.Threading.Thread.Sleep(1000);
            }

            ExitSequence();
        }

        public static void PrintGarageMenu()
        {
            string garageMenu;
            garageMenu = string.Format(
@"-------------Garage-Menu-------------
1.Enter a new vehicle to the garage.
2.Display all vehicle license plates in the garage.
3.Display all vehicle license plates in the garage according to their condition.
4.Change vehicle condition in the garage.
5.Inflate all tires of a vehicle.
6.Refill energy source (Fuel/Electric).
7.Display full information of a vehicle.
8.Release vehicle from the garage.
9.Exit the program.

Please choose your action by entering a number between 1-9");
            Console.WriteLine(garageMenu);
        }

        public static void ManageUserChoiseOfAction(Garage io_MyGarage, string i_UserChoiceOfAction, ref bool io_ProgramContinue)
        {
            Console.WriteLine("------------------------------------------------------");
            switch (i_UserChoiceOfAction)
            {
                case "1":
                    AddNewVehicleToGarage(io_MyGarage);
                    break;

                case "2":
                    PrintAllVehicleInTheGarage(io_MyGarage, i_UserChoiceOfAction);
                    break;

                case "3":
                    PrintAllVehicleInTheGarage(io_MyGarage, i_UserChoiceOfAction);
                    break;

                case "4":
                    ChangeVehicleStatus(io_MyGarage);
                    break;

                case "5":
                    InflateVehicleTires(io_MyGarage);
                    break;

                case "6":
                    FuelVehicle(io_MyGarage);
                    break;

                case "7":
                    PrintVehicleInformation(io_MyGarage);
                    break;

                case "8":
                    RemoveVehicleFromTheGarage(io_MyGarage);
                    break;

                case "9":
                    io_ProgramContinue = false;
                    break;

                default:
                    throw new ValueOutOfRangeException(9, 1, "Please choose from the list of options (1-9) ! ! !");
            }
        }

        public static void AddNewVehicleToGarage(Garage io_MyGarage)
        {
            string vehicleLicenseNumber = null;

            Console.Write("Please enter the Vehicle's License number: ");
            vehicleLicenseNumber = Console.ReadLine();
            
            try
            {
                AddGarageSlotToTheGarage(io_MyGarage, vehicleLicenseNumber);
                Console.WriteLine("Success, your vehicle was entered to the garage!\n");
            }
            catch(Exception excption)
            {
                Console.WriteLine(excption.Message);
            }
        }

        public static void AddGarageSlotToTheGarage(Garage io_MyGarage, string i_VehicleLicenseNumber)
        {
            bool enterLoop = true;
            int counterIndicator = 1;
            string typeOfVehicle = null;
            GarageSlot newGarageSlot = null;
            Vehicle newVehicle = null;

            if (io_MyGarage.M_MyGarage.TryGetValue(i_VehicleLicenseNumber, out newGarageSlot) == false)
            {
                Console.WriteLine("choose one of the following vehicles by number:");

                foreach (VehicleCreator.eVehicles currentType in VehicleCreator.m_VehicleTypes)
                {
                    Console.WriteLine(string.Format("{0}.{1}", counterIndicator, currentType.ToString()));
                    counterIndicator += 1;
                }

                while (enterLoop == true)
                {
                    try
                    {
                        typeOfVehicle = Console.ReadLine();
                        newVehicle = VehicleCreator.CreateVehicle(VehicleCreator.ToEVehicle(typeOfVehicle), i_VehicleLicenseNumber);
                        enterLoop = false;
                    }
                    catch (Exception exception)
                    {
                        System.Console.WriteLine(exception.Message);
                    }
                }

                enterLoop = true;

                while (enterLoop)
                {
                    try
                    {
                        CreateNewGarageSlot(out newGarageSlot, newVehicle);
                        enterLoop = false;
                    }
                    catch (FormatException exception)
                    {
                        System.Console.WriteLine(exception.Message);
                    }
                }

                RecieveAdditionalVehicleInformation(newGarageSlot, typeOfVehicle);
                io_MyGarage.M_MyGarage.Add(newVehicle.M_LicenseNumber, newGarageSlot);
            }
            else
            {
                newGarageSlot.UpdateVehicleStatus(GarageSlot.eGarageStatus.BeingFixed);
                throw new ArgumentException("The vehicle is already in the garage! It's status was updated to Being Fixed.");
            }
        }

        public static void CreateNewGarageSlot(out GarageSlot o_NewGarageSlot, Vehicle i_newVehicle)
        {
            bool enterLoop = true;
            string ownerName = null;
            string ownerPhoneNumber = null;
            o_NewGarageSlot = null;

            System.Console.WriteLine("Enter your name:");
            ownerName = System.Console.ReadLine();
            System.Console.WriteLine("Enter your phone Number (10 digit number with no spaces or hyphens '-' ):");
            while (enterLoop == true)
            {
               try
                {
                    ownerPhoneNumber = System.Console.ReadLine();
                    if (ValidPhoneNumber(ownerPhoneNumber) == true)
                    {
                        enterLoop = false;
                    }
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            o_NewGarageSlot = new GarageSlot(ownerName, ownerPhoneNumber, i_newVehicle);
        }

        public static bool ValidPhoneNumber(string i_ownerPhoneNumber)
        {
            int onlyToCheckIfNumber;

            if ((int.TryParse(i_ownerPhoneNumber, out onlyToCheckIfNumber) && i_ownerPhoneNumber.Length == 10) == false )
            {
                throw new FormatException("invalid phone number ! ! !");
            }

            return true;
        }

        ///later on maybe try to split to methods
        public static void RecieveAdditionalVehicleInformation(GarageSlot io_NewGarageSlot, string i_TypeOfVehicle)
        {
            bool enterLoop = true;

            Console.WriteLine("Enter the vehicle's model name:");
            io_NewGarageSlot.M_Vehicle.M_ModelName = Console.ReadLine();

            if (i_TypeOfVehicle.Equals("1") || i_TypeOfVehicle.Equals("2"))
            {
                Console.WriteLine("how much battery life remains in the vehicle (in hours)?");
            }
            else
            {
                Console.WriteLine("How much fuel remains in the vehicle?");
            }

            while (enterLoop == true)
            {
                try
                {
                    io_NewGarageSlot.M_Vehicle.UpdateEnergySource(Console.ReadLine());
                    enterLoop = false;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    enterLoop = true;
                }
            }

            enterLoop = true;

            string[] outputAdditionalInformationNeeded = io_NewGarageSlot.M_Vehicle.ReturnAdditionalInformationNeeded();
            string[] additionalInformation = new string[2];

            Console.WriteLine(outputAdditionalInformationNeeded[0]);

            while (enterLoop == true)
            {
                try
                {
                    additionalInformation[0] = Console.ReadLine();
                    io_NewGarageSlot.M_Vehicle.ParseFirstInputToInformationNeeded(additionalInformation[0]);
                    enterLoop = false;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    enterLoop = true;
                }
            }

            enterLoop = true;

            Console.WriteLine(outputAdditionalInformationNeeded[1]);

            while (enterLoop == true)
            {
                try
                {
                    additionalInformation[1] = Console.ReadLine();
                    io_NewGarageSlot.M_Vehicle.ParseSecondInputToInformationNeeded(additionalInformation[1]);
                    enterLoop = false;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    enterLoop = true;
                }
            }

            Console.WriteLine("What is the tires manufacturer name?");
            string manufacturerName = Console.ReadLine();

            foreach (Vehicle.Tire tire in io_NewGarageSlot.M_Vehicle.M_Tires)
            {
                tire.M_ManufacturerName = manufacturerName;
            }

            enterLoop = true;

            while(enterLoop)
            {
                try
                {
                    Console.WriteLine("What is the current tire pressure in your vehicle?");
                    string strInputCurrentTirePressure = Console.ReadLine();

                    if (io_NewGarageSlot.M_Vehicle.M_Tires[0].IsTirePressureWithinRange(strInputCurrentTirePressure))
                    {
                        foreach (Vehicle.Tire tire in io_NewGarageSlot.M_Vehicle.M_Tires)
                        {
                            tire.M_CurrentTirePressure = Vehicle.ToFloat(strInputCurrentTirePressure);
                        }
                    }

                    enterLoop = false;
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        public static void InflateVehicleTires(Garage io_MyGarage)
        {
            bool enterLoop = true;
            float tiresPressureBeforeUpdate = 0;
            string licenseNumber = null;
            Console.WriteLine("Enter the license number of the vehicle:");
            licenseNumber = Console.ReadLine();
            GarageSlot tempGarageSlot = null;

            if (io_MyGarage.M_MyGarage.TryGetValue(licenseNumber, out tempGarageSlot) == true)
            {
                tiresPressureBeforeUpdate = tempGarageSlot.M_Vehicle.M_Tires[0].M_CurrentTirePressure;

                while (enterLoop == true)
                {
                    Console.WriteLine("What is the amount of pressure you would like to add?");

                    try
                    {
                        float tirePressureToAdd = Vehicle.ToFloat(Console.ReadLine());
                        tempGarageSlot.InflateTires(tirePressureToAdd);
                        enterLoop = false;
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                        enterLoop = true;
                    }
                }
            }
            else
            {
                throw new ArgumentException("The vehicle with the license number you entered is not in the garage ! ! !");
            }

            Console.WriteLine(string.Format("Success, your vehicle's tires were inflated from {0} to {1}.\n", tiresPressureBeforeUpdate, tempGarageSlot.M_Vehicle.M_Tires[0].M_CurrentTirePressure));
        }

        public static void FuelVehicle(Garage io_MyGarage) ///later on maybe try to split to methods
        {
            bool enterLoop = true;
            string licenseNumber = null;
            string outputSuccessMessage = null;
            bool isTheVehicleElectric = false;
            float energySourceLevelBeforeUpdate = 0;

            Console.WriteLine("Enter the license number of the vehicle:");
            licenseNumber = Console.ReadLine();

            GarageSlot tempGarageSlot = null;

            if (io_MyGarage.M_MyGarage.TryGetValue(licenseNumber, out tempGarageSlot) == true)
            {
                energySourceLevelBeforeUpdate = tempGarageSlot.M_Vehicle.M_CurrentAmountOfEnergy;
                isTheVehicleElectric = tempGarageSlot.M_Vehicle.GetType().ToString().ToLower().Contains("electric");

                if (isTheVehicleElectric == true)
                {
                    Console.WriteLine("What is the amount of power you would like to charge your vehicle's battery with (in minutes)?");
                }
                else
                {
                    while (enterLoop == true)
                    {
                        try
                        {
                            Console.WriteLine("What type of fuel would you like to add (Octane95, Octane96, Octane98, Soler)?");
                            bool isTypeOfFuelCorrect = tempGarageSlot.IsFuelTypeCorrect(Console.ReadLine());
                            enterLoop = false;
                        }
                        catch(Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                    }

                    Console.WriteLine("How much fuel would you like to add to your vehicle's fuel tank?");
                }

                enterLoop = true;

                while (enterLoop == true)
                {
                    try
                    {
                        float amountOfFuelToAdd = Vehicle.ToFloat(Console.ReadLine());

                        if(isTheVehicleElectric == true)
                        {
                            amountOfFuelToAdd /= 60;
                            tempGarageSlot.RefillEnergySource(amountOfFuelToAdd);
                            outputSuccessMessage = string.Format("Success, your vehicle's battery was charged from {0} to {1}.\n", energySourceLevelBeforeUpdate, tempGarageSlot.M_Vehicle.M_CurrentAmountOfEnergy);
                        }
                        else
                        {
                            tempGarageSlot.RefillEnergySource(amountOfFuelToAdd);
                            outputSuccessMessage = string.Format("Success, your vehicle's tank was refueled from {0} to {1}.\n", energySourceLevelBeforeUpdate, tempGarageSlot.M_Vehicle.M_CurrentAmountOfEnergy);
                        }
                
                        enterLoop = false;
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                        enterLoop = true;
                    }
                }
            }
            else
            {
                throw new ArgumentException("The vehicle with the license number you entered is not in the garage ! ! !");
            }

            Console.Write(outputSuccessMessage);
        } 

        public static void ChangeVehicleStatus(Garage io_MyGarage)
        {
            bool enterLoop = true;
            string ownerLicenseNumber = null;
            GarageSlot.eGarageStatus newVehicleStatus = GarageSlot.eGarageStatus.BeingFixed;
            GarageSlot currentGarageSlot = null;

            Console.WriteLine("Please enter the vehicle license number");
            ownerLicenseNumber = Console.ReadLine();

            if (io_MyGarage.M_MyGarage.TryGetValue(ownerLicenseNumber, out currentGarageSlot) == false)
            {
                throw new ArgumentException("The vehicle with license number you entered does not exist in the garage ! ! !");
            }
            else
            {
                Console.WriteLine("Choose one of the following vehicle's statuses:\n1.Being Fixed\n2.Ready\n3.Paid For");

                while (enterLoop == true)
                {
                    try
                    {
                        newVehicleStatus = GarageSlot.ToEGarageStatus(Console.ReadLine());
                        currentGarageSlot.UpdateVehicleStatus(newVehicleStatus);
                        enterLoop = false;
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }

                Console.WriteLine(string.Format("Success, vehicle license number {0} condition was updated to {1}.\n", ownerLicenseNumber, newVehicleStatus.ToString()));
            }
        }

        public static void PrintVehicleInformation(Garage i_MyGarage)
        {
            string licenseNumber = null;

            Console.WriteLine("Enter the license number of the vehicle:");
            licenseNumber = Console.ReadLine();

            GarageSlot tempGarageSlot = null;

            if (i_MyGarage.M_MyGarage.TryGetValue(licenseNumber, out tempGarageSlot) == true)
            {
                Console.WriteLine(tempGarageSlot.ReturnGarageSlotInformation());
                Console.WriteLine(tempGarageSlot.M_Vehicle.ReturnVehicleInformation());
            }
            else
            {
                throw new ArgumentException("The vehicle with the license number you entered is not in the garage ! ! !");
            }
        }

        public static void PrintAllVehicleInTheGarage(Garage i_MyGarage, string i_UserChoiceOfAction)
        {
            string outputMessage = null;
            int counter = 0;
            if(i_UserChoiceOfAction == "2")
            {
                Console.WriteLine("All the vehicles' license number in the garage are:");

                foreach (KeyValuePair<string, GarageSlot> currentEntryInTheDictionary in i_MyGarage.M_MyGarage)
                {
                    outputMessage = string.Format("{0}.{1}", counter + 1, currentEntryInTheDictionary.Value.M_Vehicle.M_LicenseNumber);
                    Console.WriteLine(outputMessage);
                    counter += 1;
                }
            }
            else
            {
                bool enterLoop = true;
                List<string> listOfVehiclesFilterdByStatus;
                GarageSlot.eGarageStatus userChoiceOfVehicleCondition = GarageSlot.eGarageStatus.BeingFixed; ///temporary.

                while(enterLoop)
                {
                    try
                    {
                        Console.WriteLine("Please enter the condition of the vehicles in the garage that you'd like to see out of the following options by choosing a number:\n1.Being Fixed\n2.Ready\n3.Paid For");
                        userChoiceOfVehicleCondition = GarageSlot.ToEGarageStatus(Console.ReadLine());
                        enterLoop = false;
                    }
                    catch (FormatException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }

                listOfVehiclesFilterdByStatus = i_MyGarage.CreateListByVehicleStatus(userChoiceOfVehicleCondition);
                Console.WriteLine(string.Format("The vehicles in the garage that are {0} are:", userChoiceOfVehicleCondition.ToString()));

                foreach (string currentVehicleLicenseNumber in listOfVehiclesFilterdByStatus)
                {
                    outputMessage = string.Format("{0}.{1}", counter + 1, currentVehicleLicenseNumber);
                    Console.WriteLine(outputMessage);
                    counter += 1;
                }
            }       
        }

        public static void RemoveVehicleFromTheGarage(Garage io_MyGarage)
        {
            string licenseNumber = null;
            GarageSlot tempGarageSlot = null;
            bool wasTheVehicleReleased = false;

            Console.WriteLine("Enter the license number of the vehicle:");
            licenseNumber = Console.ReadLine();

            if (io_MyGarage.M_MyGarage.TryGetValue(licenseNumber, out tempGarageSlot) == true)
            {
                try
                {
                    io_MyGarage.RemoveVehicleFromTheGarage(tempGarageSlot);
                    wasTheVehicleReleased = true;
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            else
            {
                throw new ArgumentException("The vehicle with the license number you entered is not in the garage ! ! !\n");
            }

            if (wasTheVehicleReleased == true)
            {
                Console.WriteLine(string.Format("Vehicle license number {0} was delivered to {1} successfully!\n", licenseNumber, tempGarageSlot.M_OwnerName));
            }
        }

        public static void ExitSequence()
        {
            Console.WriteLine("Thank for using the garage program, goodbye ! ! !");
            System.Threading.Thread.Sleep(1000);
            System.Environment.Exit(0);
        }
    }
}