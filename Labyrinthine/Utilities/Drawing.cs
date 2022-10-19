using UnityEngine;

namespace Labyrinthine.Utilities
{
    internal class Drawing
    {
        public static GUIStyle StringStyle { get; set; } = new GUIStyle(GUI.skin.label);

        public static void DrawString(Vector2 position, string label, Color color, int fontSize, bool centered = true)
        {
            GUI.color = color;
            Drawing.StringStyle.fontSize = fontSize;
            Drawing.StringStyle.normal.textColor = color;
            GUIContent content = new GUIContent(label);
            Vector2 vector = Drawing.StringStyle.CalcSize(content);
            GUI.Label(new Rect(centered ? (position - vector / 2f) : position, vector), content, Drawing.StringStyle);
        }
    }
}
