using Cake.Core;
using Cake.Core.Annotations;
using ChangelogGenerator.Core;
using ChangelogGenerator.Core.Settings;

namespace Cake.igloo15.ChangelogGenerator
{
    /// <summary>
    /// Extensions for cake to generate a changelog
    /// </summary>
    public static class ChangelogExtensions
    {
        /// <summary>
        /// Generate a changelog with the given settings
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="settings">The settings to generate with</param>
        [CakeMethodAlias]
        public static void GenerateChangelog(this ICakeContext context, ChangelogSettings settings)
        {
            ChangelogCore core = new ChangelogCore();

            core.GenerateChangelog(settings);
        }

        /// <summary>
        /// Generate a changelog using the local changelog.json configuration file
        /// </summary>
        /// <param name="context">The Cake Context</param>
        [CakeMethodAlias]
        public static void GenerateChangelog(this ICakeContext context)
        {
            ChangelogCore core = new ChangelogCore();

            core.GenerateChangelog();
        }

        /// <summary>
        /// Generate a changelog using the local changelog.json configuration file but overrided with the given next version
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="nextVersion">The next version for the unreleased changelog items</param>
        [CakeMethodAlias]
        public static void GenerateChangelog(this ICakeContext context, string nextVersion)
        {
            ChangelogCore core = new ChangelogCore();

            core.GenerateChangelog(new string[]{"-n", nextVersion});
        }

        /// <summary>
        /// Generate a test changelog using the local changelog.json configuration file but optionally override with next version
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="nextVersion">The next version for the unreleased changelog items optional</param>
        [CakeMethodAlias]
        public static void GenerateTestChangelog(this ICakeContext context, string nextVersion = null)
        {
            ChangelogCore core = new ChangelogCore();

            if(nextVersion == null) 
            {
                core.GenerateChangelog(new string[]{"-t"});
            } 
            else
            {
                core.GenerateChangelog(new string[]{"-t", "-n", nextVersion});
            }
            
        }

        /// <summary>
        /// Create a changelog config in the current working directory
        /// </summary>
        /// <param name="context">The Cake Context</param>
        [CakeMethodAlias]
        public static void CreateChangelogConfig(this ICakeContext context)
        {
            ChangelogCore core = new ChangelogCore();

            core.GenerateChangelog(new string[]{"-m"});
        }
    }
}