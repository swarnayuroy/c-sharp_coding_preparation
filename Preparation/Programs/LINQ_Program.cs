using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programs
{
    public interface ILINQ_Program
    {
        Task Print_Employee_Details();
        Task Print_Department_Details();
        Task Print_Insurance_Details();

        Task Print_Employee_Department_Insurance_Details ();
        Task Print_Employees_in_each_Department_Details();
        Task Print_Employees_with_or_without_Department();
        Task Print_Employees_Details_having_Nth_Highest_Salary(int nth_Highestvalue);
    }

    public class Employee
    {
        public int empId;
        public string empName;
        public string designation;
        public double salary;
        public int deptId;
    }
    public class Department
    {
        public int deptId;
        public string deptName;
    }
    public class EmployeeInsurance
    {
        public int empId;
        public string insuranceDetail;
    }
    public class LINQ_Program : ILINQ_Program, IPrintService
    {
        private List<Employee> _empList;
        private List<Department> _deptList;
        private List<EmployeeInsurance> _insuranceDetail;
        public LINQ_Program()
        {
            this._empList = new List<Employee>{
                new Employee(){empId=1, empName="John Doe", designation="Engineer", salary=80000, deptId=1},
                new Employee(){empId=2, empName="Max Miller", designation="Engineer", salary=60000, deptId=1},
                new Employee(){empId=3, empName="Jane Doe", designation="L4 Manager", salary=80000, deptId=2},
                new Employee(){empId=4, empName="David Cox", designation="L1 Manager", salary=80000, deptId=2},
                new Employee(){empId=5, empName="David Miller", designation="Accountant", salary=85000, deptId=3},
            };

            this._deptList = new List<Department>{
                new Department(){deptId=1, deptName="IT Engineering"},
                new Department(){deptId=2, deptName="Sales Operation"}
            };

            this._insuranceDetail = new List<EmployeeInsurance>{
                new EmployeeInsurance(){empId=1, insuranceDetail="LIC"},
                new EmployeeInsurance(){empId=2, insuranceDetail="HDFC Ergo"},
                new EmployeeInsurance(){empId=3, insuranceDetail="TATA AIG"},
                new EmployeeInsurance(){empId=4, insuranceDetail="ICICI Lombard"},
                new EmployeeInsurance(){empId=5, insuranceDetail="LIC"},
            };
        }

        public List<Employee> Employee { get { return _empList; } }
        public List<Department> Department { get{ return _deptList; } }
        public List<EmployeeInsurance> Insurance { get { return _insuranceDetail; } }

        #region Print Result
        public Task PrintResult(object data, string message)
        {
            if (data is List<Employee> employees) 
            {
                Console.WriteLine($"\n{message}");
                foreach (Employee employee in employees)
                {                    
                    Console.WriteLine($"Employee ID: {employee.empId}, Name: {employee.empName}, Designation: {employee.designation}, Salary: {employee.salary}, Department ID: {employee.deptId}");
                }
            }
            else if (data is List<Department> departments)
            {
                Console.WriteLine($"\n{message}");
                foreach (Department department in departments)
                {                    
                    Console.WriteLine($"Department ID: {department.deptId}, Name: {department.deptName}");
                }
            }
            else if (data is List<EmployeeInsurance> insurances)
            {
                Console.WriteLine($"\n{message}");
                foreach (EmployeeInsurance insurance in insurances)
                {                    
                    Console.WriteLine($"Insurance ID: {insurance.empId}, Insurance Detail: {insurance.insuranceDetail}");
                }
            }
            else if(data is List<EmployeeDepartmentDTO> leftJoinResult)
            {
                Console.WriteLine($"\n{message}");
                foreach (EmployeeDepartmentDTO detail in leftJoinResult)
                {
                    Console.WriteLine($"Employee ID: {detail.EmployeeId}, Employee Name: {detail.EmployeeName}, Department: {detail.Department}");
                }
            }
            else if (data is List<EmployeeDepartmentInsuranceDTO> innerJoinResult)
            {
                Console.WriteLine($"\n{message}");
                foreach (EmployeeDepartmentInsuranceDTO detail in innerJoinResult)
                {
                    Console.WriteLine($"Employee ID: {detail.EmployeeId}, Employee Name: {detail.EmployeeName}, Department: {detail.Department}, Insurance: {detail.Insurance}");
                }
            }
            return Task.CompletedTask;
        }
        #endregion

        #region Listing Details

        public Task Print_Employee_Details()
        {
            PrintResult(_empList, "Employee List:");
            return Task.CompletedTask;
        }

        public Task Print_Department_Details()
        {
            PrintResult(_deptList, "Department List:");
            return Task.CompletedTask;
        }

        public Task Print_Insurance_Details()
        {
            PrintResult(_insuranceDetail, "Employee Insurance List:");
            return Task.CompletedTask;
        }
        #endregion

        #region Inner Join

        public Task Print_Employee_Department_Insurance_Details()
        {
            var innerJoinRes = (from employee in Employee
                                join department in Department
                                on employee.deptId equals department.deptId
                                join insurance in Insurance
                                on employee.empId equals insurance.empId
                                select new EmployeeDepartmentInsuranceDTO
                                {
                                    EmployeeId = employee.empId,
                                    EmployeeName = employee.empName,
                                    Department = department.deptName,
                                    Insurance = insurance.insuranceDetail
                                }).ToList();
            PrintResult(innerJoinRes, "Listing down the employees along with their departments and insurance details:");
            return Task.CompletedTask;
        }

        #endregion

        #region Left Join

        public Task Print_Employees_with_or_without_Department()
        {
            var leftJoinRes = (from employee in Employee
             join department in Department
             on employee.deptId equals department.deptId into empDept
             from deptDetails in empDept.DefaultIfEmpty()
             select new EmployeeDepartmentDTO
             {
                 EmployeeId = employee.empId,
                 EmployeeName = employee.empName,
                 Department = deptDetails != null ?
                 deptDetails.deptName : "NA"
             }).ToList();

            PrintResult(leftJoinRes, "Listing down the employees with or without department details:"); 
            return Task.CompletedTask;
        }

        #endregion

        #region Group Join

        public Task Print_Employees_in_each_Department_Details()
        {
            var groupJoinRes = from department in Department join employee in Employee
                               on department.deptId equals employee.deptId into empGroup
                               select new {
                                   department, 
                                   empGroup 
                               };

            Console.WriteLine("\nGroup Join:Listing down the employees in each department:");
            foreach (var item in groupJoinRes)
            {
                Console.WriteLine($"Department: {item.department.deptName}");
                foreach (var employee in item.empGroup)
                {
                    Console.WriteLine($" - {employee.empName}");
                }
            }
            return Task.CompletedTask;
        }

        #endregion

        #region Employees with Nth Highest Salary

        public Task Print_Employees_Details_having_Nth_Highest_Salary(int nth_Highestvalue)
        {
            if (nth_Highestvalue < Employee.Count())
            {
                double nth_HighestSalary = (from e in Employee orderby e.salary descending select new { Salary = e.salary })
                                            .Distinct()
                                            .ToList()[nth_Highestvalue - 1].Salary;
                var employeeResult = (from employee in Employee where employee.salary == nth_HighestSalary select employee).ToList<Employee>();

                PrintResult(employeeResult, $"Listing down the employees having [{nth_Highestvalue}]th highest salary:");
            }
            else
            {
                Console.WriteLine($"Invalid value for Nth highest salary.");
            }            
            return Task.CompletedTask;
        }

        #endregion
    }

    #region DTO
    public class EmployeeDepartmentDTO
    {
        public int EmployeeId;
        public string EmployeeName;
        public string Department;
    }
    public class EmployeeDepartmentInsuranceDTO
    {
        public int EmployeeId;
        public string EmployeeName;
        public string Department;
        public string Insurance;
    }
    #endregion
}
