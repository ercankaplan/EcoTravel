namespace Catalog.API
{
    public static class ApplicationBuilderExtensions
    {
        public static void Configure(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            { 
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.API v1"));

            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints=> endpoints.MapControllers());



        }
    }
}
