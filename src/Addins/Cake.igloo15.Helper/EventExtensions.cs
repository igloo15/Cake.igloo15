using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.igloo15.Helper
{
    public static class EventExtensions
    {
        private static Action<ProjectData> _setupAction = null;
        private static bool _isSetup = false;

        private static Action<ProjectData> _teardownAction = null;
        private static bool _isTeardown = false;

        private static Action<ProjectData> _taskSetupAction = null;
        private static bool _isTaskSetup = false;

        private static Action<ProjectData> _taskTeardownAction = null;
        private static bool _isTaskTeardown = false;


        [CakeMethodAlias]
        public static void AddSetup(this ICakeContext context, Action<ProjectData> cakeAction)
        {
            _setupAction += cakeAction;            
        }

        [CakeMethodAlias]
        public static void InvokeSetup(this ICakeContext context, ProjectData data)
        {
            _setupAction?.Invoke(data);
        }

        [CakeMethodAlias]
        public static void AddTeardown(this ICakeContext context, Action<ProjectData> cakeAction)
        {
            _teardownAction += cakeAction;
        }

        [CakeMethodAlias]
        public static void InvokeTeardown(this ICakeContext context, ProjectData data)
        {
            _teardownAction?.Invoke(data);
        }

        [CakeMethodAlias]
        public static void AddTaskSetup(this ICakeContext context, Action<ProjectData> cakeAction)
        {
            _taskSetupAction += cakeAction;
        }

        [CakeMethodAlias]
        public static void InvokeTaskSetup(this ICakeContext context, ProjectData data)
        {
            _taskSetupAction?.Invoke(data);
        }

        [CakeMethodAlias]
        public static void AddTaskTeardown(this ICakeContext context, Action<ProjectData> cakeAction)
        {
            _taskTeardownAction += cakeAction;
        }

        [CakeMethodAlias]
        public static void InvokeTaskTeardown(this ICakeContext context, ProjectData data)
        {
            _taskTeardownAction?.Invoke(data);
        }

    }
}