using System;

namespace Ex03_GarageLogic
{
    public abstract class Car : Vehicle
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

        eColor M_CarColor
        {
            get
            {
                return m_CarColor;
            }
            set
            {
                this.m_CarColor = value;
            }
        }

        int M_NumOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }
            set
            {
                this.m_NumOfDoors = value;
            }
        }

        public static eColor ToECarColor(string i_strColor)
        {
            eColor carColor;

            switch(i_strColor)
            {
                case "Red":
                    carColor = eColor.Red;
                    break;

                case "Blue":
                    carColor = eColor.Blue;
                    break;

                case "Black":
                    carColor = eColor.Black;
                    break;

                case "Gray":
                    carColor = eColor.Gray;
                    break;

                default:
                    throw (new FormatException("Input invalid ! ! !"));
            }

            return carColor;
        } 
    }
}
