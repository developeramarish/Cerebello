﻿using System.ComponentModel;
using System.Net;
using System.Web.Mvc;

namespace CerebelloWebRole.Code
{
    public class JsonUnauthorizedResult : JsonResult
    {
        public JsonUnauthorizedResult()
            : this(null)
        {
        }

        public JsonUnauthorizedResult([Localizable(true)] string statusDescription)
        {
            this.Data = this.Data ?? new JsonError()
            {
                success = false,
                text = statusDescription,
                error = true,
                errorType = "unauthorized",
                errorMessage = statusDescription,
                status = (int)HttpStatusCode.Unauthorized,
            };

            this.StatusDescription = statusDescription;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            base.ExecuteResult(context);

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            if (StatusDescription != null)
                context.HttpContext.Response.StatusDescription = StatusDescription;
        }

        [Localizable(true)]
        public string StatusDescription { get; private set; }
    }
}