using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CBSP.DAL;
using CBSP.Models;
using System.Text;

namespace CBSP.Controllers
{
    public class SysUserController : Controller
    {
        private CBDBModel db = new CBDBModel();

        // GET: SysUser
        public ActionResult Index()
        {
            return View(db.Sys_User.ToList());
        }


        public void initData()
        {
          
            List<SelectListItem> items1 = new List<SelectListItem>()
            {
                new SelectListItem(){Text="大专", Value="大专"},
                new SelectListItem(){Text="本科", Value="本科"},
                new SelectListItem(){Text="硕士", Value="硕士"},
                new SelectListItem(){Text="博士", Value="博士"}
            };

            SelectList generateList1 = new SelectList(items1, "Value", "Text");
            ViewData["educationList"] = generateList1;

            List<SelectListItem> items2 = new List<SelectListItem>()
            {
                new SelectListItem(){Text="男", Value="男"},
                new SelectListItem(){Text="女", Value="女"}
            };
            SelectList generateList6 = new SelectList(items2, "Value", "Text");
            ViewData["sexList"] = generateList6;

            List<SelectListItem> roleInfoList =  db.Database.SqlQuery<SelectListItem>(" select cast(id as varchar(50)) as value, name as text from Sys_Role ").ToList();
            MultiSelectList generateList2 = new MultiSelectList(roleInfoList, "Value", "Text");
            ViewData["roleList"] = generateList2;

            List<SelectListItem> dutyInfoList = db.Database.SqlQuery<SelectListItem>(" select cast(id as varchar(50)) as value, name as text from Dict_Duty ").ToList();
            MultiSelectList generateList21 = new MultiSelectList(dutyInfoList, "Value", "Text");
            ViewData["dutyList"] = generateList21;

            
        }

        // GET: SysUser/Create
        public ActionResult Create()
        {
            initData();
            return View("~/Views/SysUser/Edit.cshtml");
        }
        public ActionResult Edit(int id)
        {
            initData();

            SysUserModel model = new SysUserModel();
            Sys_User sys_User = db.Sys_User.Find(id);

            model.id = id;
            model.major = sys_User.major;
            model.name = sys_User.name;
            model.sex = sys_User.sex;

            // 角色
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select cast(roleid as varchar(50)) as value from Sys_UserRole where userid= " + id);
            List<SelectListItem> roleInfoList = db.Database.SqlQuery<SelectListItem>(sbSQL.ToString()).ToList();
            var list = new List<String>();
            foreach (var SelectListItem in roleInfoList)
            {
                list.Add(SelectListItem.Value);
            }
            model.roleId = list.ToArray();

            // 职务
            sbSQL = new StringBuilder();
            sbSQL.Append(" select cast(roleid as varchar(50)) as value from Sys_UserDuty where userid= " + id);
            List<SelectListItem> dutyInfoList = db.Database.SqlQuery<SelectListItem>(sbSQL.ToString()).ToList();
            list = new List<String>();
            foreach (var SelectListItem in dutyInfoList)
            {
                list.Add(SelectListItem.Value);
            }
            model.dutyId = list.ToArray();

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveSysUser(SysUserModel model)
        {
          
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}
            //else
            //{
                Sys_User sys_User = new Sys_User();
                sys_User.id = model.id;
                sys_User.name = model.name;
                sys_User.sex = model.sex;
                sys_User.major = model.major;
                sys_User.education = model.education;
                if (model.id > 0)
                {
                    // 修改
                    db.Entry(sys_User).State = EntityState.Modified;
                    db.SaveChanges();

                    StringBuilder sbSQL = new StringBuilder();
                    sbSQL.Append(" select * from Sys_UserRole where userId = " + model.id);
                    List<Sys_UserRole> roleList = db.Database.SqlQuery<Sys_UserRole>(sbSQL.ToString()).ToList();
                    for (int i = 0; i < roleList.Count; i++)
                    {
                    Sys_UserRole role = (Sys_UserRole)roleList[i];
                        db.Sys_UserRole.Remove(role);
                    }

                    sbSQL = new StringBuilder();
                    sbSQL.Append(" select * from Sys_UserDuty where userId = " + model.id);
                    List<Sys_UserDuty> dutyList = db.Database.SqlQuery<Sys_UserDuty>(sbSQL.ToString()).ToList();
                    for (int i = 0; i < dutyList.Count; i++)
                    {
                    Sys_UserDuty duty = (Sys_UserDuty)dutyList[i];
                        db.Sys_UserDuty.Remove(duty);
                    }
            }
                else
                {
                    db.Sys_User.Add(sys_User);
                    db.SaveChanges();
                }


            //添加用户角色表
            foreach (string obj in model.roleId)
            {
                Sys_UserRole userRole = new Sys_UserRole();
                userRole.userId = sys_User.id;
                userRole.roleId = Convert.ToInt32(obj);
                db.Sys_UserRole.Add(userRole);
            }

            // 添加用户职务
            foreach (string obj in model.dutyId)
            {
                Sys_UserDuty userDuty = new Sys_UserDuty();
                userDuty.userId = sys_User.id;
                userDuty.dutyId = Convert.ToInt32(obj);
                db.Sys_UserDuty.Add(userDuty);
            }
            db.SaveChanges();

            return RedirectToAction("Index");
            //}
        }

       
        public ActionResult Delete(int id)
        {
            Sys_User sys_User = db.Sys_User.Find(id);
            db.Sys_User.Remove(sys_User);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
