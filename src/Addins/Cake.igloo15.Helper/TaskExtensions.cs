using System;
using Cake.Common.Diagnostics;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.igloo15.Helper
{
    /// <summary>
    /// Extensions used to provide addition functionality to Tasks
    /// </summary>
    public static class TaskExtensions
    {
        /// <summary>
        /// A quick error function that will invoke errors using the event
        /// </summary>
        /// <param name="builder">The CakeTaskBuilder being extended</param>
        public static void CompleteTask(this CakeTaskBuilder builder)
        {
            builder
                .Does((context) => {
                    context.Information($"Task {builder.Task.Name} Completed!");
                })
                .QuickError();
        }
    }
}