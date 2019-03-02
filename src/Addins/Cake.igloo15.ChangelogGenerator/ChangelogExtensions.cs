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

            core.GenerateChangelog(new string[]{});
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