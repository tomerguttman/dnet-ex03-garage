using System;
using Ex03_GarageLogic;

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
            System.Console.WriteLine("Enter car color (Red, Blue, Black, Gray):");
            while()
            {
                try
                {
                    Car.eColor carColor = Car.ToECarColor(System.Console.ReadLine());
                }
                catch
                {
                    //enter to loop and print message
                }
            }


        }

        public static void RecieveAdditionalMotorcycleInformation(GarageSlot io_newGarageSlot)
        {

        }

        public static void RecieveAdditionalTruckInformation(GarageSlot io_newGarageSlot)
        {

        }
    }
}
