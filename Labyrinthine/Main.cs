using MelonLoader;
using System.Collections;
using System.Threading;
using UnityEngine;

namespace Labyrinthine
{
    public class Main : MelonMod
    {
        public static int? CurrentSceneIndex;

        public static bool CanRunCoRoutine = true;
        public static bool CoRoutineIsRunning = true;
        private static object coRoutine;

        public static PlayerControl PlayerControl { get; set; }

        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg($"Loaded Labyrinthine Mod!");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            LoggerInstance.Msg($"Scene {sceneName} with build index {buildIndex} has been loaded!");

            CurrentSceneIndex = buildIndex;

            if (buildIndex == 4)
            {
                CanRunCoRoutine = false;
                new Thread(() =>
                {
                    while (CoRoutineIsRunning)
                    {
                        coRoutine = MelonCoroutines.Start(CollectGameObjects());
                        Thread.Sleep(5000);
                    }
                }).Start();
            }
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                CheatToggles.GuiEnabled = !CheatToggles.GuiEnabled;

                LoggerInstance.Msg($"Main Menu is now {(CheatToggles.GuiEnabled ? "On" : "Off")}");
            }

            Hacks.Listen();
        }

        public override void OnGUI()
        {
            if (CurrentSceneIndex == null || CurrentSceneIndex < 4)
                return;

            if (CheatToggles.GuiEnabled)
            {
                var buttonWidth = 180f;
                var col1Height = 300f;
                var col1X = 10f;

                // ******************************* COL 1 *****************************

                if (GUI.Button(new Rect(col1X, col1Height, buttonWidth, 30f), $"Turn {(CheatToggles.SpeedHackEnabled ? "Off" : "On")} Speed Hack"))
                {
                    CheatToggles.SpeedHackEnabled = !CheatToggles.SpeedHackEnabled;

                    LoggerInstance.Msg($"Speed Hack is now {(CheatToggles.SpeedHackEnabled ? "On" : "Off")}");
                }
            }
        }

        IEnumerator CollectGameObjects()
        {
            PlayerControl = GameObject.FindObjectOfType<PlayerControl>();
            yield return new WaitForSeconds(0.15f);
        }
    }
}
