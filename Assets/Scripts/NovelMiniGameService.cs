using DTT.MinigameBase.UI;
using Naninovel;
using Naninovel.Commands;
using Naninovel.UI;
using System;
using UnityEngine;

[InitializeAtRuntime]
public class NovelMiniGameService : IEngineService
{
    private readonly int miniGameMaxTime = 60;

    public NovelMiniGameService()
    {

    }

    public UniTask InitializeServiceAsync()
    {
        return UniTask.CompletedTask;
    }

    public void ResetService()
    {
        // Reset service state here.
    }

    public void DestroyService()
    {
        // Stop the service and release any used resources here.
    }

    /// <summary>
    /// Attempts to retrieve item prefab with the specified identifier.
    /// </summary>
    public async UniTask StartMiniGameAsync()
    {
        var miniGameUI = Engine.GetService<IUIManager>().GetUI<MiniGameMemoryUI>();
        var customVariableManager = Engine.GetService<ICustomVariableManager>();
        miniGameUI.SetMaxGameTime(miniGameMaxTime);

        await miniGameUI.ChangeVisibilityAsync(true);

        Debug.Log("showUI MiniGameMemoryUI");

        var miniGameEndedTask = new UniTaskCompletionSource();

        miniGameUI.GameManager.Finish += (results) =>
        {
            Debug.Log(results);
            if (results.timeTaken.TotalSeconds < miniGameMaxTime)
            {
                customVariableManager.TrySetVariableValue("win", true);
            }
            miniGameEndedTask.TrySetResult();

        };


        await miniGameEndedTask.Task;

        // TODO add sfx 
        var command = new Wait();
        command.WaitMode = "1.25";
        await command.ExecuteAsync();

        await miniGameUI.ChangeVisibilityAsync(false);

        await UniTask.CompletedTask;
    }
}
