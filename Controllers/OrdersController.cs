using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

using System.Text;
using System.Threading.Tasks;

using AbhayTradingCompanyInterface.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AbhayTradingCompanyInterface.Controllers
{
    public class OrdersController : Controller
    {

        List<Millname> millnames = new List<Millname>();
        List<Customer> customers = new List<Customer>();
        List<Broker> brokers = new List<Broker>();
        List<Shipto> shipto = new List<Shipto>();


        public OrdersController()
        {

            var task1 = Task.Run(async () => {

             
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://abhaytradingcompanyapi.herokuapp.com/api/millnames"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        this.millnames = JsonConvert.DeserializeObject<List<Millname>>(apiResponse);
                    }
                }



                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://abhaytradingcompanyapi.herokuapp.com/api/customers"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        this.customers = JsonConvert.DeserializeObject<List<Customer>>(apiResponse);
                    }
                }





                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://abhaytradingcompanyapi.herokuapp.com/api/brokers"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        this.brokers = JsonConvert.DeserializeObject<List<Broker>>(apiResponse);
                    }
                }


                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://abhaytradingcompanyapi.herokuapp.com/api/shipto"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        this.shipto = JsonConvert.DeserializeObject<List<Shipto>>(apiResponse);
                    }
                }


            });
            task1.Wait();
        }


    




        // GET: OrdersController
        public async Task<IActionResult> Index()
        {
            List<Order> allorders = new List<Order>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://abhaytradingcompanyapi.herokuapp.com/api/orders/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    allorders = JsonConvert.DeserializeObject<List<Order>>(apiResponse);
                }
            }
            return View(allorders);
        }

   



        // GET: OrdersController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Order reservation = new Order();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://abhaytradingcompanyapi.herokuapp.com/api/orders/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservation = JsonConvert.DeserializeObject<Order>(apiResponse);
                }
            }
            return View(reservation);
        }

        // GET: OrdersController/Create
        public ViewResult Create() => View();

        // POST: OrdersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order reservation)
        {
            Order receivedReservation = new Order();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(reservation), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://abhaytradingcompanyapi.herokuapp.com/api/orders", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    receivedReservation = JsonConvert.DeserializeObject<Order>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }












        // GET: OrdersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdersController/Delete/5


        // POST: OrdersController/Delete/5

        [HttpPost]
        public async Task<IActionResult> DeleteReservation(int ReservationId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://abhaytradingcompanyapi.herokuapp.com/api/orders/" + ReservationId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }





    
      

        [HttpPost]
        public async Task<JsonResult> GetMills(string prefix)
        {




                var result = (from a in this.millnames

                              where a.millname.Contains(prefix)

                              select new
                              {
                                  a.millname
                              });
                return Json(result);
            
        }





        [HttpPost]
        public async Task<JsonResult> GetCustomers(string prefix)
        {




            var result = (from a in this.customers

                          where a.customer.Contains(prefix)

                          select new
                          {
                              a.customer
                          });
            return Json(result);

        }




        [HttpPost]
        public async Task<JsonResult> GetShipTo(string prefix)
        {




            var result = (from a in this.shipto

                          where a.shipto.Contains(prefix)

                          select new
                          {
                              a.shipto
                          });
            return Json(result);

        }



        [HttpPost]
        public async Task<JsonResult> GetBrokers(string prefix)
        {




            var result = (from a in this.brokers

                          where a.broker.Contains(prefix)

                          select new
                          {
                              a.broker
                          });
            return Json(result);

        }


    }
}
