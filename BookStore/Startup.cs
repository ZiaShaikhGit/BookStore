using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models.DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookStore
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
			services.AddRouting(options => options.LowercaseUrls = true);
			services.AddMemoryCache();
			services.AddSession();

			services.AddDbContextPool<BookstoreContext>(options =>
						options.UseSqlServer(Configuration.GetConnectionString("BookstoreContext")));

			services.AddControllersWithViews().AddNewtonsoftJson();
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
			}
			app.UseStaticFiles();
			app.UseRouting();
			app.UseSession();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapAreaControllerRoute(
					name: "admin",
					areaName: "Admin",
					pattern: "Admin/{controller=Book}/{action=Index}/{id?}"
					);

				//paging,sorting,filtering
				endpoints.MapControllerRoute(
					name: "",
					pattern: "{controller}/{action}/page/{pagenumber}/size/{pagesize}/sort/{sortfield}/{sortdirection}/filter/{author}/{genre}/{price}"
					);

				//paging,sorting,filtering
				endpoints.MapControllerRoute(
					name: "",
					pattern: "{controller}/{action}/page/{pagenumber}/size/{pagesize}/sort/{sortfield}/{sortdirection}"
					);


				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
