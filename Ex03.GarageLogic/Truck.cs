using System;

namespace Ex03_GarageLogic
{
    public class Truck : Vehicle
    {
        bool m_IsHaulingDangerousMaterials;
        float m_LoadVolume;
        public const eFuel k_TypeOfFuel = eFuel.Soler;
        private const int k_NumberOfTires = 12;
        private const float k_TruckTirePressure = 26;
        private const float k_MaxAmountOfFuel = 110;


        public Truck(string i_LicenseNumber ) : base(i_LicenseNumber, k_MaxAmountOfFuel, k_NumberOfTires)
        {
        }

        public override string[] ReturnAdditionalInformationNeeded()
        {
            string[] o_AdditionalInformation = new string[2];
            o_AdditionalInformation[0] = "Is the truck hauling dangerous materials?";
            o_AdditionalInformation[1] = "Enter the load volume of the truck:";

            return o_AdditionalInformation;
        }

        public override void ParseInputToInformationNeeded(string[] i_InputInformation)
        {
            m_IsHaulingDangerousMaterials = IsHaulingDangerousMaterials(i_InputInformation[0]);
            m_LoadVolume = this.ToFloat(i_InputInformation[1]);
        }

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
                throw (new ArgumentException("Please answer 'yes' or 'no'"));
            }

            return isHaulingDangerouseMaterials;
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

        eFuel K_TypeOfFuel
        {
            get
            {
                return k_TypeOfFuel;
            }
        }
    }
}
