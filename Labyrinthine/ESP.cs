using UnityEngine;
using Labyrinthine.Utilities;
using System;

namespace Labyrinthine
{
    public static class ESP
    {
        public static Camera GameCamera = Camera.main;

        public static void Render()
        {
            RenderMonsters();
        }

        private static void RenderMonsters()
        {
            foreach (var ai in Main.AIControllers)
            {
                Vector3 position = ai.transform.position;
                Vector3 vector = GameCamera.WorldToScreenPoint(position);

                if ((vector.x < 0f || vector.x > (float)Screen.width || vector.y < 0f || vector.y > (float)Screen.height || vector.z > 0f))
                {
                    float distanceToMonster = (float)Math.Round((double)Vector3.Distance(Main.PlayerControl.transform.position, ai.transform.position), 1);

                    if (vector.z >= 0f && distanceToMonster < 125f)
                    {
                        Drawing.DrawString(new Vector2(vector.x, (float)Screen.height - vector.y), ai.monsterType.ToString() + " [" + distanceToMonster.ToString() + "m]", Color.cyan, 12, true);
                    }
                }
            }
        }
    }
}
