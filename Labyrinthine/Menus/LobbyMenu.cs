using UnityEngine;

namespace Labyrinthine.Menus
{
    public class LobbyMenu
    {
        public static bool Enabled { get; set; } = false;
        public static Rect MenuRect = new Rect(60f, 250f, 300f, 230f);
        private static GUIStyle GUIStyle = new GUIStyle();

        public static void Render(int windowID)
        {
            SetDefaultWindowColors();

            if (GUI.Button(new Rect(20f, 35f, 127f, 23f), new GUIContent("Unlimited Currency"), "Add Unlimited Currency"))
            {
                Hacks.UlimitedCurrency();
            }

            GUI.color = Color.white;
            GUI.DragWindow(new Rect(0f, 0f, 10000f, 20f));
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
