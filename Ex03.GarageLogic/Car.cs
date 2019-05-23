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
        }

        public enum eColor
        {
            Red,
            Blue,
            Black,
            Gray,
        }

        public override string[] ReturnAdditionalInformationNeeded()
        {
            string[] o_AdditionalInformation = new string[2];
            o_AdditionalInformation[0] = "Enter the number of doors the car has (between 2 and 5):";
            o_AdditionalInformation[1] = "Enter the color of the car (Red, Blue, Black, Gray):";

            return o_AdditionalInformation;
        }

        public override void ParseInputToInformationNeeded(string[] i_InputInformation)
        {
            m_NumOfDoors = this.ToInt(i_InputInformation[0]);
            m_CarColor = this.ToECarColor(i_InputInformation[1]);
        }

        public eColor M_CarColor
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

        public int M_NumOfDoors
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

        protected eColor ToECarColor(string i_strColor)
        {
            eColor carColor;

            switch(i_strColor.ToLower())
            {
                case "red":
                    carColor = eColor.Red;
                    break;

                case "blue":
                    carColor = eColor.Blue;
                    break;

                case "black":
                    carColor = eColor.Black;
                    break;

                case "gray":
                    carColor = eColor.Gray;
                    break;

                default:
                    throw (new FormatException("Input invalid ! ! !\nPlease enter a color from the list!"));
            }

            return carColor;
        } 
    }
}
