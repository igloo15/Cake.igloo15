using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.igloo15.Helper
{
    public static class ErrorExtensions
    {
        private static Action<string, Exception> _exceptionEvent = null;

        public static void QuickError(this CakeTaskBuilder builder)
        {
            builder.ReportError((exception) => {
                _exceptionEvent?.Invoke(builder.Task.Name, exception);
            });
        }

        [CakeMethodAlias]
        public static void AddErrorListener(this ICakeContext context, Action<string, Exception> errorAction)
        {
            _exceptionEvent += errorAction;
        }

    }
}