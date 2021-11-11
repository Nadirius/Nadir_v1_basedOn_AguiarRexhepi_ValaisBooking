using BLL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http.Headers;
using WAPIL;

namespace APP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBookingWebApiInvoker, BookingWebApiInvoker>();
            services.AddScoped<IHotelManager, HotelManager>();
            services.AddScoped<IPictureManager, PictureManager>();
            services.AddScoped<IReservationManager, ReservationManager>();
            services.AddScoped<IRoomManager, RoomManager>();

            services.AddControllersWithViews();

            services.AddSession();

            //services.AddCookiePolicy(c => new CookiePolicyOptions());

            // Adding HttpClient factory named "AtBookingAPI" into dedpendeny injection system
            // it make it accessecible from any point of the app
            services.AddHttpClient("AtBookingAPI", config =>
            {
                config.BaseAddress = new Uri(Configuration.GetValue<string>("RootWAPI"));
                config.DefaultRequestHeaders.Accept.Clear();
                config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseSession();

            //app.UseAuthorization();
        }
    }
}
