using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CBSP.DAL;
using System.Text;

namespace CBSP.Controllers
{
    public class SysRoleController : Controller
    {
        private CBDBModel db = new CBDBModel();

        public ActionResult Index()
        {
            return View(db.Sys_Role.ToList());
        }

        
        public ActionResult Create()
        {
            return View("~/Views/SysRole/Edit.cshtml");
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveSysRole([Bind(Include = "id,name")] Sys_Role sys_Role, string nodes)
        {
            
            int id = sys_Role.id;
            if (id > 0)
            {
                db.Entry(sys_Role).State = EntityState.Modified;
                List<Sys_Right> rightList = db.Sys_Right.Where(e => e.id == id).ToList();
                for (int i = 0; i < rightList.Count; i++)
                {
                    Sys_Right right = (Sys_Right)rightList[i];
                    db.Sys_Right.Remove(right);
                }
            }
            else
            {
                db.Sys_Role.Add(sys_Role);
                db.SaveChanges();
               
            }
            string[] nodeArray = nodes.Split(',');
            for (int i = 0; i < nodeArray.Length; i++)
            {
                Sys_RoleRight sysRoleRight = new Sys_RoleRight();
                sysRoleRight.roleId = sys_Role.id;
                sysRoleRight.rightId = Convert.ToInt32(nodeArray[i]);
                db.Sys_RoleRight.Add(sysRoleRight);
            }
            db.SaveChanges();


            return RedirectToAction("Index");
         }

        // GET: SysRole/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Role sys_Role = db.Sys_Role.Find(id);
            if (sys_Role == null)
            {
                return HttpNotFound();
            }
            return View(sys_Role);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] Sys_Role sys_Role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sys_Role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sys_Role);
        }

      

        // POST: SysRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sys_Role sys_Role = db.Sys_Role.Find(id);
            db.Sys_Role.Remove(sys_Role);
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
