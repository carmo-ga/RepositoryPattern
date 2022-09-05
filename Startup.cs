using AutoMapper;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Profiles;
using RepositoryPattern.Infrastructure;
using RepositoryPattern.Domain.UseCases;
using RepositoryPattern.Configurations;
using RepositoryPattern.Domain.Infrastructure.Data;
using RepositoryPattern.Domain.Interfaces.Repositories;

namespace RepositoryPattern
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options => options.UseSqlite(Configuration.GetConnectionString("sqlite")));
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<LoginUseCase>();
            services.AddScoped<ListProductsUseCase>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            
            //services.AddAutoMapper(typeof(Startup));
            var configuration = new MapperConfiguration(cfg => 
            {
                cfg.AddProfile<LoginProfile>();
                cfg.AddProfile<ProductProfile>();
                //cfg.CreateMap<Product, ProductResponse>();
            });
            configuration.AssertConfigurationIsValid();

            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);
            
            // var config = new MapperConfiguration(cfg => {
            //     cfg.AddProfile<AppProfile>();
            //     cfg.CreateMap<Source, Dest>();
            // });

            // var mapper = config.CreateMapper();
            // // or
            // IMapper mapper = new Mapper(config);
            // var dest = mapper.Map<Source, Dest>(new Source());



            services.AddControllers();
            services.AddAuthenticationSettings(Configuration);
            //services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title="RepositoryPattern", Version="v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header, 
                    Description = @"JWT Authorization header using the Bearer scheme.
                                    Enter 'Bearer' [space] and then your token in the text input below.
                                    Example: 'Bearer 12345abcdef'", 
                }); 

                c.AddSecurityRequirement(new OpenApiSecurityRequirement 
                { 
                    {
                        new OpenApiSecurityScheme 
                        { 
                            Reference = new OpenApiReference 
                            { 
                                Type = ReferenceType.SecurityScheme, 
                                Id = "Bearer" 
                            } 
                        }, 
                        new string[] {} 
                    } 
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RepositoryPattern v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}