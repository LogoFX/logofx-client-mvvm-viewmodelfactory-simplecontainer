using LogoFX.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using LogoFX.Client.Mvvm.ViewModel.Contracts;
using Solid.Practices.Middleware;

namespace LogoFX.Client.Mvvm.ViewModelFactory.SimpleContainer
{
    /// <summary>
    /// Middleware that registers view model factory implemented using LogoFX Simple Container.
    /// </summary>
    public class RegisterViewModelFactoryMiddleware : 
        IMiddleware<IBootstrapperWithContainerAdapter<ExtendedSimpleContainerAdapter>>        
    {
        /// <summary>
        /// Applies the middleware on the specified object.
        /// </summary>
        /// <param name="object">The object.</param>
        /// <returns></returns>
        public IBootstrapperWithContainerAdapter<ExtendedSimpleContainerAdapter> 
            Apply(IBootstrapperWithContainerAdapter<ExtendedSimpleContainerAdapter> @object)
        {
            @object.Registrator.RegisterSingleton<IViewModelFactory, ViewModelFactory>();
            return @object;
        }
    }

    /// <summary>
    /// Bootstrapper extensions.
    /// </summary>
    public static class BootstrapperExtensions
    {
        /// <summary>
        /// Uses the view model factory which is based on LogoFX Simple Container.
        /// </summary>        
        /// <param name="bootstrapper">The bootstrapper.</param>
        public static IBootstrapperWithContainerAdapter<ExtendedSimpleContainerAdapter> 
            UseViewModelFactory(
            this IBootstrapperWithContainerAdapter<ExtendedSimpleContainerAdapter> bootstrapper)
        {
            return bootstrapper.Use(new RegisterViewModelFactoryMiddleware());            
        }
    }
}
