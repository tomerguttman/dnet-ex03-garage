using System;

namespace Ex03_GarageLogic
{
    class Truck : Vehicle
    {
        bool m_IsHaulingDangerousMaterials;
        float m_LoadVolume;
        static readonly int sr_NumberOfTires = 12;
        static readonly float sr_TruckTirePressure = 26;

        Truck() : base()
        {

        }

        bool M_IsHaulingDangerousMaterials
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

        float M_LoadVolume
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
    }
}
