using System;

namespace Ex03_GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        string m_LicenceType;
        int m_EngineVolume;
        protected const int k_NumOfTires = 2;
        protected const float k_MotorcycleTirePressure = 33;

        //protected motorcycle(string i_licensetype, int i_enginevolume, string i_licensenumber, float i_maxamountofenergy) : base(i_licensenumber, i_maxamountofenergy, k_numoftires)
        //{
        //    m_licencetype = i_licensenumber;
        //    m_enginevolume = i_enginevolume;
        //}

        protected Motorcycle(string i_LicenseNumber, float i_MaxAmountOfEnergy) : base(i_LicenseNumber, i_MaxAmountOfEnergy, k_NumOfTires) { }

        string M_LicenseType { get; set; }

        int M_EngineVolume { get; set; }
    }
}
