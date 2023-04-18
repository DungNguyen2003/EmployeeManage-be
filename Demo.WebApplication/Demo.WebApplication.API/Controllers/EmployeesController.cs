using Dapper;
using Demo.WebApplication.API.Entities;
using Demo.WebApplication.API.Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace Demo.WebApplication.API.Controllers
{
    [Route("api/[controller]")]//Attribute
    [ApiController]
    public class EmployeesController : ControllerBase // : = extend , impliment
    {
        /// <summary>
        /// API lay thong tin chi tiet 1 nhan vien
        /// </summary>
        /// <param name="employeeId">id nhan vien muon lay</param>
        /// <returns>Doi tuong nhan vien</returns>
        /// Create by: NVDUNG (12/03/2023)
        [HttpGet("{employeeId}")]
        public IActionResult GetEmployeeById([FromRoute]Guid employeeId)
        {
            try
            {
                
                // Chuẩn bị tên stored
                string storedProcedureName = "Proc_employee_GetById";

                // Chuẩn bị tham số đầu vào
                var parameters = new DynamicParameters();
                parameters.Add("v_EmployeeId", employeeId);

                // Khởi tạo kết nối
                string connectionString = "Server=18.179.16.166;Port=3306;Database=MISA.HOU2023_NVDUNG;Uid=nvmanh;Pwd=12345678;";
                var mySqlConnection = new MySqlConnection(connectionString);

                // Thực hiện câu lệnh Sql
                var employee = mySqlConnection.QueryFirstOrDefault<Employee>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                // Xử lý kết quả trả về

                // Thành công
                if (employee != null)
                {
                    return StatusCode(200, employee);
                }

                // Thất bại
                else
                {
                    return NotFound(employeeId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new ErrorResult
                {
                    ErrorCode = Enums.ErrorCode.Exception,
                    DevMsg = Resource.DevMsg_Exception,
                    UserMsg = Resource.UserMsg_Exception,
                    TraceId = HttpContext.TraceIdentifier,
                    MoreInfo = ex.Message
                });
                
            }

            


           
        }

        /// <summary>
        /// API them moi 1 nhan vien
        /// </summary>
        /// <param name="employeeInfo">Thông tin nhân viên</param>
        /// <returns>Status code 201</returns>
        /// Create by: NVDUNG (12/03/2023)
        [HttpPost]
        public IActionResult InsertEmployee([FromBody] CreateEmployee employeeInfo)
        {
            try { 
            
            // Chuẩn bị tên stored
            string storedProcedureName = "Proc_employee_Create";

            // Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            parameters.Add("v_EmployeeCode", employeeInfo.EmployeeCode);
            parameters.Add("v_EmployeeName", employeeInfo.EmployeeName);
            parameters.Add("v_EmployeeBirthday", employeeInfo.EmployeeBirthday);
            parameters.Add("v_EmployeeGender", employeeInfo.EmployeeGender);
            parameters.Add("v_EmployeePosition", employeeInfo.EmployeePosition);
            parameters.Add("v_DepartmentCode", employeeInfo.DepartmentCode);
            parameters.Add("v_EmployeeMobilePhoneNumber", employeeInfo.EmployeeMobilePhoneNumber);
            parameters.Add("v_EmployeePeopleId", employeeInfo.EmployeePeopleId);
            parameters.Add("v_EmployeePeopleIdLocation", employeeInfo.EmployeePeopleIdLocation);
            parameters.Add("v_EmployeeEmail", employeeInfo.EmployeeEmail);
            parameters.Add("v_EmployeeBankNumber", employeeInfo.EmployeeBankNumber);

            // Khởi tạo kết nối
            string connectionString = "Server=18.179.16.166;Port=3306;Database=MISA.HOU2023_NVDUNG;Uid=nvmanh;Pwd=12345678;";
            var mySqlConnection = new MySqlConnection(connectionString);

            // Thực hiện câu lệnh Sql
            var employee = mySqlConnection.Query<CreateEmployee>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

            // Xử lý kết quả trả về

            // Thành công
            if (employee != null)
            {
                return StatusCode(201, employee);
            }

            // Thất bại
            else
            {
                return NotFound();
            }
        }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new ErrorResult
                {
                    ErrorCode = Enums.ErrorCode.Exception,
                    DevMsg = Resource.DevMsg_Exception,
                    UserMsg = Resource.UserMsg_Exception,
                    TraceId = HttpContext.TraceIdentifier,
                    MoreInfo = ex.Message
                });
                
            }
        }

        /// <summary>
        /// API Lấy toàn bộ nhân viên
        /// </summary>
        /// <param></param>
        /// <returns>Status code 200, Thông tin toàn bộ NV</returns>
        /// Create by: NVDUNG (12/03/2023)
        [HttpGet]
        public IActionResult GetEmployees()
        {
        
            try
            {

                // Chuẩn bị tên stored
                string storedProcedureName = "Proc_employee_GetEmployees";

                // Chuẩn bị tham số đầu vào
                var parameters = new DynamicParameters();
                //parameters.Add("v_EmployeeId", employeeId);

                // Khởi tạo kết nối
                string connectionString = "Server=18.179.16.166;Port=3306;Database=MISA.HOU2023_NVDUNG;Uid=nvmanh;Pwd=12345678;";
                var mySqlConnection = new MySqlConnection(connectionString);

                // Thực hiện câu lệnh Sql
                var employee = mySqlConnection.Query<GetEmployee>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);

                // Xử lý kết quả trả về

                // Thành công
                if (employee != null)
                {
                    return StatusCode(200, employee);

                }

                // Thất bại
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new ErrorResult
                {
                    ErrorCode = Enums.ErrorCode.Exception,
                    DevMsg = Resource.DevMsg_Exception,
                    UserMsg = Resource.UserMsg_Exception,
                    TraceId = HttpContext.TraceIdentifier,
                    MoreInfo = ex.Message
                });

            }
        }

        /// <summary>
        /// API xóa 1 nhan vien theo ID
        /// </summary>
        /// <param name="employeeId">ID nhân viên</param>
        /// <returns>Status code 200, massage</returns>
        /// Create by: NVDUNG (28/03/2023)
        [HttpDelete("{employeeId}")]
        public IActionResult DeleteEmployeeById([FromRoute] Guid employeeId)
        {
            try
            {
                string storedProcedureNameFindEmp = "Proc_employee_GetById";

                // Chuẩn bị tham số đầu vào
                var parameters = new DynamicParameters();
                parameters.Add("v_EmployeeId", employeeId);

                // Khởi tạo kết nối
                string connectionString = "Server=18.179.16.166;Port=3306;Database=MISA.HOU2023_NVDUNG;Uid=nvmanh;Pwd=12345678;";
                var mySqlConnection = new MySqlConnection(connectionString);

                // Thực hiện câu lệnh Sql
                var employee = mySqlConnection.QueryFirstOrDefault<Employee>(storedProcedureNameFindEmp, parameters, commandType: System.Data.CommandType.StoredProcedure);

                // Chuẩn bị tên stored
                string storedProcedureNameDelete = "Proc_employee_DeleteByEmployeeId";

                // Chuẩn bị tham số đầu vào
                
                parameters.Add("v_EmployeeId", employee.EmployeeId);

             

                // Thực hiện câu lệnh Sql
                var employeeDelete = mySqlConnection.QueryFirstOrDefault<Employee>(storedProcedureNameDelete, parameters, commandType: System.Data.CommandType.StoredProcedure);

                // Xử lý kết quả trả về

                // Thành công
                if (employee != null)
                {
                    return StatusCode(200, "tìm thấy nhân viên và xóa thành công");
                }

                // Thất bại
                else
                {
                    return StatusCode(500, "Xóa không thành công, lỗi xảy ra");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new ErrorResult
                {
                    ErrorCode = Enums.ErrorCode.Exception,
                    DevMsg = Resource.DevMsg_Exception,
                    UserMsg = Resource.UserMsg_Exception,
                    TraceId = HttpContext.TraceIdentifier,
                    MoreInfo = ex.Message
                });

            }





        }
    }
}
