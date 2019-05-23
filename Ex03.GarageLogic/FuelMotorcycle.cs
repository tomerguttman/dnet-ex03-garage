using System;

namespace Ex03_GarageLogic
{
    public class FuelMotorcycle : Motorcycle
    {
        private const eFuel k_TypeOfFuel = eFuel.Octane95;
        private const float k_MaxAmountOfFuel = 8;

        public FuelMotorcycle(string i_LicenseNumber) : base(i_LicenseNumber, k_MaxAmountOfFuel)
        {

        }

        public override eFuel ReturnFuelType()
        {
            return k_TypeOfFuel;
        }

        public override string ReturnVehicleInformation()
        {
            string vehicleInformation = string.Format(
@" Vehicle Type {0} Model Name: {1}, License Number: {2}
Tire Manufacturer: {3}, Current Tire Pressure: {4}, Max Tire Pressure {5}, Number Of Tires: {6}
Max Fuel Amount (Liters): {7}, Current Fuel Level (Liters): {8}, Current Fuel Level (Percentage): {9}
Engine Volume {10}, License Type: {11}, Fuel Type: {12}",
"Fuel Motrcycle",
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
M_LicenseType.ToString(),
ReturnFuelType().ToString());

            return vehicleInformation;
        }
    }
}
