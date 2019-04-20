using System.Linq;
using System;
using System.Collections.Generic;
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
        /// <param name="continueOnError">Continue on error if you want</param>
        public static void CompleteTask(this CakeTaskBuilder builder, bool continueOnError = false)
        {
            builder
                .Does((context) => {
                    context.Information($"Task {builder.Task.Name} Completed!");
                })
                .QuickError(continueOnError);
        }

        /// <summary>
        /// Get the current task data
        /// </summary>
        /// <param name="context">The ICakeContext</param>
        /// <returns>The name of the current task</returns>
        [CakePropertyAlias]
        public static string TaskName(this ICakeContext context)
        {
            try 
            {
                var data = context.Data.Get<ProjectData>();
                return data.CurrentTask?.Name;
            } 
            catch(Exception e)
            {
                context.Error("Project Data Not Found");
                context.Error(e);
            }
            
            return null;
        }

        /// <summary>
        /// SetupProjectData
        /// </summary>
        /// <param name="context">The Context</param>
        [CakeMethodAlias]
        public static ProjectData SetupProjectData(this ICakeContext context)
        {
            var service = context.Data as ICakeDataService;
            if(service == null)
                throw new ArgumentNullException("service", "Could not parse context.Data to ICakeDataService");

            context.AddErrorListener((task, error) => {
                context.Error($"{task} : {error.Message}");
                context.Error($"{error.StackTrace}");
            });

            var data = new ProjectData(context, context.GlobalArguments());
            service.Add(data);

            if(context is ISetupContext setupContext)
            {
                setupContext.TasksToExecute.Select(c => c as CakeTask).Execute(t => {
                    t.AddDelayedAction(delayContext => {
                        data.CurrentTask = t;
                    });
                });
                setupContext.InvokeSetup(data);
            }
            
            

            return data;
        } 

        private static IEnumerable<T> Execute<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach(var item in items)
            {
                action(item);
            }

            return items;
        }
    }
}