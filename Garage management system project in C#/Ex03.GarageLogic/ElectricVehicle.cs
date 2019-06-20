using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricVehicle
    {
        private float m_TimeRemainingBattery;
        private float m_MaxTimeBattery;
        
        public ElectricVehicle(float i_TimeRemainingBattery, float i_MaxTimeBattery)
        {
            this.m_MaxTimeBattery = i_MaxTimeBattery;
            this.TimeRemainingBattery = i_TimeRemainingBattery;
        }

       public void ChargingAbattery(float i_HourTimeToChargeBattery)
        {
            float tempHourTimeToChargeBattery = i_HourTimeToChargeBattery + TimeRemainingBattery;

            if (tempHourTimeToChargeBattery <= MaxTimeBattery) 
            {
                TimeRemainingBattery = tempHourTimeToChargeBattery;
            }
            else
            {
                throw new ValueOutOfRangeException("You tried to charge the battery too long", 0, MaxTimeBattery);
            }
        }

        public float MaxTimeBattery { get => m_MaxTimeBattery; }

        public float TimeRemainingBattery { get => m_TimeRemainingBattery; set => m_TimeRemainingBattery = value; }
    }
}
