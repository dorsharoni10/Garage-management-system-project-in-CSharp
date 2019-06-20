using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelVehicle
    {
        public enum eFueltType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        private float m_CurrentFuel;
        private float m_MaxFuel;
        private eFueltType m_eFueltType;

        public FuelVehicle(float i_CurrentFuel, float i_MaxFuel, eFueltType i_eFueltType)
        {
            this.m_CurrentFuel = i_CurrentFuel;
            this.m_MaxFuel = i_MaxFuel;
            this.m_eFueltType = i_eFueltType;
        }

        public float CurrentFuel { get => m_CurrentFuel; set => m_CurrentFuel = value; }

        public float MaxFuel { get => m_MaxFuel; }

        public eFueltType EFueltType { get => m_eFueltType; }

        public void FillFuel(float i_HowmuchFuelToFill)
        {
            float tempMaxFuel = i_HowmuchFuelToFill + CurrentFuel;
            if (tempMaxFuel <= m_MaxFuel)
            {
                CurrentFuel = tempMaxFuel;
            }
            else
            {
                throw new ValueOutOfRangeException("You asked for too much fuel", 0, m_MaxFuel);
            }
        }  
    }
}
