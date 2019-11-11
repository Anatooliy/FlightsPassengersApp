using FPApp.Client.Helpers;
using FPApp.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FPApp.Client.Controllers
{
    public class FlightsController : Controller
    {
        // GET: Flights
        public async Task<ActionResult> Index()
        {
            var flights = await GetData<FlightViewModel>("api/Flights");

            return View(flights.OrderBy(f => f.FlightTime));
        }

        // GET: Flights/Details/5
        public async Task<ActionResult> Details(int id, bool showAll = true)
        {
            var flight = (await GetSingleData<FlightViewModel>("api/Flights", id, showAll));

            if(flight == null)
            {
                return HttpNotFound();
            }            

            return View(flight);
        }

        // GET: Flights/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flights/Create
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

        // GET: Flights/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Flights/Edit/5
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

        // GET: Flights/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Flights/Delete/5
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

        private async Task<List<T>> GetData<T>(string url)
        {
            var client = HttpClientHelper.GetHttpClient();            
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<T>>();
            }
            return null;
        }

        private async Task<T> GetSingleData<T>(string url, int id, bool showAll = true) where T : class
        {
            var client = HttpClientHelper.GetHttpClient();
            
            HttpResponseMessage response = await client.GetAsync($"{url}/{id}?showAll={showAll}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            return null;
        }
    }
}
