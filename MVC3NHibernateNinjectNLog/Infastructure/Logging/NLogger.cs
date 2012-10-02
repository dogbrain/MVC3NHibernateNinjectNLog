using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;
using MVC3NHibernateNinjectNLog.Helpers;

namespace MVC3NHibernateNinjectNLog.Infastructure.Logging
{
    public class NLogger : ILogger
    {
        private Logger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="NLogger"/> class.
        /// </summary>
        public NLogger()
        {
            logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Logs an Info message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Info(string message)
        {
            this.logger.Info(message);
        }

        /// <summary>
        /// Logs a Warning message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Warn(string message)
        {
            this.logger.Warn(message);
        }

        /// <summary>
        /// Logs an Debug message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Debug(string message)
        {
            this.logger.Debug(message);
        }

        /// <summary>
        /// Logs an Error message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Error(string message)
        {
            this.logger.Error(message);
        }

        /// <summary>
        /// Logs an Error message with an exception message.
        /// </summary>
        /// <param name="ex">The exception.</param>
        public void Error(Exception ex)
        {
            this.Error(Utils.BuildExceptionMessage(ex));
        }

        /// <summary>
        /// Logs an Fatal message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Fatal(string message)
        {
            this.logger.Fatal(message);
        }

        /// <summary>
        /// Logs an Fatal message with the exception message.
        /// </summary>
        /// <param name="ex">The exception.</param>
        public void Fatal(Exception ex)
        {

            this.Fatal(Utils.BuildExceptionMessage(ex));
        }

    }
}