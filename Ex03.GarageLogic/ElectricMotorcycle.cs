using System;

namespace Ex03_GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaxHoursBatteryLife = 1.4f;

        public ElectricMotorcycle(string i_LicenseNumber) : base(i_LicenseNumber, k_MaxHoursBatteryLife)
        {
        }

        public override eFuel ReturnFuelType()
        {
            return eFuel.Electricity;
        }

        public override string ReturnVehicleInformation()
        {
            string vehicleInformation = string.Format(
@"-Vehicle Type: {0}
-Model Name: {1}
-License Number: {2}
-Tire Manufacturer: {3}
-Current Tire Pressure: {4}
-Max Tire Pressure: {5}
-Number Of Tires: {6}
-Max Battery Level In Hours: {7}
-Hours Left In Battery: {8}
-Current Battery Level (Percentage): {9}
-Engine Volume: {10}
-License Type: {11}
____________________________________________________
",
"Electric Motorcycle",
m_ModelName,
m_LicenseNumber,
m_Tires[0].M_ManufacturerName,
m_Tires[0].M_CurrentTirePressure,
m_Tires[0].M_MaxtTirePressure,
k_NumOfTires,
m_MaxAmountOfEnergy,
m_CurrentAmountOfEnergy,
m_EnergyPercentage,
M_EngineVolume,
M_LicenseType.ToString());

            return vehicleInformation;
        }
    }
}
