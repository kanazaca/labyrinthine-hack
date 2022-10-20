using UnityEngine;
using static ValkoGames.Labyrinthine.Cases.Objects.IntersectionActivator;

namespace Labyrinthine.Menus
{
    public static class InGameMainMenu
    {
        public static bool Enabled { get; set; } = false;
        public static Rect MenuRect = new Rect(60f, 250f, 300f, 230f);
        private static GUIStyle GUIStyle = new GUIStyle();

        public static void Render(int windowID)
        {
            SetDefaultWindowColors();

            if (GUI.Button(new Rect(20f, 35f, 127f, 23f), new GUIContent($"{(CheatToggles.SpeedHackEnabled ? "Disable" : "Enable")} Speed Hack"), GUIStyle))
            {
                CheatToggles.SpeedHackEnabled = !CheatToggles.SpeedHackEnabled;
                Hacks.SpeedHack();
            }
            if (GUI.Button(new Rect(20f, 61f, 127f, 23f), new GUIContent($"{(CheatToggles.ESPEnabled ? "Disable" : "Enable")} ESP"), GUIStyle))
            {
                CheatToggles.ESPEnabled = !CheatToggles.ESPEnabled;
            }
            
            if (GUI.Button(new Rect(20f, 90f, 127f, 23f), new GUIContent($"{(CheatToggles.SunEnabled ? "Disable" : "Enable")} Sun Light"), GUIStyle))
            {
                CheatToggles.SunEnabled = !CheatToggles.SunEnabled;
                SunLight.SetActive(CheatToggles.SunEnabled);
            }

            GUI.color = Color.white;
            GUI.Label(new Rect(10f, 205f, 1000f, 23f), "Tooltip: " + GUI.tooltip);
            GUI.DragWindow(new Rect(0f, 0f, 10000f, 20f));
        }

        private static void SetDefaultWindowColors()
        {
            GUIStyle.fontSize = 16;
            GUIStyle.normal.textColor = new Color(0.207f, 0.733f, 0.243f, 1f);
            GUIStyle.alignment = TextAnchor.MiddleCenter;
            GUI.backgroundColor = Color.white;
        }
    }    
}
