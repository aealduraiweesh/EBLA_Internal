using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eblacorp_internal.Models
{
    public class EmployeeModel 
    {

        public int ID { get; set; }
        public  string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string FourthName { get; set; }
        public string FamilyName { get; set; }
        public string LatinName { get; set; }
        public string CivilNum { get; set; }
        public string BirthPlace { get; set; }
        public DateTime? DOB { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }
        public string Career { get; set; }
        public string PassportNum { get; set; }
        public DateTime? PassportEndDate { get; set; }
        public string PassportType { get; set; }
        public string Education { get; set; }
        public string MaritalStatus { get; set; }
        public string salary { get; set; }
        public string declration { get; set; }
        public string ResidencyNum { get; set; }
        public DateTime? ResidencyEndDate { get; set; }
        public DateTime? StartDate { get; set; }
        public string Duration { get; set; }
        public string DurationEng { get; set; }
        public string NationalityEng { get; set; }
        public string CareerEng { get; set; }
        public string Note { get; set; }
        public DateTime? PassportIssueDate { get; set; }
/*        public string LicenseNumber { get; set; }
        public DateTime? LicenseEndDate { get; set; }*/



     }




}
