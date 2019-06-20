using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class ConsoleUI
    {
        private readonly string r_invalidInput = "Invalid input";
        private readonly string r_insertLicenseNumber = "please insert license number";
        private readonly string r_unCorrectType = "Mission failed, uncorrect type";
        private GarageLogic.NewVehicle m_newVehicle = new GarageLogic.NewVehicle();
        private GarageLogic.Owner m_owner;
        private GarageLogic.Garage m_garage = new GarageLogic.Garage();

        public void UserSelect()
        {
            Console.WriteLine("1. to put a car in the garage press 1\n");
            Console.WriteLine("2. to display the license number press 2\n");
            Console.WriteLine("3. to change the vehicle mode in the garage press 3\n");
            Console.WriteLine("4. To inflate tire air pressure to maximum press 4\n");
            Console.WriteLine("5. To fuel a vehicle driven by fuel press 5\n");
            Console.WriteLine("6. To recharge an electric vehicle press 6\n");
            Console.WriteLine("7. To view full data on a vehicle in the garage press 7\n");
            Console.WriteLine("8. To exit press 8\n");
            float fuelToFill = 0;
            bool checkInputFromTheUser;

            string userChoice = Console.ReadLine();
            try
            {
                switch (userChoice)
                {
                    case "1":
                        pickVehicleFromUser();
                        break;
                    case "2":
                        displayVehicleNumbers();
                        break;
                    case "3":
                        pickDetailsAndSendItToChangeVehicleModeInGarage();
                        break;
                    case "4":
                        bool actionSecceeded = true;
                        Console.WriteLine(r_insertLicenseNumber);
                        string licenseNumber = Console.ReadLine();
                        actionSecceeded = m_garage.FillAirWheelsToMaximum(licenseNumber);
                        if (!actionSecceeded)
                        {
                            throw new ArgumentException("Could not find license number");
                        }
                        else
                        {
                            Console.WriteLine("The wheels were successfully filled");
                        }

                        UserSelect();
                        break;
                    case "5":
                        Console.WriteLine(r_insertLicenseNumber);
                        licenseNumber = Console.ReadLine();
                        Console.WriteLine("please insert a fuel type, octan95, octan96, octan98 or soler");
                        string fuelType = Console.ReadLine();
                        GarageLogic.FuelVehicle.eFueltType eFuelt = initFuelType(fuelType);
                        Console.WriteLine("please insert how match fuel to fill");
                        checkInputFromTheUser = false;
                        cheackTryParseFloat(checkInputFromTheUser, ref fuelToFill);
                        m_garage.FindVehicleAndSendItToGasStation(licenseNumber, eFuelt, fuelToFill);
                        UserSelect();
                        break;
                    case "6":
                        int rechargeTimeInMinutes;
                        bool inputUser;
                        checkInputFromTheUser = false;
                        Console.WriteLine(r_insertLicenseNumber);
                        licenseNumber = Console.ReadLine();
                        Console.WriteLine("please Enter how much time you want to recharge your vehicle in minutes");
                        inputUser = int.TryParse(Console.ReadLine(), out rechargeTimeInMinutes);
                        cheackFormatException(inputUser);
                        m_garage.SendToChargeElectricVehicle(licenseNumber, rechargeTimeInMinutes);
                        UserSelect();
                        break;
                    case "7":
                        Console.WriteLine(r_insertLicenseNumber);
                        licenseNumber = Console.ReadLine();
                        string resultToUser = "license number not found";
                        resultToUser = m_garage.FindVehicleDetails(licenseNumber);
                        Console.WriteLine(resultToUser);
                        UserSelect();
                        break;
                    case "8":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Your selection is not possible try again");
                        UserSelect();
                        break;
                }
            }
            catch (FormatException fex)
            {
                Console.WriteLine("The input you entered is invalid, {0}", fex.Message);
            }
            catch (ArgumentException ax)
            {
                Console.WriteLine("{0}", ax.Message);
            }
            catch (GarageLogic.ValueOutOfRangeException outOfRange)
            {
                Console.WriteLine("{0} the min is: {1} and the max is:{2}", outOfRange.Message, outOfRange.MinValue, outOfRange.MaxValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }

            UserSelect();
        }

        private void pickVehicleFromUser()
        {
            string modelName, licenseNumber, wheelsManufacturerName, color, vehicleType;
            float percentageOfVehicleEnergy = 0, wheelsCurrentAirPressure = 0, currentFuel = 0, timeRemainingBattey = 0;
            bool checkInputFromTheUser = false;
            Console.WriteLine(r_insertLicenseNumber);
            licenseNumber = Console.ReadLine();
            bool checkLicenseNumberExists = m_garage.CheackIfVehicleInGarageExists(licenseNumber);

            if (!checkLicenseNumberExists)
            {
                do
                {
                    Console.WriteLine("please insert your vehicle type, truck, motorcycle or car");
                    vehicleType = Console.ReadLine();
                }
                while (!checkType(vehicleType));

                GarageLogic.Car.eVehicleColor eVehicleColor;

                Console.WriteLine("please enter model name");
                modelName = Console.ReadLine();
                Console.WriteLine("please enter Wheels Manufactur Name");
                wheelsManufacturerName = Console.ReadLine();
                Console.WriteLine("please insert wheels current air pressure, insert only number");
                cheackTryParseFloat(checkInputFromTheUser, ref wheelsCurrentAirPressure);
                cheackMinAndMaxWheelsTirePresure(vehicleType, wheelsCurrentAirPressure);
                Console.WriteLine("please enter your name");
                m_owner = new GarageLogic.Owner();
                m_owner.OwnerName = Console.ReadLine();
                Console.WriteLine("please enter your phoneNumber");
                m_owner.OwnerPhoneNumber = Console.ReadLine();
                m_owner.LicenseNumber = licenseNumber;
                m_garage.OwnerInGarage.Add(m_owner);

                switch (vehicleType.ToLower())
                {
                    case "car":
                        string type;
                        Console.WriteLine("please enter color: Red, Blue, Black, Gray");
                        color = Console.ReadLine();
                        eVehicleColor = initColor(color);
                        do
                        {
                            Console.WriteLine("please enter if your car is electric or fuel");
                            type = Console.ReadLine();
                        }
                        while (!checkType(type));

                        switch (type)
                        {
                            case "electric":
                                Console.WriteLine("please enter time remaining battey from 0 - 1.8, ");
                                cheackTryParseFloat(checkInputFromTheUser, ref timeRemainingBattey);
                                energyRangeCheack(0, 1.8f, timeRemainingBattey);
                                percentageOfVehicleEnergy = m_garage.CalculatePercentageOfEnergy(1.8f, timeRemainingBattey);
                                m_newVehicle.AddNewElectricCar(modelName, licenseNumber, percentageOfVehicleEnergy, timeRemainingBattey, eVehicleColor, wheelsManufacturerName, wheelsCurrentAirPressure);
                                break;
                            case "fuel":
                                Console.WriteLine("please enter current fuel from 0 to 55, ");
                                cheackTryParseFloat(checkInputFromTheUser, ref currentFuel);
                                energyRangeCheack(0, 55, currentFuel);
                                percentageOfVehicleEnergy = m_garage.CalculatePercentageOfEnergy(55f, currentFuel);
                                m_newVehicle.AddNewFuelCar(eVehicleColor, modelName, licenseNumber, percentageOfVehicleEnergy, currentFuel, wheelsManufacturerName, wheelsCurrentAirPressure);
                                break;
                        }

                        m_garage.VehiclesInGarage.Add(m_newVehicle.Car);
                        break;

                    case "truck":
                        bool isDrivingDangerousMaterials;
                        float volumeOfCargo = 0;
                        Console.WriteLine("please enter current fuel from 0 to 110, Insert only numbers");
                        cheackTryParseFloat(checkInputFromTheUser, ref currentFuel);
                        energyRangeCheack(0, 110, currentFuel);
                        percentageOfVehicleEnergy = m_garage.CalculatePercentageOfEnergy(110f, currentFuel);
                        Console.WriteLine("please enter 'true' if you transport dangerous materials else 'false'");
                        checkInputFromTheUser = bool.TryParse(Console.ReadLine(), out isDrivingDangerousMaterials);
                        cheackFormatException(checkInputFromTheUser);
                        checkInputFromTheUser = false;
                        Console.WriteLine("what is your volume of your cargo?, Insert only numbers");
                        cheackTryParseFloat(checkInputFromTheUser, ref volumeOfCargo);
                        m_newVehicle.AddNewTruck(isDrivingDangerousMaterials, volumeOfCargo, modelName, licenseNumber, percentageOfVehicleEnergy, currentFuel, wheelsManufacturerName, wheelsCurrentAirPressure);
                        m_garage.VehiclesInGarage.Add(m_newVehicle.Truck);
                        break;

                    case "motorcycle":
                        do
                        {
                            Console.WriteLine("please enter if your car is electric or fuel");
                            type = Console.ReadLine();
                        }
                        while (!checkType(type));

                        Console.WriteLine("enter your engine capacity in cc, Insert only numbers");
                        int engineCapacityIncc = 0;
                        checkInputFromTheUser = int.TryParse(Console.ReadLine(), out engineCapacityIncc);
                        cheackFormatException(checkInputFromTheUser);
                        checkInputFromTheUser = false;
                        Console.WriteLine("enter which license you have: A, A1, A2 or B");
                        string tempLicence = Console.ReadLine();
                        GarageLogic.Motorcycle.eLicenseType eLicense = initELicense(tempLicence);
                        switch (type)
                        {
                            case "electric":
                                Console.WriteLine("enter time remaining battey from 0 to 1.4, ");
                                cheackTryParseFloat(checkInputFromTheUser, ref timeRemainingBattey);
                                energyRangeCheack(0, 1.4f, timeRemainingBattey);
                                percentageOfVehicleEnergy = m_garage.CalculatePercentageOfEnergy(1.4f, timeRemainingBattey);
                                m_newVehicle.AddNewElctricMotorcycle(engineCapacityIncc, modelName, licenseNumber, percentageOfVehicleEnergy, timeRemainingBattey, eLicense, wheelsManufacturerName, wheelsCurrentAirPressure);
                                break;
                            case "fuel":
                                Console.WriteLine("enter current fuel for 0 to 8, ");
                                cheackTryParseFloat(checkInputFromTheUser, ref currentFuel);
                                energyRangeCheack(0, 8f, currentFuel);
                                percentageOfVehicleEnergy = m_garage.CalculatePercentageOfEnergy(8f, currentFuel);
                                m_newVehicle.AddNewFuelMotorcycle(eLicense, engineCapacityIncc, modelName, licenseNumber, percentageOfVehicleEnergy, currentFuel, wheelsManufacturerName, wheelsCurrentAirPressure);
                                break;
                        }

                        m_garage.VehiclesInGarage.Add(m_newVehicle.Motorcycle);
                        break;
                    default:
                        Console.WriteLine(r_unCorrectType);
                        break;
                }
            }
            else
            {
                Console.WriteLine("your car in the garage and change to modified mode needs to fix");
            }

            Console.WriteLine("You want to insert more vehicle to the garage? say 'Yes' else 'No'");
            string ansewrFromUserifMoreVehicle = Console.ReadLine();
            if (ansewrFromUserifMoreVehicle.ToLower() == "yes")
            {
                pickVehicleFromUser();
            }

            UserSelect();
        }

        private void energyRangeCheack(float i_MinEnergy, float i_MaxEnergy, float i_CurrentEnergy)
        {
            if (i_CurrentEnergy < i_MinEnergy || i_CurrentEnergy > i_MaxEnergy)
            {
                throw new GarageLogic.ValueOutOfRangeException(r_invalidInput, i_MinEnergy, i_MaxEnergy);
            }
        }

        private GarageLogic.Car.eVehicleColor initColor(string color)
        {
            switch (color.ToLower())
            {
                case "red":
                    return GarageLogic.Car.eVehicleColor.Red;
                case "blue":
                    return GarageLogic.Car.eVehicleColor.Blue;
                case "black":
                    return GarageLogic.Car.eVehicleColor.Black;
                case "gray":
                    return GarageLogic.Car.eVehicleColor.Gray;
                default:
                    throw new ArgumentException(r_invalidInput);
            }
        }

        private GarageLogic.Motorcycle.eLicenseType initELicense(string userInputLicense)
        {
            switch (userInputLicense.ToUpper())
            {
                case "A":
                    return GarageLogic.Motorcycle.eLicenseType.A;
                case "A1":
                    return GarageLogic.Motorcycle.eLicenseType.A1;
                case "A2":
                    return GarageLogic.Motorcycle.eLicenseType.A2;
                case "B":
                    return GarageLogic.Motorcycle.eLicenseType.B;
                default:
                    throw new ArgumentException(r_unCorrectType);
            }
        }

        private GarageLogic.FuelVehicle.eFueltType initFuelType(string userInputLicense)
        {
            {
                switch (userInputLicense.ToLower())
                {
                    case "octan95":
                        return GarageLogic.FuelVehicle.eFueltType.Octan95;
                    case "octan96":
                        return GarageLogic.FuelVehicle.eFueltType.Octan96;
                    case "octan98":
                        return GarageLogic.FuelVehicle.eFueltType.Octan98;
                    case "soler":
                        return GarageLogic.FuelVehicle.eFueltType.Soler;
                    default:
                        throw new ArgumentException(r_unCorrectType);
                }
            }
        }

        private void cheackFormatException(bool i_UserInput)
        {
            if (!i_UserInput)
            {
                throw new FormatException(r_invalidInput);
            }
        }

        private void cheackTryParseFloat(bool i_UserInputCheack, ref float i_ValueToParse)
        {
            while (i_UserInputCheack == false)
            {
                i_UserInputCheack = float.TryParse(Console.ReadLine(), out i_ValueToParse);
                if (!i_UserInputCheack)
                {
                    throw new FormatException("insert only numbers");
                }
            }
        }

        private void displayVehicleNumbers()
        {
            Console.WriteLine("1. for all licence number press all");
            Console.WriteLine("2. for licence number that in fix press fix");
            Console.WriteLine("3. for licence number that fixed press fixed");
            Console.WriteLine("4. for licence number that paid press paid");
            string answerFromUser = Console.ReadLine();

            switch (answerFromUser.ToLower())
            {
                case "all":
                    foreach (GarageLogic.Vehicle vehicle in m_garage.VehiclesInGarage)
                    {
                        Console.WriteLine(vehicle.LicenseNumber);
                    }

                    break;
                case "fix":
                    findLicenseAndPrint(GarageLogic.Garage.eVehicleConditionInTheGarage.Fix);
                    break;
                case "fixed":
                    findLicenseAndPrint(GarageLogic.Garage.eVehicleConditionInTheGarage.Fixed);
                    break;
                case "paid":
                    findLicenseAndPrint(GarageLogic.Garage.eVehicleConditionInTheGarage.Paid);
                    break;
                default:
                    throw new ArgumentException(r_unCorrectType);
            }

            UserSelect();
        }

        private void findLicenseAndPrint(GarageLogic.Garage.eVehicleConditionInTheGarage i_eVehicleCondition)
        {
            foreach (GarageLogic.Vehicle vehicle in m_garage.VehiclesInGarage)
            {
                if (vehicle.EVehicleCondition == i_eVehicleCondition)
                {
                    Console.WriteLine(vehicle.LicenseNumber);
                }
            }
        }

        private bool checkType(string i_UserInput)
        {
            bool answer = false;
            if (i_UserInput.ToLower() == "motorcycle" || i_UserInput == "car" || i_UserInput == "truck")
            {
                answer = true;
            }
            else if (i_UserInput == "electric" || i_UserInput == "fuel")
            {
                answer = true;
            }
            else
            {
                Console.WriteLine(r_unCorrectType);
            }

            return answer;
        }

        private void pickDetailsAndSendItToChangeVehicleModeInGarage()
        {
            Console.WriteLine("insert the lincese number of the car you want change");
            string licenseNumber = Console.ReadLine();
            Console.WriteLine("insert to which mode you want to change");
            Console.WriteLine("1. to change to fix press fix");
            Console.WriteLine("2. to change to fixed press fixed");
            Console.WriteLine("3. to change for paid press paid");
            string userChoice = Console.ReadLine();

            switch (userChoice.ToLower())
            {
                case "fix":
                    actionWhenLicenseNumberFoundOrNot(m_garage.ChangeVehicleModeInGarage(licenseNumber, GarageLogic.Garage.eVehicleConditionInTheGarage.Fix));
                    break;
                case "fixed":
                    actionWhenLicenseNumberFoundOrNot(m_garage.ChangeVehicleModeInGarage(licenseNumber, GarageLogic.Garage.eVehicleConditionInTheGarage.Fixed));
                    break;
                case "paid":
                    actionWhenLicenseNumberFoundOrNot(m_garage.ChangeVehicleModeInGarage(licenseNumber, GarageLogic.Garage.eVehicleConditionInTheGarage.Paid));
                    break;
                default:
                    throw new ArgumentException(r_unCorrectType);
            }
        }

        private void actionWhenLicenseNumberFoundOrNot(bool i_IsLicenseNumberFound)
        {
            if (i_IsLicenseNumberFound)
            {
                Console.WriteLine("Mission Accomplished");
                UserSelect();
            }
            else
            {
                Console.WriteLine("Vehicle number not found");
                Console.WriteLine("Enter 'back' To return to the main screen or any key to continue");
                if (Console.ReadLine().ToLower() == "back")
                {
                    UserSelect();
                }

                pickDetailsAndSendItToChangeVehicleModeInGarage();
            }
        }

        private bool cheackMinAndMaxWheelsTirePresure(string i_Typecar, float i_wheelsCurrentAirPressure)
        {
            switch (i_Typecar.ToLower())
            {
                case "car":
                    if (i_wheelsCurrentAirPressure > 31 || i_wheelsCurrentAirPressure < 0)
                    {
                        throw new GarageLogic.ValueOutOfRangeException("invalid input", 0, 31);
                    }

                    break;
                case "truck":
                    if (i_wheelsCurrentAirPressure > 26 || i_wheelsCurrentAirPressure < 0)
                    {
                        throw new GarageLogic.ValueOutOfRangeException("invalid input", 0, 26);
                    }

                    break;
                case "motorcycle":
                    if (i_wheelsCurrentAirPressure > 33 || i_wheelsCurrentAirPressure < 0)
                    {
                        throw new GarageLogic.ValueOutOfRangeException("invalid input", 0, 33);
                    }

                    break;
            }

            return true;
        }
    }
}
