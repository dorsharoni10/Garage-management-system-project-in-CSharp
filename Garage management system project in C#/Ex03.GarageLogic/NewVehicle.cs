using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class NewVehicle
    {
        private Car m_Car;
        private Motorcycle m_Motorcycle;
        private Truck m_Truck;

        public Car Car { get => m_Car; set => m_Car = value; }

        public Motorcycle Motorcycle { get => m_Motorcycle; set => m_Motorcycle = value; }

        public Truck Truck { get => m_Truck; set => m_Truck = value; }

        ////add new car working on fuel
        public void AddNewFuelCar(Car.eVehicleColor i_eVehicleColor, string i_ModelName, string i_LicenseNumber, float i_PercentageOfVehicleEnergy, float i_CurrentFuel, string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure)
        {
            m_Car = new Car(i_eVehicleColor, i_ModelName, i_LicenseNumber, i_PercentageOfVehicleEnergy, i_CurrentFuel, i_WheelsManufacturerName, i_WheelsCurrentAirPressure);
        }
        ////add new car working on electric
        public void AddNewElectricCar(string i_ModelName, string i_LicenseNumber, float i_PercentageOfVehicleEnergy, float i_TimeRemainingBattey, Car.eVehicleColor i_eVehicleColor, string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure)
        {
            m_Car = new Car(i_ModelName, i_LicenseNumber, i_PercentageOfVehicleEnergy, i_TimeRemainingBattey, i_eVehicleColor, i_WheelsManufacturerName, i_WheelsCurrentAirPressure);
        }
        ////add new truck 
        public void AddNewTruck(bool i_IsDrivingDangerousMaterials, float i_VolumeOfCargo, string i_ModelName, string i_LicenseNumber, float i_PercentageOfVehicleEnergy, float i_CurrentFuel, string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure)
        {
            m_Truck = new Truck(i_IsDrivingDangerousMaterials, i_VolumeOfCargo, i_ModelName, i_LicenseNumber, i_PercentageOfVehicleEnergy, i_CurrentFuel, i_WheelsManufacturerName, i_WheelsCurrentAirPressure);
        }
        ////add new motorcycle working on Electric
        public void AddNewElctricMotorcycle(int i_EngineCapacityIncc, string i_ModelName, string i_LicenseNumber, float i_PercentageOfVehicleEnergy, float i_TimeRemainingBattey, Motorcycle.eLicenseType i_eLicense, string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure)
        {
            m_Motorcycle = new Motorcycle(i_EngineCapacityIncc, i_ModelName, i_LicenseNumber, i_PercentageOfVehicleEnergy, i_TimeRemainingBattey, i_eLicense, i_WheelsManufacturerName, i_WheelsCurrentAirPressure);
        }
        ////add new motorcycle working on fuel
        public void AddNewFuelMotorcycle(Motorcycle.eLicenseType i_eLicense, int i_EngineCapacityIncc, string i_ModelName, string i_LicenseNumber, float i_PercentageOfVehicleEnergy, float i_CurrentFuel, string i_WheelsManufacturerName, float i_WheelsCurrentAirPressure)
        {
            m_Motorcycle = new Motorcycle(i_eLicense, i_EngineCapacityIncc, i_ModelName, i_LicenseNumber, i_PercentageOfVehicleEnergy, i_CurrentFuel, i_WheelsManufacturerName, i_WheelsCurrentAirPressure);
        }
    }
}
