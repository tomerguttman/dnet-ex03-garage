using System;
using Ex03_GarageLogic;
using System.Collections.Generic;

namespace Ex03_ConsoleUI
{
    class ConsoleUI
    {
        public static void GarageManagingProgram()
        {
            Garage myGarage = new Garage();

            AddNewVehicleToGarage(myGarage);
        }

        public static void AddNewVehicleToGarage(Garage io_MyGarage)
        {
            Vehicle newVehicle = null;
            string licenseNumber = null;

            Console.Write("Please enter the Vehicle's License number: ");
            licenseNumber = Console.ReadLine();
            Console.WriteLine("choose one of the following vehicles by number: 1.Electric Car\n2.Electric Motorcycle\n3.Fuel Car\n4.Fuel Motorcycle\n5.Truck");

            try
            {
                newVehicle =  VehicleCreator.CreateVehicle(VehicleCreator.ToEVehicle(Console.ReadLine()), licenseNumber);
            }
            catch(ArgumentException exception)
            {
                System.Console.WriteLine(exception.Message);
            }

            AddGarageSlotToTheGarage(io_MyGarage, newVehicle);
        }

        public static void AddGarageSlotToTheGarage(Garage io_MyGarage, Vehicle i_newVehicle)
        {
            bool wasExceptionThrown = false;
            GarageSlot newGarageSlot = null;

            if (io_MyGarage.M_MyGarage.TryGetValue(i_newVehicle.M_LicenseNumber,out newGarageSlot) == false)
            {
                while (!wasExceptionThrown)
                {
                    try
                    {
                        CreateNewGarageSlot(out newGarageSlot, i_newVehicle);
                    }
                    catch(FormatException exception)
                    {
                        wasExceptionThrown = true;
                        System.Console.WriteLine(exception.Message);
                    }
                }

                RecieveAdditionalVehicleInformation(newGarageSlot);
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

        public static void RecieveAdditionalVehicleInformation(GarageSlot newGarageSlot)
        {
            if (newGarageSlot.M_Vehicle is Car)
            {
                RecieveAdditionalCarInformation(newGarageSlot);
            }
            else if (newGarageSlot.M_Vehicle is Motorcycle)
            {
                RecieveAdditionalMotorcycleInformation(newGarageSlot);
            }
            else if (newGarageSlot.M_Vehicle is Truck)
            {
                RecieveAdditionalTruckInformation(newGarageSlot);
            }
        }

        public static void RecieveAdditionalCarInformation(GarageSlot io_newGarageSlot)
        {
            Car newCar = io_newGarageSlot.M_Vehicle as Car;
            bool enterLoop = true;
            int numberOfDoors = 0;
            Car.eColor carColor = Car.eColor.Black;

            Console.WriteLine("Enter the car's color (Red, Blue, Black, Gray):");

            while (enterLoop)
            {
                try
                {
                    carColor = Car.ToECarColor(System.Console.ReadLine());
                    enterLoop = false;
                }
                catch(FormatException exception)
                {
                    enterLoop = true;
                    System.Console.WriteLine(exception.Message);
                }
            }

            newCar.M_CarColor = carColor;

            enterLoop = true;

            System.Console.WriteLine("Enter the number of doors that the car has (between 2 and 5):");

            while(enterLoop)
            {
                try
                {
                    numberOfDoors = ToInt(Console.ReadLine());
                    numberOfDoors = CheckIfParameterIsWithinRange(2, 5, numberOfDoors);
                    enterLoop = false;
                }
                catch (Exception exception)
                {
                    enterLoop = true;
                    Console.WriteLine(exception.Message);
                }
            }

            newCar.M_NumOfDoors = numberOfDoors;
        }

        public static void RecieveAdditionalMotorcycleInformation(GarageSlot io_newGarageSlot)
        {
            Motorcycle newMotorcycle = io_newGarageSlot.M_Vehicle as Motorcycle;
            bool enterLoop = true;
            int engineVolume = 0;
            string licenseType = null;

            Console.WriteLine("Enter the motorcycle's license type (A, A1, A2, B):");

            while (enterLoop)
            {
                try
                {
                    licenseType = ReturnLicenseTypeIfValid(Console.ReadLine());
                    enterLoop = false;
                }
                catch (ArgumentException exception)
                {
                    enterLoop = true;
                    System.Console.WriteLine(exception.Message);
                }
            }

            newMotorcycle.M_LicenseType = licenseType;

            enterLoop = true;

            System.Console.WriteLine("Enter the motorcycle's engine volume: ");

            while (enterLoop)
            {
                try
                {
                    engineVolume = ToInt(Console.ReadLine());
                    enterLoop = false;
                }
                catch (FormatException exception)
                {
                    enterLoop = true;
                    Console.WriteLine(exception.Message);
                }
            }

            newMotorcycle.M_EngineVolume = engineVolume;
        }

        public static void RecieveAdditionalTruckInformation(GarageSlot io_newGarageSlot)
        {
            Truck newTruck = io_newGarageSlot.M_Vehicle as Truck;
            bool enterLoop = true;
            float loadVolume = 0f;

            Console.WriteLine("Enter the truck's load volume:");

            while (enterLoop)
            {
                try
                {
                    loadVolume = ToFloat(Console.ReadLine());
                    enterLoop = false;
                }
                catch (FormatException exception)
                {
                    enterLoop = true;
                    System.Console.WriteLine(exception.Message);
                }
            }

            newTruck.M_LoadVolume = loadVolume;

            enterLoop = true;

            System.Console.WriteLine("Is the truck hauling dangerous materials? ('yes' or 'n')");

            while (!enterLoop)
            {
                try
                {
                    newTruck.M_IsHaulingDangerousMaterials = IsHaulingDangerousMaterials(Console.ReadLine());
                    enterLoop = false;
                }
                catch (FormatException exception)
                {
                    enterLoop = true;
                    Console.WriteLine(exception.Message);
                }
            }
        }

        public static int ToInt(string i_StrToParse)
        {
            int o_OutputInt = 0;
            bool didParseSucceed = int.TryParse(i_StrToParse, out o_OutputInt);

            if (didParseSucceed == false)
            {
                throw (new FormatException("Invalid input ! ! !"));
            }

            return o_OutputInt;
        }

        public static float ToFloat(string i_StrToParse)
        {
            float o_OutputFloat = 0f;
            bool didParseSucceed = float.TryParse(i_StrToParse, out o_OutputFloat);

            if (didParseSucceed == false)
            {
                throw (new FormatException("Invalid input ! ! !"));
            }

            return o_OutputFloat;
        }

        public static string ReturnLicenseTypeIfValid(string i_StrInputLicenseType)
        {
            string o_LicenseType = null;

            switch(i_StrInputLicenseType)
            {
                case "A":
                    o_LicenseType = i_StrInputLicenseType;
                    break;

                case "A1":
                    o_LicenseType = i_StrInputLicenseType;
                    break;

                case "A2":
                    o_LicenseType = i_StrInputLicenseType;
                    break;

                case "B":
                    o_LicenseType = i_StrInputLicenseType;
                    break;

                default:
                    throw (new ArgumentException("Please Choose one of the given license types ! ! !"));
            }

            return o_LicenseType;
        }

        public static int CheckIfParameterIsWithinRange(int i_MaxParam, int i_MinParam, int i_ValueToCheck)
        {
            if(i_ValueToCheck > i_MaxParam || i_ValueToCheck < i_MinParam)
            {
                throw (new ValueOutOfRangeException(i_MaxParam, i_MinParam, "Please choose from the range given ! ! !"));
            }

            return i_ValueToCheck;
        }

        public static bool IsHaulingDangerousMaterials(string i_InputAnswer)
        {
            bool isHaulingDangerouseMaterials = false;

            if(i_InputAnswer.Equals("yes"))
            {
                isHaulingDangerouseMaterials = true;
            }
            else if(i_InputAnswer.Equals("no"))
            {
                isHaulingDangerouseMaterials = false;
            }
            else
            {
                throw (new ArgumentException("Please answer 'yes' or 'no'"));
            }

            return isHaulingDangerouseMaterials;
        }
    }
}
