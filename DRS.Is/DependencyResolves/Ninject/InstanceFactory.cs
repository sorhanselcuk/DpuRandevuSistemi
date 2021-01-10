using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRS.Is.DependencyInjection.Ninject;

namespace DRS.Is.DependencyResolves.Ninject
{
    public class InstanceFactory
    {
        public static T GetInstance<T>(NinjectModule module)
        {
            var kernel = new StandardKernel(module);
            return kernel.Get<T>();
        }
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new IsModule());
            return kernel.Get<T>();
        }
    }
}
