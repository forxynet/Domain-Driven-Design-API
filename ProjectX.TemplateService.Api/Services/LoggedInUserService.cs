﻿using ProjectX.Template.Application.Contracts;
using System.Security.Claims;

namespace ProjectX.Template.Api.Services {
    public class LoggedInUserService : ILoggedInUserService {
        private readonly IHttpContextAccessor _contextAccessor;
        public LoggedInUserService(IHttpContextAccessor httpContextAccessor) {
            _contextAccessor = httpContextAccessor;
        }

        public string UserId => _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
