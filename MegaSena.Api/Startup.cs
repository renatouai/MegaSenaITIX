using Erp.Infra.Base;
using Erp.Infra.Services;
using MegaSena.Application;
using MegaSena.Domain.Interface;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(Erp.Api.Startup))]
namespace Erp.Api
{
    public partial class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
        public SimpleInjector.Container Container = null;

        public void Configuration(IAppBuilder app)
        {
            this.Container = new SimpleInjector.Container();
            InitializeContainer(Container);
            Container.Verify();

            app.Use(async (context, next) =>
            {
                using (Container.BeginExecutionContextScope())
                {
                    await next();
                }
            });

            HttpConfiguration config = new HttpConfiguration();
            config.DependencyResolver = new SimpleInjector.Integration.WebApi.SimpleInjectorWebApiDependencyResolver(this.Container);

            ConfigureOAuth(app);

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        private void ConfigureOAuth(IAppBuilder app)
        {

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        private static void InitializeContainer(SimpleInjector.Container container)
        {
            container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();
            container.Register<ErpContext>(Lifestyle.Scoped);
            container.Register(typeof(IUnitOfWork<>), typeof(UnitOfWork<>), Lifestyle.Scoped);

            container.Register<ISorteioService, SorteioService>();
            container.Register<IJogadorService, JogadorService>();
        }

    }
}