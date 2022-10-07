using ContentPatcher;
using Pathoschild.Stardew.Common.Integrations.GenericModConfigMenu;
using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace GenderOptions
{

    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {
        private ModConfig Config;

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            this.Config = this.Helper.ReadConfig<ModConfig>();

            helper.Events.GameLoop.GameLaunched += this.OnGameLaunched;
        }


        /*********
        ** Private methods
        *********/
        /// <summary>Called when game launched.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void OnGameLaunched(object sender, GameLaunchedEventArgs e)   
        {
            // Register config values as tokens

            // get Content Patcher API if installed
            var cpApi = this.Helper.ModRegistry.GetApi<IContentPatcherAPI>("Pathoschild.ContentPatcher");
            if (cpApi is null) { 
                return; 
            }

            cpApi.RegisterToken(this.ModManifest, "MyTestString", () =>
            {
                if (this.Config.ExampleString != null)
                    return new[] { this.Config.ExampleString };
                return null;
            });


            // get Generic Mod Config Menu's API (if it's installed)
            var configMenu = this.Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");
            if (configMenu is null)
                return;


                // register mod
                configMenu.Register(
                    mod: this.ModManifest,
                    reset: () => this.Config = new ModConfig(),
                    save: () => this.Helper.WriteConfig(this.Config)
                );

        // title
        configMenu.AddSectionTitle(
            mod: this.ModManifest,
                    text: () => "Stardew Valley Vanila",
                    tooltip: () => "Custom portraits for Stardew Valley Vanilla"
                    );

                // add some config options
                configMenu.AddTextOption(
                    mod: this.ModManifest,
                    name: () => "Abigail Portrait",
                    tooltip: () => "Use custom abigail portrait.",
                    getValue: () => this.Config.ExampleString,
                    setValue: value => this.Config.ExampleString = value
                );
        }
    }
}