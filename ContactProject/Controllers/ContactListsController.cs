using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ContactProject;

namespace ContactProject.Controllers
{
    public class ContactListsController : ApiController
    {
        private ContactInfoEntities db = new ContactInfoEntities();

        // GET: api/ContactLists
        public IQueryable<ContactList> GetContactLists()
        {
            return db.ContactLists;
        }

        // GET: api/ContactLists/5
        [ResponseType(typeof(ContactList))]
        public IHttpActionResult GetContactList(int id)
        {
            ContactList contactList = db.ContactLists.Find(id);
            if (contactList == null)
            {
                return NotFound();
            }

            return Ok(contactList);
        }

        // PUT: api/ContactLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContactList(int id, ContactList contactList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactList.SNo)
            {
                return BadRequest();
            }

            db.Entry(contactList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ContactLists
        [ResponseType(typeof(ContactList))]
        public IHttpActionResult PostContactList(ContactList contactList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ContactLists.Add(contactList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contactList.SNo }, contactList);
        }

        // DELETE: api/ContactLists/5
        [ResponseType(typeof(ContactList))]
        public IHttpActionResult DeleteContactList(int id)
        {
            ContactList contactList = db.ContactLists.Find(id);
            if (contactList == null)
            {
                return NotFound();
            }

            db.ContactLists.Remove(contactList);
            db.SaveChanges();

            return Ok(contactList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactListExists(int id)
        {
            return db.ContactLists.Count(e => e.SNo == id) > 0;
        }
    }
}