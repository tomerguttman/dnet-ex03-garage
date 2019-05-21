using System;

namespace Ex03_GarageLogic
{
    abstract class Car : Vehicle
    {
        protected eColor m_CarColor;
        protected int m_NumOfDoors;
        protected const int k_NumOfTires = 4;
        protected const float k_CarTirePressure = 31;

        protected Car(string i_LicenseNumber, float i_MaxAmountOfEnergy) : base(i_LicenseNumber, i_MaxAmountOfEnergy, k_NumOfTires)
        {
            ///remember to enter m_CurrentAmountOfFuel using set method.
        }

        public enum eColor
        {
            Red,
            Blue,
            Black,
            Gray,
        }

        eColor M_CarColor { get; set; }

        int M_NumOfDoors { get; set; }
    }
}
