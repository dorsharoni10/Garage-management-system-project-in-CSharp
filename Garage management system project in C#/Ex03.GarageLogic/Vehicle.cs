using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_PercentageOfVehicleEnergy;
        private Wheel m_Wheels;
        private Garage.eVehicleConditionInTheGarage m_eVehicleCondition;
        private FuelVehicle m_VehicleDrivingOnFuel;
        private ElectricVehicle m_ElectricVehicle;
        private FuelVehicle.eFueltType m_eFueltType;
        private Garage m_Garage = new Garage();

        public Vehicle(string i_ModelName, string i_LicenseNumber, float i_PercentageOfVehicleEnergy)
        {
            this.ModelName = i_ModelName;
            this.LicenseNumber = i_LicenseNumber;
            this.PercentageOfVehicleEnergy = i_PercentageOfVehicleEnergy;
            this.EVehicleCondition = Garage.eVehicleConditionInTheGarage.Fix;
        }

        public string ModelName { get => m_ModelName; set => m_ModelName = value; }

        public string LicenseNumber { get => m_LicenseNumber; set => m_LicenseNumber = value; }

        public float PercentageOfVehicleEnergy { get => m_PercentageOfVehicleEnergy; set => m_PercentageOfVehicleEnergy = value; }

        public Wheel Wheels { get => m_Wheels; set => m_Wheels = value; }

        public Garage.eVehicleConditionInTheGarage EVehicleCondition { get => m_eVehicleCondition; set => m_eVehicleCondition = value; }

        public FuelVehicle VehicleDrivingOnFuel { get => m_VehicleDrivingOnFuel; set => m_VehicleDrivingOnFuel = value; }

        public FuelVehicle.eFueltType EFueltType { get => m_eFueltType; set => m_eFueltType = value; }

        public Garage Garage { get => m_Garage; set => m_Garage = value; }

        internal ElectricVehicle ElectricVehicle { get => m_ElectricVehicle; set => m_ElectricVehicle = value; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("license number: " + LicenseNumber);
            stringBuilder.Append(", Condition in the garage: " + m_eVehicleCondition);
            stringBuilder.Append(", Model name: " + ModelName);
            if (this.VehicleDrivingOnFuel is FuelVehicle)
            {
                stringBuilder.Append(", current fuel: " + VehicleDrivingOnFuel.CurrentFuel);
            }
            else if (this.ElectricVehicle is ElectricVehicle)
            {
                stringBuilder.Append(", Time remaining battery " + ElectricVehicle.TimeRemainingBattery);
            }

            return stringBuilder.ToString();
        }
    }
}
