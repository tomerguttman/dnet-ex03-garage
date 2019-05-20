using System;

namespace Ex03_GarageLogic
{
    abstract class Car : Vehicle
    {
        protected eColor m_CarColor;
        protected int m_NumOfDoors;
        protected static readonly int sr_NumOfTires = 4;
        protected static readonly float sr_CarTirePressure = 31;

        protected Car() : base()
        {

        }

        protected enum eColor
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
    }
}
