using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eVehicleColor
        {
            Red,
            Blue,
            Black,
            Gray
        }

        public enum eQuantityOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        private eVehicleColor m_eColor;
        private eQuantityOfDoors m_eQuantityOfDoors;
        private float m_MaxFuelOrMaxTimeBattery;
        private string m_fuelt;

        //// Driving on fuel
        public Car(eVehicleColor i_eVehicleColor, string i_ModelName, string i_LicenseNumber, float i_PercentageOfVehicleEnergy, float i_CurrentFuel, string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure)
           : base(i_ModelName, i_LicenseNumber, i_PercentageOfVehicleEnergy)
        {
            this.m_eColor = i_eVehicleColor; 
            this.m_eQuantityOfDoors = eQuantityOfDoors.Four;
            FuelVehicle.eFueltType eFueltType  = FuelVehicle.eFueltType.Octan96;
            this.m_MaxFuelOrMaxTimeBattery = 55f;
            VehicleDrivingOnFuel = new FuelVehicle(i_CurrentFuel, m_MaxFuelOrMaxTimeBattery, eFueltType);
            Wheels = new Wheel(i_WheelsManufacturerName, i_WheelsCurrentAirPressure, 31, 4);
            m_fuelt = ", fuelt type: " + eFueltType;
        }

        /// Electring Driving
        public Car(string i_ModelName, string i_LicenseNumber, float i_PercentageOfVehicleEnergy, float i_TimeRemainingBattey, eVehicleColor i_eVehicleColor, string i_WheelsManufacturerName, float WheelsCurrentAirPressure)
            : base(i_ModelName, i_LicenseNumber, i_PercentageOfVehicleEnergy)
        {
            this.m_eColor = i_eVehicleColor;
            this.m_eQuantityOfDoors = eQuantityOfDoors.Four;
            this.m_MaxFuelOrMaxTimeBattery = 1.8f;
            ElectricVehicle = new ElectricVehicle(i_TimeRemainingBattey, m_MaxFuelOrMaxTimeBattery);
            Wheels = new Wheel(i_WheelsManufacturerName, WheelsCurrentAirPressure, 31, 4);
        }

        public eVehicleColor EColor { get => m_eColor; set => m_eColor = value; }

        public eQuantityOfDoors EQuantityOfDoors { get => m_eQuantityOfDoors; set => m_eQuantityOfDoors = value; }

        public float MaxFuelOrMaxTimeBattery { get => m_MaxFuelOrMaxTimeBattery; set => m_MaxFuelOrMaxTimeBattery = value; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(base.ToString());
            if (this.VehicleDrivingOnFuel is FuelVehicle)
            {
                stringBuilder.Append(", Percentage of vehicle energy: " + Garage.CalculatePercentageOfEnergy(55f, VehicleDrivingOnFuel.CurrentFuel));
            }
            else
            {
                stringBuilder.Append(", Percentage of vehicle energy: " + Garage.CalculatePercentageOfEnergy(1.8f, ElectricVehicle.TimeRemainingBattery));
            }

            stringBuilder.Append(", color: " + EColor);       
            stringBuilder.Append(", " + Wheels.ToString());
            stringBuilder.Append(m_fuelt);
            return stringBuilder.ToString();
        }
    }
}
