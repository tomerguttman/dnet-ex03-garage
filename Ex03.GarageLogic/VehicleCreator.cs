﻿using System;
using System.Collections.Generic;

namespace Ex03_GarageLogic
{
    public class VehicleCreator
    {
        public static List<eVehicles> m_VehicleTypes = new List<eVehicles>();

        public enum eVehicles
        {
            ElectricCar,
            ElectricMotorcycle,
            FuelCar,
            FuelMotorcycle,
            Truck,
        }

        public static void InitializeVehicleTypeList()
        {
            for(eVehicles vehicleType = eVehicles.ElectricCar; vehicleType <= eVehicles.Truck; vehicleType++)
            {
                m_VehicleTypes.Add(vehicleType);
            }
        }

        public static Vehicle CreateVehicle(eVehicles i_VehicleType, string i_LicenseNumber)
        {
            Vehicle newVehicle = null;
            
            switch(i_VehicleType)
            {
                case eVehicles.FuelMotorcycle:
                    newVehicle = new FuelMotorcycle(i_LicenseNumber);

                    break;

                case eVehicles.ElectricMotorcycle:
                    newVehicle = new ElectricMotorcycle(i_LicenseNumber);
                    break;

                case eVehicles.FuelCar:
                    newVehicle = new FuelCar(i_LicenseNumber);
                    break;

                case eVehicles.ElectricCar:
                    newVehicle = new ElectricCar(i_LicenseNumber);
                    break;

                case eVehicles.Truck:
                    newVehicle = new Truck(i_LicenseNumber);
                    break;
            }

            return newVehicle;
        }

        public static eVehicles ToEVehicle(string i_ToConvert)
        {
            eVehicles vehicleType;

            switch(i_ToConvert)
            {
                case "1":
                    vehicleType = eVehicles.ElectricCar;
                    break;

                case "2":
                    vehicleType = eVehicles.ElectricMotorcycle;
                    break;

                case "3":
                    vehicleType = eVehicles.FuelCar;
                    break;

                case "4":
                    vehicleType = eVehicles.FuelMotorcycle;
                    break;

                case "5":
                    vehicleType = eVehicles.Truck;
                    break;
                default:
                    throw new ArgumentException("Invalid choice ! ! !\nPlease enter a type from the list!");
            }

            return vehicleType;
        }
    }
}
