using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Home.Dto
{
    /// <summary>
    /// 查詢 Dto
    /// </summary>
    public class QueryModel : QueryDto
    {
        /// <summary>
        /// 部門-下拉式選單
        /// </summary>
        public List<Dept> DepSelectItem { get; set; }

        public string dept { get; set; }

        public string Name { get; set; }
    }

    /// <summary>
    /// 查詢結果 Dto
    /// </summary>
    public class QueryResult
    {
        /// <summary>
        /// 項次
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 帳號
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 部門ID
        /// </summary>
        public int DeptID { get; set; }

        /// <summary>
        /// 部門英文代碼
        /// </summary>
        public string DepCode { get; set; }

        /// <summary>
        /// 所屬部門
        /// </summary>
        public string DepName { get; set; }

        /// <summary>
        /// 中文名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 到職日
        /// </summary>
        public string Arrival { get; set; }

        /// <summary>
        /// 職稱
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 狀態
        /// 1:在職; 0:離職
        /// </summary>
        public int Status { get; set; }

        public string City { get; set; }
    }

    /// <summary>
    /// 單筆Dto
    /// </summary>
    public class GetDataResult
    {
        /// <summary>
        /// 帳號
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 部門ID
        /// </summary>
        public int? DeptID { get; set; }

        /// <summary>
        /// 英文代碼
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 部門中文名稱
        /// </summary>
        public string DepName { get; set; }

        /// <summary>
        /// 人員姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 上層部門ID
        /// </summary>
        public int? Level1ID { get; set; }

        /// <summary>
        /// 上層部門英文代碼
        /// </summary>
        public string Level1Code { get; set; }

        /// <summary>
        /// 上層部門中文名稱
        /// </summary>
        public string Level1Name { get; set; }

        /// <summary>
        /// 主管帳號
        /// </summary>
        public string Manager { get; set; }

        /// <summary>
        /// 主管名字
        /// </summary>
        public string ManagerName { get; set; }

        /// <summary>
        /// 第幾層
        /// </summary>
        public int Level { get; set; }
    }

    /// <summary>
    /// 新增/修改 Dto
    /// </summary>
    public class EditData
    {
        /// <summary>
        /// 部門-下拉式選單
        /// </summary>
        public List<Dept> DepSelectItem { get; set; }

        /// <summary>
        /// 縣-下拉式選單
        /// </summary>
        public List<CityItem> CitySelectItem { get; set; }

        /// <summary>
        /// 市-下拉式選單
        /// </summary>
        // public List<ZipCode> AriaSelectItem { get; set; }

        /// <summary>
        /// 通勤方式否為機車
        /// </summary>
        public bool checkbox1 { get; set; }

        /// <summary>
        /// 通勤方式否為汽車
        /// </summary>
        public bool checkbox2 { get; set; }

        /// <summary>
        /// 通勤方式否為步行
        /// </summary>
        public bool checkbox3 { get; set; }

        /// <summary>
        /// 通勤方式否為大眾運輸
        /// </summary>
        public bool checkbox4 { get; set; }

        /// <summary>
        /// 人員id
        /// Employee.ID
        /// </summary>
        public int? ID { get; set; }

        /// <summary>
        /// 部門代號
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DepName { get; set; }

        public string Arrival { get; set; }

        /// <summary>
        /// 人員姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 撫養人口
        /// </summary>
        public int Dependent { get; set; }

        /// <summary>
        /// 帳號
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 職稱
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 戶籍縣市全名
        /// </summary>
        public string CityALL { get; set; }

        /// <summary>
        /// 戶籍縣-編號
        /// </summary>
        public int CityNo { get; set; }

        public int CityALLNo { get; set; }

        /// <summary>
        /// 戶籍縣
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 戶籍市
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// 通勤方式，多選
        /// ex: 1,2
        /// 1.機車
        /// 2.汽車
        /// 3.步行
        /// 4.大眾運輸
        /// </summary>
        public string Commuting { get; set; }

        /// <summary>
        /// 狀態
        /// true.在職
        /// false.離職
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 信箱
        /// </summary>
        public string Mail { get; set; }
    }

    /// <summary>
    /// 縣
    /// </summary>
    public class CityItem
    {
        public string value { get; set; }

        public string text { get; set; }
    }
}
