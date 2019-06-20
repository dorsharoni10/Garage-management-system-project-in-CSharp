using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaximumAirPressure;
        private int m_numbersOfWheels;

        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressure, int i_numberOfWheels)
        {
            this.ManufacturerName = i_ManufacturerName;
            this.CurrentAirPressure = i_CurrentAirPressure;
            this.MaximumAirPressure = i_MaximumAirPressure;
            this.NumbersOfWheels = i_numberOfWheels;
        }

        public string ManufacturerName { get => m_ManufacturerName; set => m_ManufacturerName = value; }

        public float CurrentAirPressure { get => m_CurrentAirPressure; set => m_CurrentAirPressure = value; }

        public float MaximumAirPressure { get => m_MaximumAirPressure; set => m_MaximumAirPressure = value; }

        public int NumbersOfWheels { get => m_numbersOfWheels; set => m_numbersOfWheels = value; }

        public void WheelInflating(float i_AddAirPressure)
        {
            float tempCurrentAirPressure = i_AddAirPressure + CurrentAirPressure;
            if(tempCurrentAirPressure <= MaximumAirPressure)
            {
                this.CurrentAirPressure = tempCurrentAirPressure; 
            }
            else
            {
                throw new Exception();
            }
        }

        public override string ToString()
        {
            return "wheels manufacture name: " + ManufacturerName + " wheels current air pressure: " + CurrentAirPressure;
        }
    }
}
