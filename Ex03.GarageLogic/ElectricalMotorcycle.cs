using System;

namespace Ex03_GarageLogic
{
    class ElectricalMotorcycle : Motorcycle
    {
        float m_BatteryHoursRemaining;
        static readonly float sr_MaxHoursBatteryLife = 1.4f;

        ElectricalMotorcycle() : base()
        {

        }

        float M_BatteryHoursRemaining
        {
            get
            {
                return m_BatteryHoursRemaining;
            }
            set
            {
                this.m_BatteryHoursRemaining = value;
            }
        }
    }
}
