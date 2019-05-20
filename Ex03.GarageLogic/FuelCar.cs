using System;

namespace Ex03_GarageLogic
{
    class FuelCar : Car
    {
        static readonly eFuel sr_TypeOfFuel = eFuel.Octane96;
        float m_CurrentAmountOfFuel;
        static readonly float sr_MaxAmountOfFuel = 55;

        FuelCar() : base()
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
