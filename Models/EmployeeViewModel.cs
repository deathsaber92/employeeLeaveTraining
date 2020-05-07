using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeLeaveTraining.Models
{
    /// <summary>
    /// View model for the employee
    /// </summary>
    public class EmployeeViewModel 
    {
        public string Id { get; set; }

        [DisplayName("First name")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        public string LastName { get; set; }

        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Tax id")]
        public string TaxId { get; set; }

        [DisplayName("Username")]
        public string UserName { get; set; }

        public string Email { get; set; }

        [DisplayName("Date of birth")]
        public DateTime DateOfBirth { get; set; }

        public DateTime DateJoined { get; set; }
    }
}
