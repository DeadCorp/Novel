using Naninovel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestLogDropdown : ScriptableDropdown
{
    [ManagedText("CustomUI")]
    protected static string QuestLog1 = "_";
    [ManagedText("CustomUI")]
    protected static string QuestLog2 = "Talk with Oliver";
    [ManagedText("CustomUI")]
    protected static string QuestLog3 = "Talk with Josh";
    [ManagedText("CustomUI")]
    protected static string QuestLog4 = "Go on north and find DUCK";
    [ManagedText("CustomUI")]
    protected static string QuestLog5 = "Return to Josh";
    [ManagedText("CustomUI")]
    protected static string QuestLog6 = "Go to Oliver";
    [ManagedText("CustomUI")]
    protected static string QuestLog7 = "Decide who must own item";
    [ManagedText("CustomUI")]
    protected static string QuestLog8 = "Job is Done";

    private ICameraManager cameraManager;

    protected override void OnEnable()
    {
        base.OnEnable();

        InitializeOptions();

        if (Engine.TryGetService<ILocalizationManager>(out var localeManager))
            localeManager.OnLocaleChanged += HandleLocaleChanged;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        if (Engine.TryGetService<ILocalizationManager>(out var localeManager))
            localeManager.OnLocaleChanged -= HandleLocaleChanged;
    }

    private void InitializeOptions()
    {
        List<string> availableOptions = new List<string>(8);

        availableOptions.Add(QuestLog1);
        availableOptions.Add(QuestLog2);
        availableOptions.Add(QuestLog3);
        availableOptions.Add(QuestLog4);
        availableOptions.Add(QuestLog5);
        availableOptions.Add(QuestLog6);
        availableOptions.Add(QuestLog7);
        availableOptions.Add(QuestLog8);
        

        UIComponent.ClearOptions();
        UIComponent.AddOptions(availableOptions);
        //UIComponent.value = cameraManager.QualityLevel;
        UIComponent.RefreshShownValue();
    }

    private void HandleLocaleChanged(string locale) => InitializeOptions();

}
