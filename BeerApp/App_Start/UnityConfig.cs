using Microsoft.Practices.Unity;
using System.Web.Http;
using System.Web.Mvc;
using Beer.Data;
using Beer.Model;
using Unity.WebApi;

namespace BeerApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IGenericRepository<Ingredient>, IngredientRepository>();
            container.RegisterType<IGenericRepository<Recipe>, RecipeRepository>();

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new Microsoft.Practices.Unity.Mvc.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}