using System;
using System.IO;
using System.Text;
using Microsoft.Owin;
using Owin;
using Stormpath.AspNet;
using Stormpath.Configuration.Abstractions;
using Stormpath.SDK.Logging;
using LogLevel = Stormpath.SDK.Logging.LogLevel;


[assembly: OwinStartup(typeof(WebApplication2.App_Start.Startup))]

namespace WebApplication2.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Old autorisation
            /*app.CreatePerOwinContext<ApplicationContext>(ApplicationContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            }); */

            var logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StormpathMiddleware.log");

            app.UseStormpath(new StormpathMiddlewareOptions()
            {
                Logger = new FileLogger(logPath, LogLevel.Trace)
            });


            app.UseStormpath(new StormpathConfiguration
            {
                Application = new ApplicationConfiguration
                {
                    Href = "https://api.stormpath.com/v1/applications/33IpQkQjpdg0GTBIvcY4Ad"
                },
                Client = new ClientConfiguration
                {
                    ApiKey = new ClientApiKeyConfiguration
                    {
                        Id = "615TTXTV293LX7BHN4G62OIDU",
                        Secret = "TYlgJimbvK1z7LMti1jRpAYg8Kbo1Vd0trkfs5cNK/Q"

                    }
                }
            });

            app.UseStormpath(new StormpathConfiguration
            {
                Web = new WebConfiguration()
                {
                    ForgotPassword = new WebForgotPasswordRouteConfiguration()
                    {
                        Enabled = false
                    },
                    ChangePassword = new WebChangePasswordRouteConfiguration()
                    {
                        Enabled = false
                    },
                    VerifyEmail = new WebVerifyEmailRouteConfiguration()
                    {
                        Enabled = false
                    }
                }
            });
        }
    }

    public class FileLogger : ILogger
    {
        private readonly string _path;
        private readonly LogLevel _severity;

        public FileLogger(string path, LogLevel severity)
        {
            _path = path;
            _severity = severity;
        }

        public void Log(LogEntry entry)
        {
            if (entry.Severity < _severity)
            {
                return;
            }

            var logBuilder = new StringBuilder()
                .Append($"[{entry.Severity}] {entry.Source}: ");

            if (entry.Exception != null)
            {
                logBuilder.Append($"Exception {entry.Exception.GetType().Name} \"{entry.Exception.Message}\" in {entry.Exception.Source} ");
            }

            bool isMessageUseful = !string.IsNullOrEmpty(entry.Message)
                                   && !entry.Message.Equals(entry.Exception?.Message, StringComparison.Ordinal);
            if (isMessageUseful)
            {
                logBuilder.Append($"\"{entry.Message}\"");
            }

            logBuilder.Append("\n");

            File.AppendAllText(_path, logBuilder.ToString());
        }
    }
}
