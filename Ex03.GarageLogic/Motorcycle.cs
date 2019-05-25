using System;

namespace Ex03_GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        eLicenseType m_LicenceType;
        int m_EngineVolume;
        protected const int k_NumOfTires = 2;
        protected const float k_MotorcycleTirePressure = 33; 

        protected Motorcycle(string i_LicenseNumber, float i_MaxAmountOfEnergy) : base(i_LicenseNumber, i_MaxAmountOfEnergy, k_NumOfTires, k_MotorcycleTirePressure) { }

        public override string[] ReturnAdditionalInformationNeeded()
        {
            string[] o_AdditionalInformation = new string[2];
            o_AdditionalInformation[0] = "Enter the license type (A, A1, A2, B):";
            o_AdditionalInformation[1] = "Enter the engine volume of the motorcycle:";

            return o_AdditionalInformation;
        }

        public override void ParseFirstInputToInformationNeeded(string i_FirstInputInformation)
        {
            m_LicenceType = this.ReturnLicenseTypeIfValid(i_FirstInputInformation);
        }

        public override void ParseSecondInputToInformationNeeded(string i_SecondInputInformation)
        {
            m_EngineVolume = ToInt(i_SecondInputInformation);
        }

        protected eLicenseType ReturnLicenseTypeIfValid(string i_StrInputLicenseType)
        {
            eLicenseType o_LicenseType;

            switch (i_StrInputLicenseType.ToLower())
            {
                case "a":
                    o_LicenseType = eLicenseType.A;
                    break;

                case "a1":
                    o_LicenseType = eLicenseType.A1;
                    break;

                case "a2":
                    o_LicenseType = eLicenseType.A2;
                    break;

                case "b":
                    o_LicenseType = eLicenseType.B; ;
                    break;

                default:
                    throw (new ArgumentException("Please Choose one of the given license types ! ! !"));
            }

            return o_LicenseType;
        }

        public enum eLicenseType
        {
            A,
            A1,
            A2,
            B,
        }

        public eLicenseType M_LicenseType
        {
            get
            {
                return m_LicenceType;
            }
            set
            {
                this.m_LicenceType = value;
            }
        }

        public int M_EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
            set
            {
                this.m_EngineVolume = value;
            }
        }
    }
}

