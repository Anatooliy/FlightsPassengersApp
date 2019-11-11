using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FPApp.DAL.EF;
using FPApp.DAL.Entities;
using FPApp.Service.Models;

namespace FPApp.Service.Controllers
{
    public class FlightsController : ApiController
    {
        private FPContext db = new FPContext();

        // GET: api/Flights
        public IEnumerable<FlightDTO> GetFlights()
        {
            return db.Flights.Select(f => new FlightDTO {
                Id = f.FlightId,
                CityFrom = f.CityFrom.CityName,
                CityTo = f.CityTo.CityName,
                FlightTime = f.FlightTime
            }).ToList();
        }

        // GET: api/Flights/5
        [ResponseType(typeof(FlightDTO))]
        public IHttpActionResult GetFlight(int id, bool showAll = true)
        {
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return NotFound();
            }

            FlightDTO flightInfo = new FlightDTO
            {
                Id = flight.FlightId,
                CityFrom = flight.CityFrom.CityName,
                CityTo = flight.CityTo.CityName,
                FlightTime = flight.FlightTime
            };            

            if(flight.FlightsPass != null)
            {
                var passengerQuery = flight.FlightsPass.AsQueryable();
                if (!showAll)
                {
                    passengerQuery = passengerQuery.Where(p => !p.IsCheckedIn);
                }

                flightInfo.passengerInfos = passengerQuery.Select(p => new PassengerInfoDTO {
                    Id = p.PassengerId,
                    FirstName = p.Passenger.FirstName,
                    LastName = p.Passenger.LastName,
                    IsChecked = p.IsCheckedIn
                }).ToList();          
            }            

            return Ok(flightInfo);
        }

        // PUT: api/Flights/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFlight(int id, [FromBody]FlightPassengerDTO fpDTO)
        {
            var fp = db.FlightsPassengers
                .FirstOrDefault(f => (f.FlightId == fpDTO.FlightId && f.PassengerId == fpDTO.PassengerId));

            if(fp == null)
            {
                return NotFound();
            }

            fp.IsCheckedIn = fpDTO.IsChecked;

            db.Entry(fp).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {                
                    throw;               
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Flights
        [ResponseType(typeof(Flight))]
        public async Task<IHttpActionResult> PostFlight(Flight flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Flights.Add(flight);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = flight.FlightId }, flight);
        }

        // DELETE: api/Flights/5
        [ResponseType(typeof(Flight))]
        public async Task<IHttpActionResult> DeleteFlight(int id)
        {
            Flight flight = await db.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }

            db.Flights.Remove(flight);
            await db.SaveChangesAsync();

            return Ok(flight);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FlightExists(int id)
        {
            return db.Flights.Count(e => e.FlightId == id) > 0;
        }
    }
}