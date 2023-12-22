using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
{
    /// <summary>
    /// 部門
    /// </summary>
    [Table("Dept")]
    public class Dept
    {
        /// <summary>
        /// 流水號
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 父部門
        /// </summary>
        public int? ParentID { get; set; }

        /// <summary>
        /// 部門英文代號
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 部門中文名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 部門管理者
        /// </summary>
        public string Manager { get; set; }

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
