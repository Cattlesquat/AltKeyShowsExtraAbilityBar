using HarmonyLib;

namespace Cattlesquat_AltKeyShowsExtraAbilityBar.HarmonyPatches
{
    [HarmonyPatch(typeof(Qud.UI.AbilityBar))]
    class Cattlesquat_AltKeyShowsExtraAbilityBar
    {
        static bool prevAlt = false;
        static bool alt = false;

        [HarmonyPrefix]
        [HarmonyPatch("Update")]
        static void Prefix()
        {
            if (!Qud.UI.AbilityBar.instance.canvas.enabled) return;

            prevAlt = alt;
            alt = ConsoleLib.Console.Keyboard._bAlt;
            if (alt != prevAlt)
            {
                if (alt)
                {
                    Qud.UI.AbilityBar.instance.MovePage(1);
                }
                else
                {
                    Qud.UI.AbilityBar.instance.MovePage(-1);
                }
            }
        }
    }
}
