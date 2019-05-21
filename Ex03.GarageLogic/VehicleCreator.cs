using System;

namespace Ex03_GarageLogic
{
    public class VehicleCreator
    {
        public enum eVehicles
        {
            FuelCar,
            ElectricCar,
            FuelMotorcycle,
            ElectricMotorcycle,
            Truck,
        }

        public static void CreateVehicle(eVehicles i_VehicleType, string i_LicenseNumber)
        {
            switch(i_VehicleType)
            {
                case eVehicles.FuelMotorcycle:
                    FuelMotorcycle fuelMotorcycle = new FuelMotorcycle(i_LicenseNumber);
                    //things happen.
                    break;

                case eVehicles.ElectricMotorcycle:
                    ElectricMotorcycle electricMotorcycle = new ElectricMotorcycle(i_LicenseNumber);
                    //things happen.
                    break;

                case eVehicles.FuelCar:
                    FuelCar fuelCar = new FuelCar(i_LicenseNumber);
                    //things happen.
                    break;

                case eVehicles.ElectricCar:
                    ElectricCar electricCar = new ElectricCar(i_LicenseNumber);
                    //things happen.
                    break;

                case eVehicles.Truck:
                    Truck truck = new Truck(i_LicenseNumber);
                    //things happen.
                    break;
            }
        }
    }
}
