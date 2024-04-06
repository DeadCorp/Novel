using Naninovel;
using Naninovel.Commands;
using UnityEngine;
using Naninovel.UI;

[CommandAlias("memory_minigame")]
public class NovelMiniGameStart : Command
{
    public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var customService = Engine.GetService<NovelMiniGameService>();

        await customService.StartMiniGameAsync();
    }
}
