using Dynamite3D.RealIvy;
using MelonLoader;
using System.Linq;
using UnityEngine;
using static ValkoGames.Labyrinthine.Cases.Objects.IntersectionActivator;

namespace Labyrinthine.Menus
{
    public class InGameMainMenu
    {
        public static bool Enabled { get; set; } = false;
        public static Rect MenuRect = new Rect(500f, 250f, 300f, 230f);
        private static GUIStyle GUIStyle = new GUIStyle();

        public static void Render(int windowID)
        {
            SetDefaultWindowColors();

            RenderColumn1();
            RenderColumn2();

            if (GUI.Button(new Rect(20f, 155f, 257f, 30f), new GUIContent("Open Teleport Menu")))
            {
                TeleportMenu.Enabled = !TeleportMenu.Enabled;
            }

            GUI.color = Color.white;
            GUI.DragWindow(new Rect(0f, 0f, 10000f, 20f));
        }

        private static void RenderColumn1()
        {
            if (GUI.Button(new Rect(20f, 35f, 130f, 25f), new GUIContent($"{(CheatToggles.ESPEnabled ? "Disable" : "Enable")} ESP")))
            {
                CheatToggles.ESPEnabled = !CheatToggles.ESPEnabled;
            }

            if (GUI.Button(new Rect(20f, 65f, 130f, 25f), new GUIContent($"{(CheatToggles.SunEnabled ? "Disable" : "Enable")} Sun Light")))
            {
                CheatToggles.SunEnabled = !CheatToggles.SunEnabled;
                SunLight.SetActive(CheatToggles.SunEnabled);
            }

            if (GUI.Button(new Rect(20f, 95f, 130f, 25f), new GUIContent($"{(CheatToggles.DumbAIEnabled ? "Disable" : "Enable")} Dumb AI")))
            {
                CheatToggles.DumbAIEnabled = !CheatToggles.DumbAIEnabled;
                DumbAI.Toggle(CheatToggles.DumbAIEnabled);
            }
        }

        private static void RenderColumn2()
        {
            GUI.Label(new Rect(160f, 35f, 130f, 20f), new GUIContent("Flashlight Multiplier"));
            Hacks.FlashlightMultiplier = GUI.HorizontalSlider(new Rect(157f, 57f, 128f, 20f), Hacks.FlashlightMultiplier, 1f, 500f);

            GUI.Label(new Rect(160f, 74f, 130f, 20f), new GUIContent("Speed Hack"));
            Main.PlayerControl.CurrentPlayerControlPreset.MovementSpeed = GUI.HorizontalSlider(new Rect(157f, 96f, 128f, 20f), Main.PlayerControl.CurrentPlayerControlPreset.MovementSpeed, 4f, 50f);

            
        }

        private static void SetDefaultWindowColors()
        {
            GUI.backgroundColor = Color.white;
            GUIStyle.fontSize = 16;
            GUIStyle.normal.textColor = new Color(0.207f, 0.733f, 0.243f, 1f);
            GUIStyle.alignment = TextAnchor.MiddleCenter;
        }
    }    
}
