using Eblacorp_internal.Commands;
using Eblacorp_internal.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eblacorp_internal.ViewModel
{
    public class EmployeeViewModel
    {
        //instance of the employee DAL
         EmployeeDal employeeDb = new EmployeeDal();

        //collection of the UserTable information
        public ObservableCollection<Models.EmployeeModel> Employee { get; set; } = new ObservableCollection<Models.EmployeeModel>();

        //RelayCommand

        public EmployeeViewModel()
        {
            Employee = employeeDb.selectAllEmployees();
        }


    }
}
