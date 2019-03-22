using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AchievementArgs : EventArgs {

    public readonly string Name;
    public readonly int value;
    public AchievementArgs(string name, int value)
    {
        Name = name;
        this.value = value;
    }
}
