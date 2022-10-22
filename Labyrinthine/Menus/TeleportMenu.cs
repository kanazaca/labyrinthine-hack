using UnityEngine;

namespace Labyrinthine.Menus
{
    public class TeleportMenu : MonoBehaviour
    {
        public static bool Enabled { get; set; } = false;
        public static Rect MenuRect = new Rect(InGameMainMenu.MenuRect.x + 325f, InGameMainMenu.MenuRect.y / 2f, 460f, 500f);
        private static GUIStyle GUIStyle = new GUIStyle();

        public static void Render(int windowID)
        {
            SetDefaultWindowColors();

            // COL-1
            GUI.Label(new Rect(30f, 15f, 100f, 50f), "Players", GUIStyle);

            if (GUI.Button(new Rect(32f, 65f, 127f, 23f), new GUIContent(Main.PlayerControl.playerNetworkSync.playerName)))
            {
                // TODO, because need to test with more players in game
            }

            // COL-2
            GUI.Label(new Rect(172f, 15f, 100f, 50f), "Locations", GUIStyle);

            if (GUI.Button(new Rect(174f, 65f, 127f, 23f), new GUIContent("Go to Spawn")))
            {
                Main.PlayerControl.playerNetworkSync.MoveToSpawnpoint();
            }

            // COL-3
            RenderMonstersColumn();

            GUI.color = Color.white;
            GUI.DragWindow(new Rect(0f, 0f, 10000f, 20f));
        }

        private static void RenderMonstersColumn()
        {
            GUI.Label(new Rect(314f, 15f, 100f, 50f), "Monsters", GUIStyle);

            var monsterColY = 65f;
            foreach (var ai in Main.AIControllers)
            {
                var normalizedMonsterName = ai.MonsterType.ToString().Replace("_", " ");

                if (GUI.Button(new Rect(316f, monsterColY, 127f, 23f), new GUIContent(normalizedMonsterName)))
                {
                    var transform = ai.transform;
                    transform.position = new Vector3(
                        transform.position.x,
                        transform.position.y,
                        transform.position.z - 4f // to fix some stuck/fall into the ground
                    );

                    Main.PlayerControl.playerNetworkSync.MoveToTransform(ai.transform);
                }

                monsterColY += 27f;
            }
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
