
using Demo.WebApplication.API.Enums;

namespace Demo.WebApplication.API.Entities
{
    /// <summary>
    /// Thong tin nhan vien
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Id nhan vien
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Ma nhan vien
        /// </summary>
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Ten nhan vien
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// Gioi tinh
        /// </summary>
        public Gender EmployeeGender { get; set; }
        /// <summary>
        /// Ngay sinh
        /// </summary>
        public DateTime EmployeeBirthday { get; set; }

        public string EmployeePosition { get; set; }

        public string DepartmentCode { get; set; }

        public string DepartmentName { get; set; }

        public string EmployeePeopleId { get; set; }

        public string EmployeePeopleIdLocation { get; set; }

        public string EmployeeMobilePhoneNumber { get; set; }

        public string EmployeeEmail { get; set; }

        public string EmployeeBankNumber { get; set; }

       /* public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }*/
    }
}
