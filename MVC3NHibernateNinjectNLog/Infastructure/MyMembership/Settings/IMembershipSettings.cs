using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC3NHibernateNinjectNLog.Infastructure.MyMembership.Settings
{
    public interface IMembershipSettings
    {
        IRegistrationSettings Registration { get; }
        IPasswordSettings Password { get; }
        ILoginSettings Login { get; }
    }
}
