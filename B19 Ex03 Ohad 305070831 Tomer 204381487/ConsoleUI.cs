using System;
using Ex03_GarageLogic;
using System.Collections.Generic;

namespace Ex03_ConsoleUI
{
    class ConsoleUI
    {
        public static void GarageManagingProgram() //////////////////////// main method ///////////////////////////
        {
            Garage myGarage = new Garage();

            AddNewVehicleToGarage(myGarage);
        }

        public static void AddNewVehicleToGarage(Garage io_MyGarage)
        {
            Vehicle newVehicle = null;
            string licenseNumber = null;
            string typeOfVehicle = null;

            Console.Write("Please enter the Vehicle's License number: ");
            licenseNumber = Console.ReadLine();
            Console.WriteLine("choose one of the following vehicles by number: 1.Electric Car\n2.Electric Motorcycle\n3.Fuel Car\n4.Fuel Motorcycle\n5.Truck");

            try
            {
                typeOfVehicle = Console.ReadLine();
                newVehicle = VehicleCreator.CreateVehicle(VehicleCreator.ToEVehicle(typeOfVehicle), licenseNumber);
            }
            catch (ArgumentException exception)
            {
                System.Console.WriteLine(exception.Message);
            }

            AddGarageSlotToTheGarage(io_MyGarage, newVehicle, typeOfVehicle);
        }

        public static void AddGarageSlotToTheGarage(Garage io_MyGarage, Vehicle i_newVehicle, string i_TypeOfVehicle)
        {
            bool enterLoop = true;
            GarageSlot newGarageSlot = null;

            if (io_MyGarage.M_MyGarage.TryGetValue(i_newVehicle.M_LicenseNumber, out newGarageSlot) == false)
            {
                while (enterLoop)
                {
                    try
                    {
                        CreateNewGarageSlot(out newGarageSlot, i_newVehicle);
                        enterLoop = false;
                    }
                    catch (FormatException exception)
                    {
                        enterLoop = true;
                        System.Console.WriteLine(exception.Message);
                    }
                }

                RecieveAdditionalVehicleInformation(newGarageSlot, i_TypeOfVehicle);
                io_MyGarage.M_MyGarage.Add(i_newVehicle.M_LicenseNumber, newGarageSlot);
            }
            else
            {
                newGarageSlot.UpdateVehicleStatus(GarageSlot.eGarageStatus.BeingFixed);
            }
        }

        public static void CreateNewGarageSlot(out GarageSlot o_NewGarageSlot, Vehicle i_newVehicle)
        {
            o_NewGarageSlot = null;

            string ownerName = null;
            string ownerPhoneNumber = null;

            System.Console.WriteLine("Enter your name:");
            ownerName = System.Console.ReadLine();
            System.Console.WriteLine("Enter your phone Number (10 digit number with no spaces or hyphens '-' ):");
            ownerPhoneNumber = System.Console.ReadLine();

            if (ValidPhoneNumber(ownerPhoneNumber) == false)
            {
                throw (new FormatException("Invalid phone number ! ! !"));
            }
            o_NewGarageSlot = new GarageSlot(ownerName, ownerPhoneNumber, i_newVehicle);
        }

        public static bool ValidPhoneNumber(string i_ownerPhoneNumber)
        {
            int fakeOutParameter;

            return int.TryParse(i_ownerPhoneNumber, out fakeOutParameter) && i_ownerPhoneNumber.Length == 10;
        }

        public static void RecieveAdditionalVehicleInformation(GarageSlot newGarageSlot, string i_TypeOfVehicle)
        {
            bool enterLoop = true;

            Console.WriteLine("Enter the vehicle's model name:");
            newGarageSlot.M_Vehicle.M_ModelName = Console.ReadLine();

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
                    newGarageSlot.M_Vehicle.UpdateEnergySource(Console.ReadLine());
                    enterLoop = false;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    enterLoop = true;
                }
            }

            enterLoop = true;

            string[] outputAdditionalInformationNeeded = newGarageSlot.M_Vehicle.ReturnAdditionalInformationNeeded();
            string[] additionalInformation = new string[2];

            Console.WriteLine(outputAdditionalInformationNeeded[0]);

            while (enterLoop == true)
            {
                try
                {
                    additionalInformation[0] = Console.ReadLine();
                    newGarageSlot.M_Vehicle.ParseFirstInputToInformationNeeded(additionalInformation[0]);
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
                    newGarageSlot.M_Vehicle.ParseSecondInputToInformationNeeded(additionalInformation[1]);
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

            foreach (Vehicle.Tire tire in newGarageSlot.M_Vehicle.M_Tires)
            {
                tire.M_ManufacturerName = manufacturerName;
            }
        }

        public static void InflateVehicleTires(Garage io_MyGarage)
        {
            bool enterLoop = true;
            string licenseNumber = null;
            Console.WriteLine("Enter the license number of the vehicle:");
            licenseNumber = Console.ReadLine();
            GarageSlot tempGarageSlot = null;

            if (io_MyGarage.M_MyGarage.TryGetValue(licenseNumber, out tempGarageSlot) == false)
            {
                while (enterLoop == true)
                {
                    Console.WriteLine("What is the amount of pressure you would like to add?");

                    try
                    {
                        float tirePressureToAdd = tempGarageSlot.M_Vehicle.ToFloat(Console.ReadLine());
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
                throw (new ArgumentException("The vehicle with the license number you entered is not in the garage ! ! !"));
            }
        }

        public static void FuelVehicle(Garage io_MyGarage)
        {
            bool enterLoop = true;
            string licenseNumber = null;
            bool isTheVehicleElectric = false;

            Console.WriteLine("Enter the license number of the vehicle:");
            licenseNumber = Console.ReadLine();

            GarageSlot tempGarageSlot = null;

            if (io_MyGarage.M_MyGarage.TryGetValue(licenseNumber, out tempGarageSlot) == true)
            {
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
                        catch(ArgumentException exception)
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
                        float amountOfFuelToAdd = tempGarageSlot.M_Vehicle.ToFloat(Console.ReadLine());

                        if(isTheVehicleElectric == true)
                        {
                            amountOfFuelToAdd /= 60;
                            tempGarageSlot.RefillEnergySource(amountOfFuelToAdd);
                        }
                        else
                        {
                            tempGarageSlot.RefillEnergySource(amountOfFuelToAdd);

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
                throw (new ArgumentException("The vehicle with the license number you entered is not in the garage ! ! !"));
            }
        }

        public static void ChangeVehicleStatus(Garage io_MyGarage)
        {
            bool enterLoop = true;
            GarageSlot.eGarageStatus newVehicleStatus;
            string ownerLicenseNumber = null;
            GarageSlot currentGarageSlot = null;

            Console.WriteLine("Please enter the vehicle license number");
            ownerLicenseNumber = Console.ReadLine();
            if (io_MyGarage.M_MyGarage.TryGetValue(ownerLicenseNumber, out currentGarageSlot) == false)
            {
                throw (new ArgumentException("The vehicle with license number you entered does not exist in the garage ! ! !"));
            }
            else
            {
                Console.Write("Choose one of the following vehicle's statuses:\n1.Being Fixed\n2.Ready\n3.Paid For");
                while (enterLoop == true)
                {
                    try
                    {
                        newVehicleStatus = currentGarageSlot.ToEGarageStatus(Console.ReadLine()); //throws exception if needed.
                        currentGarageSlot.UpdateVehicleStatus(newVehicleStatus);
                        enterLoop = false;
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
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
                Console.WriteLine(tempGarageSlot.M_Vehicle.ReturnVehicleInformation());
            }
            else
            {
                throw (new ArgumentException("The vehicle with the license number you entered is not in the garage ! ! !"));
            }
        }
    }
}