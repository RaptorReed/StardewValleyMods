using HarmonyLib;
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
            /*CollectionsPage colPage = __instance;

            b.Begin((SpriteSortMode)4, BlendState.AlphaBlend, SamplerState.PointClamp, (DepthStencilState)null, (RasterizerState)null, (Effect)null, (Matrix?)null);
            foreach (ClickableTextureComponent item in colPage.collections[colPage.currentTab][colPage.currentPage])
            {
                bool flag = Convert.ToBoolean(item.name.Split(' ')[1]);
                bool flag2 = colPage.currentTab == 4 && Convert.ToBoolean(item.name.Split(' ')[2]);
                item.draw(b, flag2 ? (Color.DimGray * 0.4f) : (flag ? Color.White : (Color.Black * 0.2f)), 0.86f);
                if (colPage.currentTab == 5 && flag)
                {
                    int num = new Random(Convert.ToInt32(item.name.Split(' ')[0])).Next(12);
                    b.Draw(Game1.mouseCursors, new Vector2((float)(item.bounds.X + 16 + 16), (float)(item.bounds.Y + 20 + 16)), (Rectangle?)new Rectangle(256 + num % 6 * 64 / 2, 128 + num / 6 * 64 / 2, 32, 32), Color.get_White(), 0f, new Vector2(16f, 16f), item.scale, (SpriteEffects)0, 0.88f);
                }
            }
            b.End();*/
        }
    }
}