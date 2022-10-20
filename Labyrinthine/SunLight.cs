using UnityEngine;
using MelonLoader;

namespace Labyrinthine
{
    public static class SunLight
    {
        private static bool _isSunAlreadyInScene;
        private static GameObject _theSun;
  
        public static void SetActive(bool status)
        {
            if (!_isSunAlreadyInScene)
            {
                RenderSun();
            }
            else
            {
                _theSun.SetActive(status);
            }
            
            Melon<Main>.Logger.Msg($"Sun is {status.ToString()}");
        }

        private static void RenderSun()
        {
            var player = Main.PlayerControl;

            var playerPos = player.transform.position;
            _theSun = new GameObject("The Sun")
            {
                transform =
                {
                    rotation = Quaternion.Euler(90f, 0f, 0f),
                    position = new Vector3(playerPos.x, 25f, playerPos.z)
                }
            };

            var lightComp = _theSun.AddComponent<Light>();
            lightComp.color = new Color(1f, 0.75f, 0.5f, 1f);
            lightComp.type = LightType.Directional;
            lightComp.range = 10f;
            lightComp.intensity = 1.1f;
            lightComp.spotAngle = 80f;

            _isSunAlreadyInScene = true;
        }
    }
}