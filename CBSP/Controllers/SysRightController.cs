using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CBSP.DAL;
using Newtonsoft.Json;
using CBSP.Models;

namespace CBSP.Controllers
{
    public class SysRightController : Controller
    {
        private CBDBModel db = new CBDBModel();

        // GET: SysRight
        public ActionResult Index()
        {
            //return View(db.Sys_Right.ToList());
            return View();    
        }

        [HttpGet]
        public string GetNodes()
        {
            List<RightNodeModel> rightNodes = new List<RightNodeModel>();
            List<Sys_Right> lists = db.Sys_Right.ToList();
            for (int i = 0; i < lists.Count; i++)
            {
                Sys_Right right = (Sys_Right)lists[i];

                RightNodeModel node = new RightNodeModel();
                node.id = right.id;
                node.name = right.name;
                node.pId = right.parent_id;
                node.menuUrl = right.url;
                node.menuIcon = right.icon;
                node.open = true;
                //node.isParent = true;
                rightNodes.Add(node);
            }
            string json = JsonConvert.SerializeObject(rightNodes);
            return json;
        }

        // GET: SysRight/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Right sys_Right = db.Sys_Right.Find(id);
            if (sys_Right == null)
            {
                return HttpNotFound();
            }
            return View(sys_Right);
        }

        // GET: SysRight/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveSysRight([Bind(Include = "id,parent_id,name,url,icon")] Sys_Right sys_Right)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Sys_Right.Add(sys_Right);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            int id = sys_Right.id;
            if (id > 0)
            {
                db.Entry(sys_Right).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                db.Sys_Right.Add(sys_Right);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        // GET: SysRight/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Right sys_Right = db.Sys_Right.Find(id);
            if (sys_Right == null)
            {
                return HttpNotFound();
            }
            return View(sys_Right);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,parent_id,name,url,icon")] Sys_Right sys_Right)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sys_Right).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sys_Right);
        }

        // GET: SysRight/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Right sys_Right = db.Sys_Right.Find(id);
            if (sys_Right == null)
            {
                return HttpNotFound();
            }
            return View(sys_Right);
        }

        // POST: SysRight/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sys_Right sys_Right = db.Sys_Right.Find(id);
            db.Sys_Right.Remove(sys_Right);
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
