using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.Unity.Math;
using MelonLoader;
using UnityEngine;
using ValkoGames.Labyrinthine.AI;

namespace Labyrinthine;

public static class DumbAI
{
    private static bool _isEnable;

    public static void Toggle(bool status)
    {
        _isEnable = status;

        var listAI = Main.AIControllers;
        foreach (var ai in listAI)
        {
            // Disable Kill
            var aiCollider = ai.GetComponent<CapsuleCollider>();
            aiCollider.isTrigger = !_isEnable;
            aiCollider.enabled = !_isEnable;

            // Disable BehaviorTree.Task
            var bhTree = ai.GetComponent<BehaviorTree>();
            var listTskConditional = bhTree.FindTasks<Conditional>();

            foreach (var task in listTskConditional)
            {
                // If is type FloatComparison ignore to avoid
                // monster walk in "statue" mode
                if (task.ToString() == typeof(FloatComparison).ToString())
                    continue;
                
                task.disabled = _isEnable;
                
                Melon<Main>.Logger.Msg($"{task.ToString()} is {_isEnable.ToString()}");
            }
            
            // Reset to Patrol status
            bhTree.DisableBehavior();
            bhTree.EnableBehavior();
        }
    }
}