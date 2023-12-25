using Application.Home;
using Application.Home.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        #region : : : 服務及建構子 : : : 
        //private readonly IHomeRepository _IHomeRepo;
        private IHomeRepository _IHomeRepo = DependencyResolver.Current.GetService<IHomeRepository>();

        //public HomeController(HomeRepository webRepo
        //                         )
        //{
        //    iHomeRepo = webRepo;

        //}

        //public HomeController() : this(new HomeRepository())
        //{
        //    // this.iWebRepo = WebRepo;
        //}

        // 無參數的公用建構函式
        public HomeController()
        {
            // 在這裡進行初始化
        }

        // 帶參數的建構函式，用於依賴注入
        public HomeController(IHomeRepository iHomeRepo)
        {
            //DependencyResolver.SetResolver(new IHomeRepository());
            _IHomeRepo = DependencyResolver.Current.GetService<IHomeRepository>();
            //IHomeRepo = iHomeRepo;
        }
        #endregion

        public ActionResult Index()
        {
            //var model = new QueryModel()
            //{
            //    DepSelectItem = _IHomeRepo.DeptData.ToList()
            //};
            ViewBag.Message = "人員查詢";
            //ViewBag.Dep = new SelectList(_IHomeRepo.DeptData.Select(p => new { Text = p.Name, Value = p.Code }).ToList(), "Value", "Text");

            return View();
        }

        /// <summary>
        /// 查詢 資料
        /// </summary>
        ///  <param name="page">jqGrid丟進來的參數</param>
        ///  https://www.techdoubts.net/2017/05/full-integration-dynamic-jqgrid-asp-net-mvc.html
        /// <returns></returns>
        public JsonResult Query(QueryModel model, int page)
        {
            var queryData = _IHomeRepo.queryData(model);
            // var aa = JsonConvert.SerializeObject(queryData);

            int pageSize = 10;
            int pageNum = page;
            int totalRecords = queryData.Count;
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            var jsonData = new
            {
                total = totalPages,
                page = pageNum,
                records = totalRecords,
                rows = queryData.Skip((pageNum - 1) * pageSize).Take(pageSize)
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 取得單筆資料
        /// </summary>
        /// <param name="DeptID"></param>
        /// <returns></returns>
        public JsonResult GetData(string Account)
        {
            try
            {
                var data = _IHomeRepo.getData(Account);

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 取得部門
        /// 查詢/新增頁面 - 全部顯示
        /// 修改 - 顯示其他系列的部門+自己的父層級:最終結果(拿所有部門剃除子節點)
        /// </summary>
        public JsonResult GetDeptList(int? DeptID)
        {
            try
            {
                var queryData = _IHomeRepo.GetDept(DeptID);
                return Json(queryData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}