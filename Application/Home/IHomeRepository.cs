using Application.Home.Dto;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Home
{
    public interface IHomeRepository
    {
        /// <summary>
        /// 查詢部門資料
        /// </summary>
        IQueryable<Dept> DeptData { get; }

        /// <summary>
        /// 查詢人員資料
        /// </summary>
        IQueryable<Employee> EmployeeData { get; }

        /// <summary>
        /// 查詢縣市資料
        /// </summary>
        //IQueryable<ZipCode> ZipCodeData { get; }

        /// <summary>
        /// 部門下拉選單
        /// 查詢/新增頁面 - 全部顯示
        /// 修改 - 顯示其他系列的部門+自己的父層級:最終結果(拿所有部門剃除子節點)
        /// </summary>
        /// <returns></returns>
        List<Dept> GetDept(int? DeptID);

        /// <summary>
        /// 編輯用-縣下拉選單
        /// </summary>
        /// <returns></returns>
        //List<CityItem> GetCitySelect();

        #region
        List<QueryResult> queryData(QueryModel model);

        /// <summary>
        /// 取得資料
        /// </summary>
        /// <param name="Account"></param>
        /// <returns></returns>
        EditData getData(string Account);

        /// <summary>
        /// 新增/修改 資料
        /// </summary>
        /// <returns></returns>
        /// <param name="status"狀態; 1.新增; 2.修改></param>
        bool update(EditData model, int status);

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="Account"></param>
        bool delete(string Account);
        #endregion
    }
}
