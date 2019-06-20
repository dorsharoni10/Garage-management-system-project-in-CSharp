using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public enum eVehicleConditionInTheGarage
        {
            Fix,
            Fixed,
            Paid
        }

        private Owner m_owner;
        private eVehicleConditionInTheGarage m_eConditionInTheGarage;
        private List<Vehicle> m_VehiclesInGarage = new List<Vehicle>();
        private List<Owner> m_Owner = new List<Owner>();

        public float CalculatePercentageOfEnergy(float i_MaxEnergy, float i_CurrentEnergy)
        {
            if (i_MaxEnergy == 0) 
            {
                throw new ValueOutOfRangeException("You divided by 0", i_MaxEnergy, i_CurrentEnergy);
            }

            return (i_CurrentEnergy / i_MaxEnergy) * 100;
        }

        public bool CheackIfVehicleInGarageExists(string i_LicenseNumber)
        {
            bool theCarInGarage = false;

            foreach (Vehicle vehicle in VehiclesInGarage)
            {
                if (vehicle.LicenseNumber == i_LicenseNumber)
                {
                    vehicle.EVehicleCondition = eVehicleConditionInTheGarage.Fix;
                    theCarInGarage = true;
                }
            }

            return theCarInGarage;
        }

        public bool ChangeVehicleModeInGarage(string i_LicenseNumber, Garage.eVehicleConditionInTheGarage i_eVehicleCondition)
        {
            bool answer = false;
            foreach (Vehicle vehicle in VehiclesInGarage)
            {
                if (vehicle.LicenseNumber == i_LicenseNumber)
                {
                    vehicle.EVehicleCondition = i_eVehicleCondition;
                    answer = true;
                }
            }

            return answer;
        }

        public bool FillAirWheelsToMaximum(string i_LicenseNumber)
        {
            bool answer = false;
            foreach (Vehicle vehicle in VehiclesInGarage)
            {
                if (vehicle.LicenseNumber == i_LicenseNumber)
                {
                    vehicle.Wheels.WheelInflating(vehicle.Wheels.MaximumAirPressure - vehicle.Wheels.CurrentAirPressure);
                    answer = true;
                }
            }

            return answer;
        }

        public void FindVehicleAndSendItToGasStation(string i_LicenseNumber, FuelVehicle.eFueltType i_eFueltType, float i_FuelToFill)
        {
            foreach (Vehicle vehicle in VehiclesInGarage)
            {
                if (vehicle.LicenseNumber == i_LicenseNumber)
                {
                    if (vehicle.ElectricVehicle is ElectricVehicle)
                    {
                        throw new ArgumentException("It is impossible to fuel an electric vehicle with fuel");
                    }
                    else if (vehicle.VehicleDrivingOnFuel.EFueltType == i_eFueltType)
                    {
                        vehicle.VehicleDrivingOnFuel.FillFuel(i_FuelToFill);
                    }
                    else if (vehicle.VehicleDrivingOnFuel.EFueltType != i_eFueltType)
                    {
                        throw new ArgumentException("Fuel type is not suitable for your vehicle type");
                    }
                }           
            }
        }

        public void SendToChargeElectricVehicle(string i_LicenseNumber, int i_FuelToFill)
        {
            float fuelToFillInHour = ((float)i_FuelToFill) / 60f;

            foreach (Vehicle vehicle in VehiclesInGarage)
            {
                if (i_LicenseNumber == vehicle.LicenseNumber)
                {
                    if (vehicle.VehicleDrivingOnFuel is FuelVehicle)
                    {
                        throw new ArgumentException("It is impossible to charge a vehicle that works on fuel with electricity");
                    }

                    vehicle.ElectricVehicle.ChargingAbattery(fuelToFillInHour);
                }
            }
        }

        public string FindVehicleDetails(string i_licenseNumber)
        {
            StringBuilder sbresultToUser = new StringBuilder();

            foreach (Vehicle vehicle in VehiclesInGarage)
            {
                if (vehicle.LicenseNumber == i_licenseNumber)
                {
                    sbresultToUser.Append(vehicle.ToString());
                }
            }

            foreach (Owner owner in OwnerInGarage)
            {
                if (owner.LicenseNumber == i_licenseNumber)
                {
                    sbresultToUser.Append(", " + owner.ToString());
                }
            }

            return sbresultToUser.ToString(); 
        }

        public eVehicleConditionInTheGarage EConditionInTheGarage { get => m_eConditionInTheGarage; set => m_eConditionInTheGarage = value; }

        public Owner Owner { get => m_owner; set => m_owner = value; }

        public List<Owner> OwnerInGarage { get => m_Owner; set => m_Owner = value; }

        public List<Vehicle> VehiclesInGarage { get => m_VehiclesInGarage; set => m_VehiclesInGarage = value; }
    }
}
