using System;

namespace Ex03_GarageLogic
{
    public class Truck : Vehicle
    {
        private const int k_NumOfTires = 12;
        private const float k_TruckTirePressure = 26;
        private const float k_MaxAmountOfFuel = 110;
        private bool m_IsHaulingDangerousMaterials;
        private float m_LoadVolume;
        public const eFuel k_TypeOfFuel = eFuel.Soler;

        public static bool IsHaulingDangerousMaterials(string i_InputAnswer)
        {
            bool isHaulingDangerouseMaterials = false;

            if (i_InputAnswer.ToLower().Equals("yes"))
            {
                isHaulingDangerouseMaterials = true;
            }
            else if (i_InputAnswer.ToLower().Equals("no"))
            {
                isHaulingDangerouseMaterials = false;
            }
            else
            {
                throw new ArgumentException("Please answer 'yes' or 'no'");
            }

            return isHaulingDangerouseMaterials;
        }

        public Truck(string i_LicenseNumber ) : base(i_LicenseNumber, k_MaxAmountOfFuel, k_NumOfTires, k_TruckTirePressure)
        {
        }

        public override string[] ReturnAdditionalInformationNeeded()
        {
            string[] o_AdditionalInformation = new string[2];
            o_AdditionalInformation[0] = "Is the truck hauling dangerous materials?";
            o_AdditionalInformation[1] = "Enter the load volume of the truck:";

            return o_AdditionalInformation;
        }

        public override void ParseFirstInputToInformationNeeded(string i_FirstInputInformation)
        {
            m_IsHaulingDangerousMaterials = IsHaulingDangerousMaterials(i_FirstInputInformation);
        }

        public override void ParseSecondInputToInformationNeeded(string i_SecondInputInformation)
        {
            m_LoadVolume = ToFloat(i_SecondInputInformation);
        }

        public float M_LoadVolume
        {
            get
            {
                return m_LoadVolume;
            }

            set
            {
                this.m_LoadVolume = value;
            }
        }

        public bool M_IsHaulingDangerousMaterials
        {
            get
            {
                return m_IsHaulingDangerousMaterials;
            }

            set
            {
                this.m_IsHaulingDangerousMaterials = value;
            }
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
-Load Volume: {10}
-Is Hauling dangerous materials: {11}
-Fuel Type: {12}
____________________________________________________
",
"Truck",
m_ModelName,
m_LicenseNumber,
m_Tires[0].M_ManufacturerName,
m_Tires[0].M_CurrentTirePressure,
m_Tires[0].M_MaxtTirePressure,
k_NumOfTires,
m_MaxAmountOfEnergy,
m_CurrentAmountOfEnergy,
m_EnergyPercentage,
m_LoadVolume,
m_IsHaulingDangerousMaterials,
ReturnFuelType().ToString());

            return vehicleInformation;
        }
    }
}
