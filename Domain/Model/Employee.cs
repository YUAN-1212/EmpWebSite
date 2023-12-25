using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
{
    /// <summary>
    /// 員工
    /// </summary>
    [Table("Employee")]
    public class Employee
    {
        /// <summary>
        /// 流水號
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 帳號
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 中文名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 部門ID
        /// 對應至 Dept
        /// </summary>
        public int DeptID { get; set; }

        /// <summary>
        /// 職稱
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 到職日
        /// </summary>
        public DateTime Arrival { get; set; }

        /// <summary>
        /// 狀態
        /// 1:在職; 0:離職
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 新增時間
        /// </summary>
        public DateTime AddDate { get; set; }

        /// <summary>
        /// 更新時間
        /// </summary>
        public DateTime UpdateDate { get; set; }
    }
}
