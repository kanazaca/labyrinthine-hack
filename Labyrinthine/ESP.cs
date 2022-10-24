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
            RenderPlayers();
            RenderKeyPuzzle();
        }

        private static void RenderKeyPuzzle()
        {
            foreach (var key in Main.KeyPuzzle.keys)
            {
                if(key == null)
                {
                    continue;
                }

                Drawing.TextWithDistance(key.transform, key.name);
            }

            foreach (var keyLock in Main.KeyPuzzle.locks)
            {
                if(keyLock == null)
                {
                    continue;
                }

                Drawing.TextWithDistance(keyLock.transform, keyLock.name);
            }
        }

        private static void RenderPlayers()
        {
            foreach (var player in Main.GameManager.Players)
            {
                Drawing.TextWithDistance(player.transform, player.playerName);
            }
        }

        private static void RenderMonsters()
        {
            foreach (var ai in Main.AIControllers)
            {
                Drawing.TextWithDistance(ai.transform, ai.monsterType.ToString());
            }
        }
    }
}
