using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;
        private string m_Messege;

        public ValueOutOfRangeException(string i_messege, float i_minValue, float i_maxValue) : base(i_messege)
        {
            this.m_MinValue = i_minValue;
            this.m_MaxValue = i_maxValue;
            this.m_Messege = i_messege;
        }

        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
        }

        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
        }

        public string Messege
        {
            get
            {
                return m_Messege;
            }
        }
    }
}
