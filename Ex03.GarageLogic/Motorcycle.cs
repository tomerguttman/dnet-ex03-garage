using System;

namespace Ex03_GarageLogic
{
    abstract class Motorcycle : Vehicle
    {
        string m_LicenceType;
        int m_EngineVolume;
        protected static readonly int sr_NumOfTires = 2;
        protected static readonly float sr_MotorcycleTirePressure = 33;

        protected Motorcycle(): base()
        {

        }

        string M_LicenseType
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

        int M_EngineVolume
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
