﻿using My.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class Default1Controller : Controller
    {
        //
        // GET: /Default1/

        public ActionResult Index()
        {
            List<Class1> aList = new List<Class1>();
            Class1 a = new Class1();
            a.string2 = "aaa";
            a.int1 = 1;
            a.date = new DateTime(2012, 2, 2);
            a.booltry = true;
            Class1 b = new Class1();
            b.string2 = "bbb";
            b.int1 = 1;
            b.date = new DateTime(2012, 4, 2);
            b.booltry = false;

            aList.Add(a);
            aList.Add(b);
            return View(aList);
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Details(Class1 class1)
        {
            return View();
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            List<Class1> aList = new List<Class1>();
            Class1 a = new Class1();
            a.string2 = "aaa";
            aList.Add(a);
            return View(aList);
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id)
        {
            List<Class1> aList = new List<Class1>();
            Class1 a = new Class1();
            a.string2 = "aaa";
            a.int1 = 1;
            a.date = new DateTime(2012, 2, 2);
            a.booltry = true;
            Class1 b = new Class1();
            b.string2 = "bbb";
            b.int1 = 1;
            b.date = new DateTime(2012, 4, 2);
            b.booltry = false;

            aList.Add(a);
            aList.Add(b);
            return View(aList);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
