using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotNetAcademy.BLL.Services.CustomerService;
using dotNetAcademy.BLL.Services.ParticipantService;
using dotNetAcademy.WEB.ViewModels.Participant;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotNetAcademy.WEB.Controllers
{
    public class ParticipantsController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IParticipantService _participantService;
        private readonly IMapper _mapper;

        public ParticipantsController(ICustomerService customerService, IParticipantService participantService, IMapper mapper)
        {
            _mapper = mapper;
            _customerService = customerService;
            _participantService = participantService;
        }


        // GET: Participants
        public ActionResult Index()
        {
            var viewmodel = new AllParticipantsViewModel();
            viewmodel.Participants = _participantService.GetAll();
            return View(viewmodel);
        }

        public ActionResult IndexFromCustomer(int id)
        {
            var viewmodel = new AllParticipantsViewModel();
            //todo: erase 1 database-call with parameter passing in views
            viewmodel.CustomerName = _customerService.GetById(id).Name;
            viewmodel.Participants = _participantService.GetAll().Where(x => x.Customer.Id == id);
            return View(viewmodel);
        }

        // GET: Participants/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Participants/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Participants/Create
        public ActionResult CreateForCustomer(int id)
        {
            //todo:add directly to customer list
            return View();
        }

        // POST: Participants/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Participants/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Participants/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Participants/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Participants/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}