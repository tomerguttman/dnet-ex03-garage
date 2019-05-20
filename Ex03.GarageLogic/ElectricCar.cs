using System;

namespace Ex03_GarageLogic
{
    class ElectricCar : Car
    {
        float m_BatteryHoursRemaining;
        static readonly float sr_MaxHoursBatteryLife = 1.8f;

        ElectricCar() : base()
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
