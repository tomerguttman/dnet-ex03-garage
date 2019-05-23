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

        protected Vehicle(string i_LicenseNumber, float i_MaxAmountOfEnergy, int i_NumOfTires)
        {
            m_LicenseNumber = i_LicenseNumber;
            M_MaxAmountOfEnergy = i_MaxAmountOfEnergy;
            m_Tires = new Tire[i_NumOfTires];
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
                try
                {
                    tire.InflateTire(i_AmountOfPressureToAdd);
                }
                catch (ValueOutOfRangeException exception)
                {
                    System.Console.WriteLine(exception.Message);
                    break;
                }
            }
        }

        public void RefillEnergySource(float i_AmountOfEnergySourceToAdd)
        {
            if(i_AmountOfEnergySourceToAdd + m_CurrentAmountOfEnergy > m_MaxAmountOfEnergy )
            {
                throw (new ValueOutOfRangeException(m_MaxAmountOfEnergy, 0, "The amount that was entered is too much for this vehicle ! ! !"));  
            }
            else
            {
                m_CurrentAmountOfEnergy += i_AmountOfEnergySourceToAdd;
            }
        }

        abstract public string[] ReturnAdditionalInformationNeeded();

        abstract public void ParseInputToInformationNeeded(string[] i_InputInformation);

        public int ToInt(string i_StrToParse)
        {
            int o_OutputInt = 0;
            bool didParseSucceed = int.TryParse(i_StrToParse, out o_OutputInt);

            if (didParseSucceed == false)
            {
                throw (new FormatException("Invalid input ! ! !"));
            }

            return o_OutputInt;
        }

        public float ToFloat(string i_StrToParse)
        {
            float o_OutputFloat = 0f;
            bool didParseSucceed = float.TryParse(i_StrToParse, out o_OutputFloat);

            if (didParseSucceed == false)
            {
                throw (new FormatException("Invalid input ! ! !"));
            }

            return o_OutputFloat;
        }

        public bool IsParameterIsWithinRange(float i_MaxParam, float i_MinParam, float i_ValueToCheck)
        {
            if (i_ValueToCheck > i_MaxParam || i_ValueToCheck < i_MinParam)
            {
                throw (new ValueOutOfRangeException(i_MaxParam, i_MinParam, string.Format("Please choose from the range {0}-{1} ! ! !", i_MinParam, i_MaxParam)));
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
        }

        public void UpdateEnergySource(string i_CurrentAmountOfEnergy)
        {
            float currentAmountOfEnergy = ToFloat(i_CurrentAmountOfEnergy);

            if (IsParameterIsWithinRange(m_MaxAmountOfEnergy, 0, currentAmountOfEnergy))
            {
                m_CurrentAmountOfEnergy = currentAmountOfEnergy;
            }
        }

        public class Tire
        {
            string m_ManufacturerName;
            float m_CurrentTirePressure;
            float m_MaxTirePressure;

            string M_ManufacturerName
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

            float M_CurrentTirePressure
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

            public void InflateTire(float i_AmountOfPressureToAdd)
            {
                if (i_AmountOfPressureToAdd + m_CurrentTirePressure > m_MaxTirePressure)
                {
                    throw (new ValueOutOfRangeException(m_MaxTirePressure, 0, "The tire can't hold that much pressure ! ! !"));
                }
                else
                {
                    m_CurrentTirePressure += i_AmountOfPressureToAdd;
                }
            }
        }
    }
}