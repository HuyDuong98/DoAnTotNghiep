using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

namespace QLNhaSachFahasa
{
    public class HasCredentialAttribute : AuthorizeAttribute
    {
        public string RoleId { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = (Common.UserLogin)HttpContext.Current.Session[Common.CommonConstants.USER_SEESION];
            if (session == null)
            {
                return false;
            }
            List<string> privilegeLevels = this.GetCredentialByLoggedInUser(session.UserName);
            if (privilegeLevels.Contains(this.RoleId) || session.GroupID == CommonConstants.ADMIN_GROUP)
            {
                return true;
            }
            else { return false; }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName= "~/Areas/Admin/Views/Shared/Error401.cshtml"
        };     
        }
        private List<string> GetCredentialByLoggedInUser(string userName)
        {
            var credentials = (List<string>)HttpContext.Current.Session[Common.CommonConstants.SESSION_CREDENTIALS];
            return credentials;
        }
    }

}