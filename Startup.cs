using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BigMammaPizzaGroup
{
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                #region snippet1
                services.AddMvc()
                    .AddRazorPagesOptions(options =>
                    {
                        options.Conventions.AuthorizePage("/ChangeItem");
                        options.Conventions.AuthorizeFolder("/Change");
                        options.Conventions.AllowAnonymousToPage("");
                        options.Conventions.AllowAnonymousToFolder("");
                    })
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
                #endregion

                services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie();
            }

            public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    //app.UseDatabaseErrorPage();
                }
                else
                {
                    app.UseExceptionHandler("/Error");
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseStaticFiles();

                app.UseAuthentication();

                //app.UseMvc();
            }
        }
    }
