// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Authentication.Cookies
{
    /// <summary>
    /// Configuration options for <see cref="CookieAuthenticationOptions"/>.
    /// </summary>
    public class CookieAuthenticationOptions : AuthenticationSchemeOptions
    {
        private string _cookieName;

        /// <summary>
        /// Create an instance of the options initialized with the default values
        /// </summary>
        public CookieAuthenticationOptions()
        {
            ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            ExpireTimeSpan = TimeSpan.FromDays(14);
            SlidingExpiration = true;
            CookieSameSite = SameSiteMode.Strict;
            CookieHttpOnly = true;
            CookieSecure = CookieSecurePolicy.SameAsRequest;
            Events = new CookieAuthenticationEvents();
        }

        /// <summary>
        /// Determines the cookie name used to persist the identity. The default value is ".AspNetCore.Cookies".
        /// This value should be changed if you change the name of the AuthenticationScheme, especially if your
        /// system uses the cookie authentication handler multiple times.
        /// </summary>
        public string CookieName
        {
            get { return _cookieName; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _cookieName = value;
            }
        }

        /// <summary>
        /// Determines the domain used to create the cookie. Is not provided by default.
        /// </summary>
        public string CookieDomain { get; set; }

        /// <summary>
        /// Determines the path used to create the cookie. The default value is "/" for highest browser compatibility.
        /// </summary>
        public string CookiePath { get; set; }

        /// <summary>
        /// Determines if the browser should allow the cookie to be attached to same-site or cross-site requests. The
        /// default is Strict, which means the cookie is only allowed to be attached to same-site requests.
        /// </summary>
        public SameSiteMode CookieSameSite { get; set; }

        /// <summary>
        /// Determines if the browser should allow the cookie to be accessed by client-side javascript. The
        /// default is true, which means the cookie will only be passed to http requests and is not made available
        /// to script on the page.
        /// </summary>
        public bool CookieHttpOnly { get; set; }

        /// <summary>
        /// Determines if the cookie should only be transmitted on HTTPS request. The default is to limit the cookie
        /// to HTTPS requests if the page which is doing the SignIn is also HTTPS. If you have an HTTPS sign in page
        /// and portions of your site are HTTP you may need to change this value.
        /// </summary>
        public CookieSecurePolicy CookieSecure { get; set; }

        /// <summary>
        /// If set this will be used by the CookieAuthenticationHandler for data protection.
        /// </summary>
        public IDataProtectionProvider DataProtectionProvider { get; set; }

        /// <summary>
        /// Controls how much time the cookie will remain valid from the point it is created. The expiration
        /// information is in the protected cookie ticket. Because of that an expired cookie will be ignored 
        /// even if it is passed to the server after the browser should have purged it 
        /// </summary>
        public TimeSpan ExpireTimeSpan { get; set; }

        /// <summary>
        /// The SlidingExpiration is set to true to instruct the handler to re-issue a new cookie with a new
        /// expiration time any time it processes a request which is more than halfway through the expiration window.
        /// </summary>
        public bool SlidingExpiration { get; set; }

        /// <summary>
        /// The LoginPath property informs the handler that it should change an outgoing 401 Unauthorized status
        /// code into a 302 redirection onto the given login path. The current url which generated the 401 is added
        /// to the LoginPath as a query string parameter named by the ReturnUrlParameter. Once a request to the
        /// LoginPath grants a new SignIn identity, the ReturnUrlParameter value is used to redirect the browser back  
        /// to the url which caused the original unauthorized status code.
        /// </summary>
        public PathString LoginPath { get; set; }

        /// <summary>
        /// If the LogoutPath is provided the handler then a request to that path will redirect based on the ReturnUrlParameter.
        /// </summary>
        public PathString LogoutPath { get; set; }

        /// <summary>
        /// The AccessDeniedPath property informs the handler that it should change an outgoing 403 Forbidden status
        /// code into a 302 redirection onto the given path.
        /// </summary>
        public PathString AccessDeniedPath { get; set; }

        /// <summary>
        /// The ReturnUrlParameter determines the name of the query string parameter which is appended by the handler
        /// when a 401 Unauthorized status code is changed to a 302 redirect onto the login path. This is also the query 
        /// string parameter looked for when a request arrives on the login path or logout path, in order to return to the 
        /// original url after the action is performed.
        /// </summary>
        public string ReturnUrlParameter { get; set; }

        /// <summary>
        /// The Provider may be assigned to an instance of an object created by the application at startup time. The handler
        /// calls methods on the provider which give the application control at certain points where processing is occurring. 
        /// If it is not provided a default instance is supplied which does nothing when the methods are called.
        /// </summary>
        public new CookieAuthenticationEvents Events
        {
            get { return (CookieAuthenticationEvents)base.Events; }
            set { base.Events = value; }
        }

        /// <summary>
        /// The TicketDataFormat is used to protect and unprotect the identity and other properties which are stored in the
        /// cookie value. If not provided one will be created using <see cref="DataProtectionProvider"/>.
        /// </summary>
        public ISecureDataFormat<AuthenticationTicket> TicketDataFormat { get; set; }

        /// <summary>
        /// The component used to get cookies from the request or set them on the response.
        ///
        /// ChunkingCookieManager will be used by default.
        /// </summary>
        public ICookieManager CookieManager { get; set; }

        /// <summary>
        /// An optional container in which to store the identity across requests. When used, only a session identifier is sent
        /// to the client. This can be used to mitigate potential problems with very large identities.
        /// </summary>
        public ITicketStore SessionStore { get; set; }
    }
}
