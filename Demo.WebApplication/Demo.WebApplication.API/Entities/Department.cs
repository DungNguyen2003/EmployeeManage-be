﻿namespace Demo.WebApplication.API.Entities
{
    public class Department
    {
        public Guid DepartmentId { get; set; }

        public string DepartmentCode { get; set; }

        public string DepartmentName { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }
    }
}
