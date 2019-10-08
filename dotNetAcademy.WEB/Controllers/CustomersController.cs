using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotNetAcademy.BLL.DTO;
using dotNetAcademy.BLL.Services.CustomerService;
using dotNetAcademy.BLL.Services.ParticipantService;
using dotNetAcademy.WEB.ViewModels.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration;

namespace dotNetAcademy.WEB.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IParticipantService _participantService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService,IParticipantService participantService,IMapper mapper)
        {
            _mapper = mapper;
            _customerService = customerService;
            _participantService = participantService;
        }

        // GET: Customers
        public ActionResult Index()
        {
            var viewmodel = new AllCustomersViewModel();
            viewmodel.Customers = _customerService.GetAll();
            return View(viewmodel);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name,StreetAndNumber,City,Email,MaxParticipants")] CustomerDTO c)
        {
            if (ModelState.IsValid)
            {
                _customerService.Add(c);
                _customerService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
            
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _customerService.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,Name,StreetAndNumber,City,Email,MaxParticipants")] CustomerDTO c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //TODO:check if changes are made correctly
                    _customerService.Update(c.Id,c);
                    _customerService.Save();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            _customerService.Delete(id);
            _customerService.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}