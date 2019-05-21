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


        abstract public string M_ModelName { get; set; }

        abstract public string M_LicenseNumber { get; set; }

        abstract public float M_EnergyPercentage { get; set; }

        abstract public float M_CurrentAmountOfEnergy { get; set; }

        abstract public float M_MaxAmountOfEnergy { get; set; }

        abstract public Tire[] M_Tires { get; set; }

        public enum eFuel
        {
            Octane95,
            Octane96,
            Octane98,
            Soler,
        }

    }
}