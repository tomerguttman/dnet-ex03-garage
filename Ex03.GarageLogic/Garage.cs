﻿using System;
using System.Collections.Generic;

namespace Ex03_GarageLogic
{
    public class Garage
    {
        Dictionary<string, GarageSlot> m_MyGarage = new Dictionary<string, GarageSlot>();

        public void AddVehicleToTheGarage(GarageSlot i_NewGarageSlot)
        {
            m_MyGarage.Add(i_NewGarageSlot.M_Vehicle.M_LicenseNumber, i_NewGarageSlot);
        }

        public bool RemoveVehicleFromTheGarage(GarageSlot i_GarageSlotToRemove)
        {
           return m_MyGarage.Remove(i_GarageSlotToRemove.M_Vehicle.M_LicenseNumber);
        }

        public List<string> CreateListByVehicleStatus(GarageSlot.eGarageStatus i_FilterStatus)
        {
            List<string> o_FilteredVehicles = new List<string>();
            foreach (KeyValuePair<string, GarageSlot> garageSlot in m_MyGarage)
            {
                if(garageSlot.Value.M_CurrentStatus == i_FilterStatus)
                {
                    o_FilteredVehicles.Add(garageSlot.Value.M_Vehicle.M_LicenseNumber);
                }
            }

            return o_FilteredVehicles;
        }

        public Dictionary<string, GarageSlot> M_MyGarage
        {
            get
            {
                return m_MyGarage;
            }
        }
    }
}
