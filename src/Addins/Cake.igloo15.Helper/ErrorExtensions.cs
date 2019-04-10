using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.igloo15.Helper
{
    /// <summary>
    /// Extensions used for Errors
    /// </summary>
    public static class ErrorExtensions
    {
        private static Action<string, Exception> _exceptionEvent = null;

        /// <summary>
        /// A quick error function that will invoke errors using the event
        /// </summary>
        /// <param name="builder">The CakeTaskBuilder being extended</param>
        /// <param name="continueOnError">Continue On error allows you to continue building if you don't want to report</param>
        public static void QuickError(this CakeTaskBuilder builder, bool continueOnError = false)
        {
            if(continueOnError)
            {
                builder.ReportError((exception) => {
                    _exceptionEvent?.Invoke(builder.Task.Name, exception);
                });
            } 
            else 
            {
                builder.OnError((exception) => {
                    _exceptionEvent?.Invoke(builder.Task.Name, exception);
                    throw exception;
                });
            }
            
        }

        /// <summary>
        /// Add a listener on all errors passed by functions
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="errorAction">The error action</param>
        [CakeMethodAlias]
        public static void AddErrorListener(this ICakeContext context, Action<string, Exception> errorAction)
        {
            _exceptionEvent += errorAction;
        }

    }
}