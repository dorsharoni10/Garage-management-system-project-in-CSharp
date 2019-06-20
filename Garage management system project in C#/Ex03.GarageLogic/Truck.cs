using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsDrivingDangerousMaterials;
        private float m_VolumeOfCargo;
        private float m_MaxFuel;
        private string m_fuelt;

        public Truck(bool i_IsDrivingDangerousMaterials, float i_VolumeOfCargo, string i_ModelName, string i_LicenseNumber, float i_PercentageOfVehicleEnergy, float i_CurrentFuel, string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure)
            : base(i_ModelName, i_LicenseNumber, i_PercentageOfVehicleEnergy)
        {
            this.m_IsDrivingDangerousMaterials = i_IsDrivingDangerousMaterials;
            this.m_VolumeOfCargo = i_VolumeOfCargo;
            FuelVehicle.eFueltType eFueltType = FuelVehicle.eFueltType.Soler;
            m_MaxFuel = 110f;
            VehicleDrivingOnFuel = new FuelVehicle(i_CurrentFuel, m_MaxFuel, eFueltType);
            Wheels = new Wheel(i_WheelsManufacturerName, i_WheelsCurrentAirPressure, 26, 12);
            m_fuelt = ", fuelt type: " + eFueltType;
        }

        public bool IsDrivingDangerousMaterials { get => m_IsDrivingDangerousMaterials; }

        public float VolumeOfCargo { get => m_VolumeOfCargo; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(base.ToString());
            stringBuilder.Append(", Percentage of vehicle energy: " + Garage.CalculatePercentageOfEnergy(110f, VehicleDrivingOnFuel.CurrentFuel));
            stringBuilder.Append(", Is driving dangerous materials?: " + IsDrivingDangerousMaterials);
            stringBuilder.Append(", Volume Of Cargo: " + VolumeOfCargo);
            stringBuilder.Append(", " + Wheels.ToString());
            stringBuilder.Append(m_fuelt);
            return stringBuilder.ToString();
        }
    }
}
