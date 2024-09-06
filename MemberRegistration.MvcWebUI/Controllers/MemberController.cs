using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MemberRegistration.Business.Abstract;
using MemberRegistration.Entities.Concrete;
using MemberRegistration.MvcWebUI.Filters;
using MemberRegistration.MvcWebUI.Models;

namespace MemberRegistration.MvcWebUI.Controllers
{
    public class MemberController : Controller
    {
        private IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public ActionResult Add()
        {
            return View(new MemberAddViewModule());
        }

        [HttpPost]
        [ExceptionHandler]
        public ActionResult Add(Member member)
        {
            _memberService.Add(member);
            return View(new MemberAddViewModule());
        }
    }
}