using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotNetAcademy.BLL.DTO;
using dotNetAcademy.BLL.Rules;
using dotNetAcademy.BLL.Services.CustomerService;
using dotNetAcademy.BLL.Services.ParticipantService;
using dotNetAcademy.WEB.Models;
using dotNetAcademy.WEB.ViewModels.Customer;
using dotNetAcademy.WEB.ViewModels.Error;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration;

namespace dotNetAcademy.WEB.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IParticipantService _participantService;
        private readonly IMapper _mapper;
       // private readonly UserManager<CustomerDTO> _userManager;

        public CustomersController(ICustomerService customerService,IParticipantService participantService,IMapper mapper/*, UserManager<CustomerDTO> userManager*/)
        {
            _mapper = mapper;
            _customerService = customerService;
            _participantService = participantService;
            //_userManager = userManager;
        }

        // GET: Customers
        public ActionResult Index()
        {
            var viewmodel = new AllCustomersViewModel();
            viewmodel.Customers = _customerService.GetAll();
            viewmodel.Members = viewmodel.Customers.Sum(x=>x.MaxParticipants);
            return View(viewmodel);
        }

        // GET: Customers/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }

        // GET: Customers/Create
        public ActionResult Create()
        {

            var participants = _customerService.GetAll().Sum(x => x.MaxParticipants);
            if (MaxAmount.IsReached(MaxAmount.MaxParticipantsInSystem,participants))
            {
                return View();
            }
            else
            {
                var viewmodel = new FoutMeldingViewModel
                {
                    Fout = "too many participants"
                };
                return RedirectToAction(nameof(Error));
            }
           
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name,StreetAndNumber,City,Email,MaxParticipants")] CustomerDTO c)
        {
            if (ModelState.IsValid)
            {
                _customerService.Add(c);
                //_userManager.AddToRoleAsync(c, "Customer");
                _customerService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
            
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(string id)
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
        public ActionResult Delete(string id)
        {
            //delete related data
            var participants = _participantService.GetAll().Where(x => x.CustomerId == id);
            foreach (var item in participants)
            {
                _participantService.Delete(item.Id);
            }
            _customerService.Delete(id);
            _customerService.Save();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Error(string message)
        {
            var viewmodel = new FoutMeldingViewModel();
            viewmodel.Fout = message;
            return View(viewmodel);
        }
    }
}