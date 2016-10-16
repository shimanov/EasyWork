using System;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using WebApplication.Service.Services;
using WebApplication.Service.Services.Base;
using WebApplication2.DAL.Context;
using WebApplication2.DAL.Repositories;
using WebApplication2.DAL.Repositories.Base;

namespace WebApplication2.IoC
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _kernel;

        public NinjectControllerFactory()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            //return controllerType == null
            //    ? null
            //    : (IController)_kernel.Get(controllerType);

            if (controllerType == null)
                return null;
            return (IController)_kernel.Get(controllerType);
        }

        private void AddBindings()
        {
            _kernel.Bind(typeof(DbContext)).To(typeof(EasyWorkDBContext));

            _kernel.Bind<IEasyWorkRepository>().To<EasyWorkRepository>();
            _kernel.Bind<IEasyWorkServices>().To<IEasyWorkServices>();
            _kernel.Bind<IPhoneBookService>().To<PhoneBookService>();

            _kernel.Bind<IProblemDecisionRepository>().To<ProblemDecisionRepository>();
            _kernel.Bind<IProblemDecisionServices>().To<ProblemDecisionServices>();
        }

        
    }
}
