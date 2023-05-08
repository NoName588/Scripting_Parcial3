using System;
using UnityEngine;

public class SwitchToWeaponCommand : ICommand
{
    public int index = 0;
    public SwitchToWeaponCommand(int index)
    {
        this.index = index;
    }

    public void Execute()
    {
        RefactoredUIManager.Instance.SendMessage("EnableIcon", index);
    }
}