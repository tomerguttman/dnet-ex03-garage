using System;

namespace Ex03_GarageLogic
{
    class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaxHoursBatteryLife = 1.4f;

        public ElectricMotorcycle(string i_LicenseNumber) : base(i_LicenseNumber, k_MaxHoursBatteryLife)
        {
            
        }

        public override string M_ModelName
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

        public override string M_LicenseNumber
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

        public override float M_EnergyPercentage
        {
            get
            {
                return m_EnergyPercentage;
            }
            set
            {
                this.m_EnergyPercentage = (m_CurrentAmountOfEnergy / m_MaxAmountOfEnergy) * 100;
            }
        }

        public override float M_CurrentAmountOfEnergy
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

        public override float M_MaxAmountOfEnergy
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

        public override Tire[] M_Tires
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
    }
}
