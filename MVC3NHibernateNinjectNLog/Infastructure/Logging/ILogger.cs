using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC3NHibernateNinjectNLog.Infastructure.Logging
{
    public interface ILogger
    {
        /// <summary>
        /// Logs an Info message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Info(string message);
        /// <summary>
        /// Logs a Warning message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Warn(string message);
        /// <summary>
        /// Logs an Debug message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Debug(string message);
        /// <summary>
        /// Logs an Error message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Error(string message);
        /// <summary>
        /// Logs an Error message with an exception message.
        /// </summary>
        /// <param name="ex">The exception.</param>
        void Error(Exception ex);
        /// <summary>
        /// Logs an Fatal message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Fatal(string message);
        /// <summary>
        /// Logs an Fatal message with the exception message.
        /// </summary>
        /// <param name="ex">The exception.</param>
        void Fatal(Exception ex);
    }
}