using System;

namespace Ex03_GarageLogic
{
    public class GarageSlot
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eGarageStatus m_CurrentStatus;
        private Vehicle m_Vehicle = null;

        public GarageSlot(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_Vehicle = i_vehicle;
            m_CurrentStatus = eGarageStatus.BeingFixed;
        }

        public enum eGarageStatus
        {
            BeingFixed,
            Ready,
            PaidFor,
        }

        public string M_OwnerName
        {
            get
            {
                return m_OwnerName;
            }
            set
            {
                this.m_OwnerName = value;
            }
        }

        public string M_OwnerPhoneNumber
        {
            get
            {
                return M_OwnerPhoneNumber;
            }
            set
            {
                this.m_OwnerPhoneNumber = value;
            }
        }

        public eGarageStatus M_CurrentStatus
        {
            get
            {
                return m_CurrentStatus;
            }
            set
            {
                this.m_CurrentStatus = value;
            }
        }

        public Vehicle M_Vehicle
        {
            get
            {
                return m_Vehicle;
            }
            set
            {
                this.m_Vehicle = value;
            }
        }

        public void InflateTires(float i_AmountOfPressureToAdd)
        {
            m_Vehicle.InflateAllTires(i_AmountOfPressureToAdd);
        }
        
        public void RefillEnergySource(float i_AmountOfEnergySourceToAdd)
        {
            m_Vehicle.RefillEnergySource(i_AmountOfEnergySourceToAdd);
        }

        public void UpdateVehicleStatus(eGarageStatus i_NewVehicleStatus)
        {
            m_CurrentStatus = i_NewVehicleStatus;
        }

        public static eGarageStatus ToEGarageStatus(string i_stringVehicleStatus)
        {
            eGarageStatus vehicleStatus;

            switch (i_stringVehicleStatus)
            {
                case "1":
                    vehicleStatus = eGarageStatus.BeingFixed;
                    break;

                case "2":
                    vehicleStatus = eGarageStatus.Ready;
                    break;

                case "3":
                    vehicleStatus = eGarageStatus.PaidFor;
                    break;

                default:
                    throw (new FormatException("Input invalid ! ! ! please enter a vehicle status from the given options ! ! !"));
            }

            return vehicleStatus;
        }

        public bool IsFuelTypeCorrect(string i_StrInputFuelType)
        {
            if(m_Vehicle.ReturnFuelType() == m_Vehicle.ToEFuel(i_StrInputFuelType) == false)
            {
                throw (new ArgumentException(string.Format("The fuel type you entered does not match the vehicle's ! ! ! The fuel type need is {0}",m_Vehicle.ReturnFuelType().ToString())));
            }

            return true;
        }

        public string ReturnGarageSlotInformation()
        {
            string o_GarageSlotInformation = string.Format(
@"________________The_Requested_Vehicle________________

Name: {0}    Phone Number: {1}    Vehicle Status: {2}

", m_OwnerName, m_OwnerPhoneNumber, m_CurrentStatus);

            return o_GarageSlotInformation;
        }
    }
}
