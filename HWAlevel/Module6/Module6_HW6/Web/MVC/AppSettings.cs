﻿using Infrastructure.Identity;

namespace MVC;

public class AppSettings
{
	public string BasketUrl { get; set; }
	public string CatalogUrl { get; set; }
    public int SessionCookieLifetimeMinutes { get; set; }    
    public string CallBackUrl { get; set; }
    public string IdentityUrl { get; set; }
}
