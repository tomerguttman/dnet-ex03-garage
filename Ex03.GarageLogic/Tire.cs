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

        public void InflateTire(float i_AmountOfPressureToAdd)
        {
            if(i_AmountOfPressureToAdd + m_CurrentTirePressure > m_MaxTirePressure)
            {
                throw (new ValueOutOfRangeException(m_MaxTirePressure, 0, "The tire can't hold that much pressure ! ! !"));
            }
            else
            {
                m_CurrentTirePressure += i_AmountOfPressureToAdd;
            }
        }
    }
}
