using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeProject_UI;

public class DebugTool : MonoBehaviour
{
    public void SpeedUp()
    {
        Time.timeScale += 1;
    }
    public void SpeedDown()
    {
        Time.timeScale -= 1;
    }

    public void SkillNoLimit()
    {
        var allSkillButton = GetComponentsInChildren<SkillButton>();
        foreach (var button in allSkillButton)
        {
            button.DebugModeSwitch();
        }
    }
}
