using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.igloo15.Helper
{
    /// <summary>
    /// Some initial cake events extensions
    /// </summary>
    public static class EventExtensions
    {
        private static Action<ProjectData> _setupAction = null;
        private static Action<ProjectData> _teardownAction = null;
        private static Action<ProjectData> _taskSetupAction = null;
        private static Action<ProjectData> _taskTeardownAction = null;
        

        /// <summary>
        /// An method used to add a listener on the setup action
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cakeAction"></param>
        [CakeMethodAlias]
        public static void AddSetup(this ICakeContext context, Action<ProjectData> cakeAction)
        {
            _setupAction += cakeAction;            
        }

        /// <summary>
        /// A method used to invoke the setup action
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="data">The project data to invoke with</param>
        [CakeMethodAlias]
        public static void InvokeSetup(this ICakeContext context, ProjectData data)
        {
            _setupAction?.Invoke(data);
        }

        /// <summary>
        /// A method used to register to listen on teardown of a cake script
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="cakeAction">The listener action</param>
        [CakeMethodAlias]
        public static void AddTeardown(this ICakeContext context, Action<ProjectData> cakeAction)
        {
            _teardownAction += cakeAction;
        }

        /// <summary>
        /// Method to be invoked in teardown to trigger all listeners
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="data">The data to be invoked with</param>
        [CakeMethodAlias]
        public static void InvokeTeardown(this ICakeContext context, ProjectData data)
        {
            _teardownAction?.Invoke(data);
        }

        /// <summary>
        /// A method used to register to listen on task setup of a cake script
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="cakeAction">The listener action</param>
        [CakeMethodAlias]
        public static void AddTaskSetup(this ICakeContext context, Action<ProjectData> cakeAction)
        {
            _taskSetupAction += cakeAction;
        }

        /// <summary>
        /// Method to be invoked in task setup to trigger all listeners
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="data">The data to be invoked with</param>
        [CakeMethodAlias]
        public static void InvokeTaskSetup(this ICakeContext context, ProjectData data)
        {
            _taskSetupAction?.Invoke(data);
        }

        /// <summary>
        /// A method used to register to listen on task teardown of a cake script
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="cakeAction">The listener action</param>
        [CakeMethodAlias]
        public static void AddTaskTeardown(this ICakeContext context, Action<ProjectData> cakeAction)
        {
            _taskTeardownAction += cakeAction;
        }

        /// <summary>
        /// Method to be invoked in task teardown to trigger all listeners
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="data">The data to be invoked with</param>
        [CakeMethodAlias]
        public static void InvokeTaskTeardown(this ICakeContext context, ProjectData data)
        {
            _taskTeardownAction?.Invoke(data);
        }

    }
}