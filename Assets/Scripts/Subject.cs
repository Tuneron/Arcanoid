using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Subject : MonoBehaviour {

    public delegate void SubjectAcievementHadler(object sender, AchievementArgs e);

    public event SubjectAcievementHadler AchievementsHandler;

    public void NotifyObservers(object sender, AchievementArgs e)
    {
        if (AchievementsHandler != null)
            AchievementsHandler(sender, e); 
    }
}
