using HarmonyLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Menus;
using System;
using System.Xml.Linq;

namespace MuseumTracker
{
    /// <summary>Applies Harmony patches to <see cref="CollectionsPage"/>.</summary>
    internal class CollectionsPagePatcher : BasePatcher
    {
        /*********
        ** Public methods
        *********/
        /// <inheritdoc />
        public override void Apply(Harmony harmony, IMonitor monitor)
        {
            harmony.Patch(
                original: this.RequireMethod<CollectionsPage>("draw", new Type[] { typeof(SpriteBatch) }),
                postfix: this.GetHarmonyMethod(nameof(Postfix_Draw))
            );
        }

        public static void Postfix_Draw(CollectionsPage __instance, SpriteBatch b)
        {
            CollectionsPage collPage = __instance;
            b.End();
            b.Begin((SpriteSortMode)4, BlendState.AlphaBlend, SamplerState.PointClamp, (DepthStencilState)null, (RasterizerState)null, (Effect)null, (Matrix?)null);
            if(collPage.currentTab == 2)
            {
                foreach (ClickableTextureComponent item in collPage.collections[2][collPage.currentPage])
                {
                    bool flag = Convert.ToBoolean(item.name.Split(' ')[1]);
                    bool flag2 = collPage.currentTab == 4 && Convert.ToBoolean(item.name.Split(' ')[2]);
                    item.draw(b, flag2 ? (Color.DimGray * 0.4f) : (flag ? Color.White : (Color.HotPink * 0.2f)), 0.86f);
                }
            }
        }
    }
}