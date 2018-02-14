using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactInfo_Project.ViewModel;
using ContactInfo_Project.Models;

namespace ContactInfo_Project.Controllers
{
    public class ContactListController : Controller
    {
        // GET: ContactList
        public ActionResult Index()
        {
            ContactListClient cc = new ContactListClient();
            ViewBag.listContactInfo = cc.findAll();

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(ContactListViewModel cvm)
        {
            ContactListClient CC = new ContactListClient();
            CC.Create(cvm.contactlist);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            ContactListClient CC = new ContactListClient();
            CC.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ContactListClient CC = new ContactListClient();
            ContactListViewModel CVM = new ContactListViewModel();
            CVM.contactlist = CC.find(id);
            return View("Edit", CVM);
        }
        [HttpPost]
        public ActionResult Edit(ContactListViewModel CVM)
        {
            ContactListClient CC = new ContactListClient();
            CC.Edit(CVM.contactlist);
            return RedirectToAction("Index");
        }
    }
}