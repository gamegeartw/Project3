﻿using Furion;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Project3.Web.Core
{
    public class MyRazorFilterAttribute:ResultFilterAttribute
    {
        private readonly ILogger<MyRazorFilterAttribute> _logger;

        public MyRazorFilterAttribute()
        {
            _logger= App.GetService<ILogger<MyRazorFilterAttribute>>();

        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation("OnResultExecuting");
            base.OnResultExecuting(context);
        }
    }
}
