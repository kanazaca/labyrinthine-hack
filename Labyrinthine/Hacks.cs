using System;

namespace Labyrinthine
{
    public static class Hacks
    {
        public static void Listen()
        {
            SpeedHack();
        }

        private static void SpeedHack()
        {
            if(CheatToggles.SpeedHackEnabled)
            {
                Main.PlayerControl.CurrentPlayerControlPreset.MovementSpeed = 15f;
            }
            else
            {
                Main.PlayerControl.CurrentPlayerControlPreset.MovementSpeed = 4f;
            }
        }
    }
}
