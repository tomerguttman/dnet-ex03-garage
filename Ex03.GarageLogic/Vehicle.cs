using System;

namespace Ex03_GarageLogic
{
    abstract class Vehicle 
    {
        string m_ModelName;
        string m_LicenceNumber;
        float m_EnergyPercentage;
        Tire[] m_Tires;

        protected Vehicle()
        {

        }

        string M_ModelName
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

        string M_LicenseNumber
        {
            get
            {
                return m_LicenceNumber;
            }
            set
            {
                this.m_LicenceNumber = value;
            }
        }

        float M_EnergyPercentage
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

        Tire[] M_Tires
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

     internal enum eFuel
    {
        Octane95,
        Octane96,
        Octane98,
        Soler,
    }

    }
}