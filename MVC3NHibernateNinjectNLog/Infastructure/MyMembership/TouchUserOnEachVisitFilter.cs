using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC3NHibernateNinjectNLog.Infastructure.MyMembership
{
    public class TouchUserOnEachVisitFilter : ActionFilterAttribute
    {
        private readonly IUserServiceFactory _userServiceFactory;
        private IUserService _userService;

        private IUserService UserService
        {
            get { return _userService ?? (_userService = _userServiceFactory.Make()); }
        }

        public TouchUserOnEachVisitFilter()
            : this(new AspNetMembershipProviderUserServiceFactory())
        {
        }

        public TouchUserOnEachVisitFilter(IUserServiceFactory userServiceFactory)
        {
            _userServiceFactory = userServiceFactory;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = filterContext.RequestContext.HttpContext.User;
            if (user.Identity.IsAuthenticated)
                UserService.Touch(user.Identity.Name);
        }
    }
}