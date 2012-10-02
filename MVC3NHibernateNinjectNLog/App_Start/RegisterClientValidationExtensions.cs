using DataAnnotationsExtensions.ClientValidation;

[assembly: WebActivator.PreApplicationStartMethod(typeof(MVC3NHibernateNinjectNLog.App_Start.RegisterClientValidationExtensions), "Start")]
 
namespace MVC3NHibernateNinjectNLog.App_Start {
    public static class RegisterClientValidationExtensions {
        public static void Start() {
            DataAnnotationsModelValidatorProviderExtensions.RegisterValidationExtensions();            
        }
    }
}