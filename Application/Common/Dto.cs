using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    /// <summary>
    /// 共用的查詢 Dto
    /// </summary>
    public class QueryDto
    {
        public int page { get; set; }

        public int take { get; set; }

        /// <summary>
        /// 倒排 | 正排
        /// </summary>
        public string orderby { get; set; }

        /// <summary>
        /// 根據哪個欄位排序
        /// </summary>
        public string orderbyField { get; set; }
    }
}
