using Labyrinthine.Menus;
using MelonLoader;
using System.Collections;
using System.Threading;
using UnityEngine;
using ValkoGames.Labyrinthine.Monsters;
using System.Linq;

namespace Labyrinthine
{
    public class Main : MelonMod
    {
        public static int? CurrentSceneIndex;

        public static bool CanRunCoRoutine = true;
        public static bool CoRoutineIsRunning = true;
        private static object coRoutine;

        // Game Objects
        public static PlayerControl PlayerControl { get; set; }
        public static AIController[] AIControllers { get; set; }

        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg($"Loaded Labyrinthine Mod!");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            LoggerInstance.Msg($"Scene {sceneName} with build index {buildIndex} has been loaded!");

            CurrentSceneIndex = buildIndex;

            if (buildIndex >= 4)
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

            // Reset Menus
            LobbyMenu.Enabled = false;
            InGameMainMenu.Enabled = false;
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                if (CurrentSceneIndex == 2)
                {
                    LobbyMenu.Enabled = !LobbyMenu.Enabled;

                    LoggerInstance.Msg("Toggled Lobby Menu");
                }
                else if (CurrentSceneIndex >= 4)
                {
                    InGameMainMenu.Enabled = !InGameMainMenu.Enabled;
                }
            }
        }

        public override void OnGUI()
        {
            if (CurrentSceneIndex == null || CurrentSceneIndex < 2)
                return;

            GUI.backgroundColor = Color.black;

            if (LobbyMenu.Enabled)
            {
                LobbyMenu.MenuRect = GUI.Window(0, LobbyMenu.MenuRect, (GUI.WindowFunction)LobbyMenu.Render, "~ Labyrinthine Hack ~");
            }

            if (InGameMainMenu.Enabled)
            {
                InGameMainMenu.MenuRect = GUI.Window(1, InGameMainMenu.MenuRect, (GUI.WindowFunction)InGameMainMenu.Render, "~ Labyrinthine Hack ~");
            }

            if(CheatToggles.ESPEnabled)
            {
                ESP.Render();

                LoggerInstance.Msg($"We have {AIControllers.Count()} monsters");
            }
        }

        public override void OnSceneWasUnloaded(int buildIndex, string sceneName)
        {
            InGameMainMenu.Enabled = false;
            LobbyMenu.Enabled = false;
            CheatToggles.ESPEnabled = false;
            CheatToggles.SpeedHackEnabled = false;
        }

        IEnumerator CollectGameObjects()
        {
            PlayerControl = GameObject.FindObjectOfType<PlayerControl>();
            yield return new WaitForSeconds(0.15f);

            AIControllers = GameObject.FindObjectsOfType<AIController>().ToArray();
            yield return new WaitForSeconds(0.15f);
        }
    }
}
