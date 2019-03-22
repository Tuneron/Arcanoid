using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class Observer : MonoBehaviour {

    Subject subject;
    public HUD Hud;
    public Player player;
    private bool[] AchievementsStat = new bool[64];

    public void Subscribe()
    {
        subject.AchievementsHandler += AchievementGet;    
    }

    public void UnSubscribe()
    {
        subject.AchievementsHandler -= AchievementGet;
    }

    private void AchievementGet(object sender, AchievementArgs e) // Achievement #0
    {
        switch (e.Name)
        {
            case "AddHp":
                {
                    player.AddHp();
                    break;
                }
        }
    }

    private void Update()
    {
        if (Hud.Score == 500 && !AchievementsStat[0])
        {
            subject.NotifyObservers(this, new AchievementArgs("AddHp", 0));
            AchievementsStat[0] = true;
        }
    }

    private void Start()
    {
        this.subject = new Subject();
        this.Subscribe();
    }
}
