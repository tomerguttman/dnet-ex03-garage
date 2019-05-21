using System;

namespace Ex03_GarageLogic
{
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
    }
}
