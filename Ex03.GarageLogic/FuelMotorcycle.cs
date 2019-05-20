using System;

namespace Ex03_GarageLogic
{
    class FuelMotorcycle : Motorcycle
    {
        static eFuel s_TypeOfFuel = eFuel.Octane95;
        float m_CurrentAmountOfFuel;
        static float s_MaxAmountOfFuel = 8;

        FuelMotorcycle() : base()
        {

        }

        float M_CurrentAmountOfFuel
        {
            get
            {
                return m_CurrentAmountOfFuel;
            }
            set
            {
                this.m_CurrentAmountOfFuel = value;
            }
        }
    }
}
