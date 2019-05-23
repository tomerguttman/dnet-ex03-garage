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
            string typeOfVehicle = null;

            Console.Write("Please enter the Vehicle's License number: ");
            licenseNumber = Console.ReadLine();
            Console.WriteLine("choose one of the following vehicles by number: 1.Electric Car\n2.Electric Motorcycle\n3.Fuel Car\n4.Fuel Motorcycle\n5.Truck");

            try
            {
                typeOfVehicle = Console.ReadLine();
                newVehicle =  VehicleCreator.CreateVehicle(VehicleCreator.ToEVehicle(typeOfVehicle), licenseNumber);
            }
            catch(ArgumentException exception)
            {
                System.Console.WriteLine(exception.Message);
            }

            AddGarageSlotToTheGarage(io_MyGarage, newVehicle, typeOfVehicle);
        }

        public static void AddGarageSlotToTheGarage(Garage io_MyGarage, Vehicle i_newVehicle, string i_TypeOfVehicle)
        {
            bool enterLoop = true;
            GarageSlot newGarageSlot = null;

            if (io_MyGarage.M_MyGarage.TryGetValue(i_newVehicle.M_LicenseNumber,out newGarageSlot) == false)
            {
                while (enterLoop)
                {
                    try
                    {
                        CreateNewGarageSlot(out newGarageSlot, i_newVehicle);
                        enterLoop = false;
                    }
                    catch(FormatException exception)
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
                Console.WriteLine("how much battery life remains in the vehicle?");
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

            string[] additionalInformationNeeded = newGarageSlot.M_Vehicle.ReturnAdditionalInformationNeeded();

            Console.WriteLine(additionalInformationNeeded[0]);

        }
    }
}
