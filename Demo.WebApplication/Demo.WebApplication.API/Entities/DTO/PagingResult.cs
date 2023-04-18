namespace Demo.WebApplication.API.Entities.DTO
{
    public class PagingResult
    {
        /// <summary>
        /// Dữ liệu trả về thỏa mãn
        /// </summary>
        public List<Employee> Data { get; set; }

        /// <summary>
        /// Tổng số bản ghi thỏa mãn điều kiện lọc
        /// </summary>
        public int TotalRecord { get; set; }
    }
}
