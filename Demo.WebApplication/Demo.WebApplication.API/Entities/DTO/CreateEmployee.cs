using Demo.WebApplication.API.Enums;

namespace Demo.WebApplication.API.Entities.DTO
{
    public class CreateEmployee
    {
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Ten nhan vien
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// Gioi tinh
        /// </summary>
        public int EmployeeGender { get; set; }
        /// <summary>
        /// Ngay sinh
        /// </summary>
        public DateTime EmployeeBirthday { get; set; }

        public string EmployeePosition { get; set; }

        public string DepartmentCode { get; set; }

        public string EmployeePeopleId { get; set; }

        public string EmployeePeopleIdLocation { get; set; }

        public string EmployeeMobilePhoneNumber { get; set; }

        public string EmployeeEmail { get; set; }

        public string EmployeeBankNumber { get; set; }
    }
}
