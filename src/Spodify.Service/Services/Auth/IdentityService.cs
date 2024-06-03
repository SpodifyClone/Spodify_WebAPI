﻿using Spodify.Service.Interfaces.Auth;
using Microsoft.AspNetCore.Http;

namespace Spodify.Service.Services.Auth;

public class IdentityService : IIdentityService
{
    private readonly IHttpContextAccessor _accessor;
    public IdentityService(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    public int Id { 
        get {
            if (_accessor.HttpContext is null) return 0;
            var claim = _accessor.HttpContext.User.Claims.FirstOrDefault(op => op.Type == "Id");
            if (claim is null) return 0;
            else return int.Parse(claim.Value);
        }
    }

    public string UserName{
        get
        {
            if (_accessor.HttpContext is null) return "";
            var claim = _accessor.HttpContext.User.Claims.FirstOrDefault(op => op.Type == "UserName");
            if (claim is null) return "";
            else return claim.Value;
        }
    }

    public string Email {
        get
        {
            if (_accessor.HttpContext is null) return "";
            string type = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";
            var claim = _accessor.HttpContext.User.Claims.FirstOrDefault(op => op.Type == type);
            if (claim is null) return "";
            else return claim.Value;
        }
    }  
}
