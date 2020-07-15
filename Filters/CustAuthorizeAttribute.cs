using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstChe.Filters
{
    public class CustAuthorizeAttribute : AuthorizeAttribute
    {
        private bool isLocalAllowed;

        public CustAuthorizeAttribute (bool allowParam)
        {
            isLocalAllowed = allowParam;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Request.IsLocal)
            {

                return isLocalAllowed;
            }
            else
            {
                return true;

            }
        }
    }
}