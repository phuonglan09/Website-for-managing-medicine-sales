﻿using Doctors.Base.Session;
using Newtonsoft.Json;

namespace Doctorskin.Areas.Admin.Helper
{
    public static class Sessions
    {
        public static AdminSession GetUser(IHttpContextAccessor _httpContextAccessor)
        {
            var userSession = _httpContextAccessor.HttpContext.Session.GetString("manager");
            if (userSession != null)
            {
                return JsonConvert.DeserializeObject<AdminSession>(userSession);
            }
            return null;
        }
    }
}
