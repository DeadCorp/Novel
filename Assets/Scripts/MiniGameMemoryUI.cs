using DTT.MinigameBase.Timer;
using DTT.MinigameMemory;
using Naninovel.UI;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class MiniGameMemoryUI : CustomUI
{
    public MemoryGameManager GameManager;
    public CustomTimerUI timerUI;

    public void SetMaxGameTime(int time)
    {
        timerUI.maxGameTimer = new TimeSpan(0, 0, time);

    }
}


