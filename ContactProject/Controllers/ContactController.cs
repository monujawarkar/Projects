using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactProject.Models;
using ContactProject.ViewModel;

namespace ContactProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            ContactListClient CC = new ContactListClient();
            ViewBag.listContact = CC.findAll();

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(ContactViewModelList cvm)
        {
                ContactListClient CC = new ContactListClient();
                CC.Create(cvm.contactModelList);
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
            ContactViewModelList CVM = new ContactViewModelList();
            CVM.contactModelList = CC.find(id);
            return View("Edit", CVM);
        }
        [HttpPost]
        public ActionResult Edit(ContactViewModelList CVM)
        {
            ContactListClient CC = new ContactListClient();
            CC.Edit(CVM.contactModelList);
            return RedirectToAction("Index");
        }
    }
}