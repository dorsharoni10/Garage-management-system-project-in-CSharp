using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A,
            A1,
            A2,
            B
        }

        private eLicenseType m_eLicense;
        private int m_EngineCapacityIncc;
        private float m_MaxFuelOrElectic;
        private string m_fuelt;

        /// Driving on fuel
        public Motorcycle(eLicenseType i_eLicense, int i_EngineCapacityIncc, string i_ModelName, string i_LicenseNumber, float i_PercentageOfVehicleEnergy, float i_CurrentFuel, string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure)
            : base(i_ModelName, i_LicenseNumber, i_PercentageOfVehicleEnergy)
        {
            this.m_eLicense = i_eLicense;
            this.EngineCapacityIncc = i_EngineCapacityIncc;
            this.m_MaxFuelOrElectic = 8f;
            FuelVehicle.eFueltType eFueltType = FuelVehicle.eFueltType.Octan95;
            VehicleDrivingOnFuel = new FuelVehicle(i_CurrentFuel, m_MaxFuelOrElectic, eFueltType);
            Wheels = new Wheel(i_WheelsManufacturerName, i_WheelsCurrentAirPressure, 33, 2);
            m_fuelt = ", fuelt type: " + eFueltType;
        }

        /// Electric Driving
        public Motorcycle(int i_EngineCapacityIncc, string i_ModelName, string i_LicenseNumber, float i_PercentageOfVehicleEnergy, float i_TimeRemainingBattey, eLicenseType i_eLicense, string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure) 
            : base(i_ModelName, i_LicenseNumber, i_PercentageOfVehicleEnergy)
        {
            this.m_eLicense = i_eLicense;
            this.EngineCapacityIncc = i_EngineCapacityIncc;
            this.m_MaxFuelOrElectic = 1.4f;
            ElectricVehicle = new ElectricVehicle(i_TimeRemainingBattey, m_MaxFuelOrElectic);
            Wheels = new Wheel(i_WheelsManufacturerName, i_WheelsCurrentAirPressure, 33, 2);
        }

        public eLicenseType License { get => m_eLicense; }

        public int EngineCapacityIncc { get => m_EngineCapacityIncc; set => m_EngineCapacityIncc = value; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(base.ToString());
            if (this.VehicleDrivingOnFuel is FuelVehicle)
            {
                stringBuilder.Append(", Percentage of vehicle energy: " + Garage.CalculatePercentageOfEnergy(8f, VehicleDrivingOnFuel.CurrentFuel));
            }
            else
            {
                stringBuilder.Append(", Percentage of vehicle energy: " + Garage.CalculatePercentageOfEnergy(1.4f, ElectricVehicle.TimeRemainingBattery));
            }

            stringBuilder.Append(", elicense type: " + m_eLicense);
            stringBuilder.Append(", Engine capacityIn cc: " + EngineCapacityIncc);
            stringBuilder.Append(", " + Wheels.ToString());
            stringBuilder.Append(m_fuelt);
            return stringBuilder.ToString();
        } 
    }
}
