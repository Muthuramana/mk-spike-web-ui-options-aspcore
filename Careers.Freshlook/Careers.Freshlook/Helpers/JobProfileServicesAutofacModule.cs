using Autofac;

namespace Careers.Freshlook
{
    internal class JobProfileServicesAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterAssemblyTypes(ThisAssembly).AsImplementedInterfaces()
              .InstancePerLifetimeScope();
        }
    }
}