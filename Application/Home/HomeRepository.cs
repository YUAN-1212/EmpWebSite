using Application.Home.Dto;
using Domain;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Home
{
    public class HomeRepository : IHomeRepository
    {
        private readonly WebDbContext db = new WebDbContext();

        /// <summary>
        /// 查詢部門資料
        /// </summary>
        public IQueryable<Dept> DeptData
        {
            get { return db.Depts; }
        }

        /// <summary>
        /// 查詢人員資料
        /// </summary>
        public IQueryable<Employee> EmployeeData
        {
            get { return db.Employees; }
        }

        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<QueryResult> queryData(QueryModel model)
        {
            var aa = db.Depts.ToList();
            var bb = db.Employees.ToList();

            var temp = (from a in db.Depts
                        join b in db.Employees on a.ID equals b.DeptID
                        select new
                        {
                            Index = b.ID,
                            b.Account,
                            b.Name,
                            a.Code,
                            DepName = a.Name,
                            //b.City,
                        }
                      );

            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                temp = temp.Where(t => t.Name.Contains(model.Name) || t.Account.Contains(model.Name));
            }

            if (!string.IsNullOrWhiteSpace(model.dept))
            {
                temp = temp.Where(t => t.Code == model.dept);
            }

            var data = temp.Select(p => new QueryResult()
            {
                Index = p.Index,
                Account = p.Account,
                Name = p.Name,
                //Code = p.Code,
                DepName = p.DepName,
                //City = p.City,
            });

            return data.ToList();
        }

        /// <summary>
        /// 取得資料
        /// </summary>
        /// <param name="Account"></param>
        /// <returns></returns>

        public EditData getDate(string Account)
        {
            var data = new EditData();

            var query = (from a in DeptData
                         join b in EmployeeData on a.ID equals b.DeptID
                         where b.Account == Account
                         select new
                         {
                             b.Account,
                             b.Name, //人員名稱
                             a.Code,
                             DepName = a.Name, //部門名稱
                             b.Arrival,
                             //b.Dependent,
                             //b.Title,
                             //CityALL = b.City,//縣市全名
                             //Commuting = b.Commuting,
                             //b.Status,
                             //b.Mail,
                             // b.City, // 取得縣市
                             //Area = b.City, //取得區域
                         });

            data = query
                   .AsEnumerable()
                   .Select(p => new EditData()
                   {
                       Account = p.Account,
                       Name = p.Name, //人員名稱
                       DepCode = p.Code,
                       DepName = p.Name, //部門名稱
                       Arrival = p.Arrival.ToString("yyyy-MM-dd"),
                       //Dependent = p.Dependent,
                       //Title = p.Title,
                       //CityALL = p.City,//縣市全名
                       //Commuting = p.Commuting,
                       //Status = p.Status == true ? 1 : 0,
                       //Mail = p.Mail,
                       //City = p.City.Split('_')[0], // 取得縣市
                       //Area = p.City.Split('_')[1], //取得區域
                   })
                   .FirstOrDefault();

            //var aa = db.ZipCodes.Where(p => p.City == data.City && p.Area == data.Area).Select(p => p.NO).FirstOrDefault();
            //data.CityALLNo = aa;

            //var bb = GetCitySelect().Where(p => p.text == data.City).Select(p => p.value).FirstOrDefault();
            //data.CityNo = Convert.ToInt32(bb);

            for (int i = 0; i < data.Commuting.Split(';').Length; i++)
            {
                if (data.Commuting.Split(';')[i] == "1")
                {
                    data.checkbox1 = true;
                }
                else if (data.Commuting.Split(';')[i] == "2")
                {
                    data.checkbox2 = true;
                }
                else if (data.Commuting.Split(';')[i] == "3")
                {
                    data.checkbox3 = true;
                }
                else if (data.Commuting.Split(';')[i] == "4")
                {
                    data.checkbox4 = true;
                }
            }

            return data;
        }

        /// <summary>
        /// 新增/修改 資料
        /// </summary>
        /// <returns></returns>
        /// <param name="status"狀態; 1.新增; 2.修改></param>
        public bool update(EditData model, int status)
        {
            var success = false;
            var addDate = DateTime.Now;

            try
            {
                var employee = new Employee();
                var deptID = db.Depts.Where(p => p.Code == model.DepCode).Select(p => p.ID).FirstOrDefault();

                if (!Common.checkEmail(model.Mail))
                {
                    // 信箱格式驗證
                    throw new Exception("信箱格式錯誤!");
                }

                if (status == 1)
                {
                    #region 新增

                    if (EmployeeData.Where(p => p.Name == model.Account).Any())
                    {
                        // 帳號不可重複
                        throw new Exception("已有相同的帳號!");
                    }
                    //else if (EmployeeData.Where(p => p.Mail == model.Mail).Any())
                    //{
                    //    // 信箱不可重複
                    //    throw new Exception("已有相同的信箱!");
                    //}

                    employee = new Employee()
                    {
                        Account = model.Account,
                        DeptID = deptID,
                        Name = model.Name,
                        //Title = model.Title,
                        Arrival = Convert.ToDateTime(model.Arrival),
                        //Dependent = model.Dependent,
                        //Commuting = model.Commuting,
                        //City = model.City + "_" + model.Area,
                        //Mail = model.Mail,
                        //Status = model.Status == 1 ? true : false,
                        //Modified = DateTime.Now,
                    };

                    db.Employees.Add(employee);

                    #endregion
                }
                else if (status == 2)
                {
                    #region 編輯
                    employee = db.Employees.Where(p => p.Account == model.Account).FirstOrDefault();
                    if (employee == null)
                    {
                        throw new Exception("系統找不到指定資料。");
                    }
                    //else if (EmployeeData.Where(p => p.Mail == model.Mail).Count() > 1)
                    //{
                    //    // 信箱不可重複
                    //    throw new Exception("已有相同的信箱!");
                    //}

                    //employee.Account = model.Account;//帳號不可修改
                    employee.DeptID = deptID;
                    employee.Name = model.Name;
                    //employee.Title = model.Title;
                    employee.Arrival = Convert.ToDateTime(model.Arrival);
                    //employee.Dependent = model.Dependent;
                    //employee.Commuting = model.Commuting;
                    //employee.City = model.City + "_" + model.Area;
                    //employee.Mail = model.Mail;
                    //employee.Status = model.Status == 1 ? true : false;
                    //employee.Modified = DateTime.Now;
                    db.Entry(employee).State = EntityState.Modified;
                    #endregion
                }

                db.SaveChanges();
                success = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return success;

        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="Account"></param>
        public bool delete(string Account)
        {
            bool success = false;

            try
            {
                var employee = db.Employees.Where(p => p.Account == Account).FirstOrDefault();
                if (employee == null)
                {
                    throw new Exception("系統找不到指定資料。");
                }

                //if (employee.Status)
                //{
                //    throw new Exception("人員的狀態為在職中，不可刪除");
                //}

                db.Employees.Remove(employee);

                db.SaveChanges();

                success = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return success;
        }

        
    }
}
