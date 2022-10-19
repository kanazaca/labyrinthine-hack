using System;
using UnityEngine;
using ValkoGames.Labyrinthine.Store;

namespace Labyrinthine
{
    public static class Hacks
    {
        public static void Listen()
        {
            SpeedHack();
        }

        public static void SpeedHack()
        {
            if(CheatToggles.SpeedHackEnabled) {
                Main.PlayerControl.CurrentPlayerControlPreset.MovementSpeed = 15f;
            }
            else {
                Main.PlayerControl.CurrentPlayerControlPreset.MovementSpeed = 4f;
            }
        }

        public static void UlimitedCurrency()
        {
            CurrencyManager.AddCurrency(99999, false);
        }
    }
}
