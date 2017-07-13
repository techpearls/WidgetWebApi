using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : ApiController
    {
        private List<Widget> widgets = new List<Widget>();
        
        public HomeController() { }

        public HomeController(List<Widget> widgets)
        {
            this.widgets = widgets; 
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(widgets);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var w = widgets.Where(d => d.Id == id).FirstOrDefault();
            if(w == null)
            {
                return NotFound();
            }
            return Json(w);
        }

        [HttpPost]
        public IHttpActionResult Create(Widget w)
        {
            widgets.Add(w);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(Widget w)
        {
            var widget = widgets.Where(d => d.Id == w.Id).FirstOrDefault();
            if(widget == null)
            {
                return NotFound();
            }
            widget.Name = w.Name;
            widget.Description = w.Description;
            widget.Price = w.Price;
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var widget = widgets.Where(d => d.Id == id).FirstOrDefault();
            if(widget == null)
            {
                return NotFound();
            }
            widgets.Remove(widget);
            return Ok();
        }
    }
}
