using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Owner
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private string m_LicenseNumber;

        public string OwnerName { get => m_OwnerName; set => m_OwnerName = value; }

        public string OwnerPhoneNumber { get => m_OwnerPhoneNumber; set => m_OwnerPhoneNumber = value; }

        public string LicenseNumber { get => m_LicenseNumber; set => m_LicenseNumber = value; }

        public override string ToString()
        {
            return "Owner name: " + m_OwnerName + ", Owner phone number: " + m_OwnerPhoneNumber;
        }
    }
}
