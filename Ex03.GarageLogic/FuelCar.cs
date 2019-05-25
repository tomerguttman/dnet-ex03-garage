namespace Ex03_GarageLogic
{
    public class FuelCar : Car
    {
        private const float k_MaxAmountOfFuel = 55;
        private const eFuel k_TypeOfFuel = eFuel.Octane96;

        public FuelCar(string i_LicenseNumber) : base(i_LicenseNumber, k_MaxAmountOfFuel)
        {
        }

        public override eFuel ReturnFuelType()
        {
            return k_TypeOfFuel;
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
-Max Fuel Amount (Liters): {7}
-Current Fuel Level (Liters): {8}
-Current Fuel Level (Percentage): {9}
-Number Of Doors: {10}
-Car Color: {11}
-Fuel Type: {12}
____________________________________________________
",
"Fuel Car",
m_ModelName,
m_LicenseNumber,
m_Tires[0].M_ManufacturerName,
m_Tires[0].M_CurrentTirePressure,
m_Tires[0].M_MaxtTirePressure,
k_NumOfTires,
m_MaxAmountOfEnergy,
m_CurrentAmountOfEnergy,
m_EnergyPercentage,
m_NumOfDoors,
m_CarColor.ToString(),
ReturnFuelType().ToString());

            return vehicleInformation;
        }
    }
}
