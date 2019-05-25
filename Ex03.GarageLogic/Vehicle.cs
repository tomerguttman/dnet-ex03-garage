using System;

namespace Ex03_GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected float m_EnergyPercentage;
        protected float m_MaxAmountOfEnergy;
        protected float m_CurrentAmountOfEnergy;
        protected Tire[] m_Tires;

        public static int ToInt(string i_StrToParse)
        {
            int o_OutputInt = 0;
            bool didParseSucceed = int.TryParse(i_StrToParse, out o_OutputInt);

            if (didParseSucceed == false)
            {
                throw new FormatException("Invalid input ! ! ! input must be an integer number.");
            }

            return o_OutputInt;
        }

        public static float ToFloat(string i_StrToParse)
        {
            float o_OutputFloat = 0f;
            bool didParseSucceed = float.TryParse(i_StrToParse, out o_OutputFloat);

            if (didParseSucceed == false)
            {
                throw new FormatException("Invalid input ! ! !");
            }

            return o_OutputFloat;
        }

        protected Vehicle(string i_LicenseNumber, float i_MaxAmountOfEnergy, int i_NumOfTires, float i_MaxTirePressure)
        {
            m_LicenseNumber = i_LicenseNumber;
            m_MaxAmountOfEnergy = i_MaxAmountOfEnergy;
            m_Tires = new Tire[i_NumOfTires];

            for (int i = 0; i < i_NumOfTires; i++)
            {
                m_Tires[i] = new Tire(i_MaxTirePressure);
            }
        }

        public string M_ModelName
        {
            get
            {
                return m_ModelName;
            }

            set
            {
                this.m_ModelName = value;
            }
        }

        public string M_LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }

            set
            {
                this.m_LicenseNumber = value;
            }
        }

        public float M_EnergyPercentage
        {
            get
            {
                return m_EnergyPercentage;
            }

            set
            {
                this.m_EnergyPercentage = value;
            }
        }

        public float M_CurrentAmountOfEnergy
        {
            get
            {
                return m_CurrentAmountOfEnergy;
            }

            set
            {
                this.m_CurrentAmountOfEnergy = value;
            }
        }

        public float M_MaxAmountOfEnergy
        {
            get
            {
                return m_MaxAmountOfEnergy;
            }

            set
            {
                this.m_MaxAmountOfEnergy = value;
            }
        }

        public void InflateAllTires(float i_AmountOfPressureToAdd)
        {
            foreach (Tire tire in m_Tires)
            {
                tire.InflateTire(i_AmountOfPressureToAdd);
            }
        }

        public void RefillEnergySource(float i_AmountOfEnergySourceToAdd)
        {
            if(i_AmountOfEnergySourceToAdd + m_CurrentAmountOfEnergy > m_MaxAmountOfEnergy )
            {
                if (this.GetType().ToString().ToLower().Contains("electric"))
                {
                    throw new ValueOutOfRangeException(m_MaxAmountOfEnergy, 0, string.Format("The amount that was entered is too much for this vehicle ! ! ! you can only add up to {0} minutes.", (m_MaxAmountOfEnergy - m_CurrentAmountOfEnergy) * 60));
                }
                else
                {
                    throw new ValueOutOfRangeException(m_MaxAmountOfEnergy, 0, string.Format("The amount that was entered is too much for this vehicle ! ! ! you can only add up to {0}L.", m_MaxAmountOfEnergy - m_CurrentAmountOfEnergy));
                }
            }
            else
            {
                m_CurrentAmountOfEnergy += i_AmountOfEnergySourceToAdd;
                m_EnergyPercentage = (m_CurrentAmountOfEnergy / m_MaxAmountOfEnergy) * 100;
            }
        }

        public abstract string[] ReturnAdditionalInformationNeeded();

        public abstract void ParseFirstInputToInformationNeeded(string i_FirstInputInformation);

        public abstract void ParseSecondInputToInformationNeeded(string i_SecondInputInformation);

        public bool IsParameterIsWithinRange(float i_MaxParam, float i_MinParam, float i_ValueToCheck)
        {
            if (i_ValueToCheck > i_MaxParam || i_ValueToCheck < i_MinParam)
            {
                throw new ValueOutOfRangeException(i_MaxParam, i_MinParam, string.Format("Please choose from the range {0}-{1} ! ! !", i_MinParam, i_MaxParam));
            }

            return true;
        }

        public Tire[] M_Tires
        {
            get
            {
                return m_Tires;
            }

            set
            {
                this.m_Tires = value;
            }
        }

        public enum eFuel
        {
            Octane95,
            Octane96,
            Octane98,
            Soler,
            Electricity,
        }

        public void UpdateEnergySource(string i_CurrentAmountOfEnergy)
        {
            float currentAmountOfEnergy = ToFloat(i_CurrentAmountOfEnergy);

            if (IsParameterIsWithinRange(m_MaxAmountOfEnergy, 0, currentAmountOfEnergy))
            {
                m_CurrentAmountOfEnergy = currentAmountOfEnergy;
                m_EnergyPercentage = (m_CurrentAmountOfEnergy / m_MaxAmountOfEnergy) * 100;
            }
        }

        public abstract eFuel ReturnFuelType();

        public eFuel ToEFuel(string i_strFuelInput)
        {
            eFuel fuelType;

            switch (i_strFuelInput.ToLower())
            {
                case "octane95":
                    fuelType = eFuel.Octane95;
                    break;

                case "octane96":
                    fuelType = eFuel.Octane96;
                    break;

                case "octane98":
                    fuelType = eFuel.Octane98;
                    break;

                case "soler":
                    fuelType = eFuel.Soler;
                    break;

                default:
                    throw new FormatException("Input invalid ! ! !\nPlease enter a fuel type from the list!");
            }

            return fuelType;
        }

        public abstract string ReturnVehicleInformation();

        public class Tire
        {
            private string m_ManufacturerName;
            private float m_CurrentTirePressure;
            private float m_MaxTirePressure;

            public Tire(float i_MaxTirePressure)
            {
                m_MaxTirePressure = i_MaxTirePressure;
                m_ManufacturerName = null;
                m_CurrentTirePressure = 0;
            }

            public string M_ManufacturerName
            {
                get
                {
                    return m_ManufacturerName;
                }

                set
                {
                    this.m_ManufacturerName = value;
                }
            }

            public float M_CurrentTirePressure
            {
                get
                {
                    return m_CurrentTirePressure;
                }

                set
                {
                    this.m_CurrentTirePressure = value;
                }
            }

            public float M_MaxtTirePressure
            {
                get
                {
                    return m_MaxTirePressure;
                }

                set
                {
                    this.m_MaxTirePressure = value;
                }
            }

            public void InflateTire(float i_AmountOfPressureToAdd)
            {
                if (i_AmountOfPressureToAdd + m_CurrentTirePressure > m_MaxTirePressure)
                {
                    throw new ValueOutOfRangeException(m_MaxTirePressure, 0, string.Format("The tires can't hold that much pressure ! ! ! there's only {0} psi left to fill.", m_MaxTirePressure - m_CurrentTirePressure));
                }
                else
                {
                    m_CurrentTirePressure += i_AmountOfPressureToAdd;
                }
            }

            public bool IsTirePressureWithinRange(string i_StrInputCurrentTirePressure)
            {
                bool o_IsTirePressureWithinRange = false;
                float inputCurrentTirePressure = ToFloat(i_StrInputCurrentTirePressure);

                if (inputCurrentTirePressure >= 0 && inputCurrentTirePressure <= m_MaxTirePressure)
                {
                    o_IsTirePressureWithinRange = true;
                }
                else
                {
                    throw new ValueOutOfRangeException(m_MaxTirePressure, 0, string.Format("Invalid input ! ! ! Please enter a pressure between 0 and {0}", m_MaxTirePressure));
                }

                return o_IsTirePressureWithinRange;
            }
        }
    }
}