using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using dotNetAcademy.BLL.DTO;
using dotNetAcademy.BLL.Rules;
using dotNetAcademy.BLL.Services.CustomerService;
using dotNetAcademy.BLL.Services.ParticipantService;
using dotNetAcademy.WEB.ViewModels.Error;
using dotNetAcademy.WEB.ViewModels.Participant;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace dotNetAcademy.WEB.Controllers
{
    public class ParticipantsController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IParticipantService _participantService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ParticipantsController(ICustomerService customerService, IParticipantService participantService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _customerService = customerService;
            _participantService = participantService;
            _httpContextAccessor = httpContextAccessor;
        }


        // GET: Participants
        public ActionResult Index()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (User.IsInRole("Customer"))
            {
                return RedirectToAction("IndexFromCustomer", "Participants", new {@id = userId});
            }

            
            var viewmodel = new AllParticipantsViewModel();
            viewmodel.Participants = _participantService.GetAll();
            return View(viewmodel);
        }

        public ActionResult IndexFromCustomer(string id)
        {
            var viewmodel = new AllParticipantsViewModel();
            //todo: erase 1 database-call with parameter passing in views
            viewmodel.Customer = _customerService.GetById(id);
            viewmodel.Participants = _participantService.GetAll()
                .Where(x => x.Customer.Id==id)
                .OrderBy(x=>x.StartDate);
            return View(viewmodel);
        }

        // GET: Participants/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }

        // GET: Participants/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Participants/Create
        public ActionResult CreateForCustomer(string id)
        {
            var customer = _customerService.GetById(id);
            var model = new ParticipantDTO();
            if (MaxAmount.IsReached(customer.MaxParticipants, customer.Participants.Count()))
            {
            model.Customer = _customerService.GetById(id);
            }
            return View(model);
        }

        // POST: Participants/CreateForCustomer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateForCustomer(string id,[Bind("FirstName,LastName,Email,StartDate,EndDate")] ParticipantDTO p)
        {
            try
            {
                p.Customer = _customerService.GetById(id);
                if (ModelState.IsValid)
                {
                    if (DurationDotNetAcademy.IsLongEnough(p.StartDate, p.EndDate)) { 

                    _participantService.Add(p);
                    _participantService.Save();
                    return RedirectToAction("IndexFromCustomer","Participants",new {@id =id});
                    }

                    return RedirectToAction("CreateForCustomer", "Participants", new {@id = id});
                }

                return View();
            }
            catch
            {
                return View();
            }
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
        public ActionResult Edit(string id)
        {
            var participant = _participantService.GetById(id);
            participant.Customer = null;
            if (participant == null)
            {
                return NotFound();
            }
            return View(participant);
        }

        // POST: Participants/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, [Bind("Id,FirstName,LastName,Email,StartDate,EndDate,CustomerId")] ParticipantDTO p)
        {
            try
            {
                //p.Customer = _customerService.GetById(p.CustomerId);
                if (ModelState.IsValid)
                {
                    _participantService.Update(id, p);
                    _participantService.Save();
                }
                
                return RedirectToAction("IndexFromCustomer", "Participants", new { @id = p.CustomerId });
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Participants/Delete/5
        public ActionResult Delete(string id)
        {
            _participantService.Delete(id);
            _participantService.Save();
            return RedirectToAction(nameof(Index));
        }

        //// POST: Participants/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}