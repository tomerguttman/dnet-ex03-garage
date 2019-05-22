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
    }
}