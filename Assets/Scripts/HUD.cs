using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    private const int HP_MAX = 5;
    private const int LVL_MAX = 4;
    private Text ScorePoints;
    private bool GameIsPause;
    private GameObject PauseLogo;
    private int CurrentLevl;

    GameObject[] Hearts;
    public int Score;
    // Use this for initialization
    void Start()
    {
        ScorePoints = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();

        PauseLogo = GameObject.FindGameObjectWithTag("Pause");
        PauseLogo.SetActive(false);

        Hearts = GameObject.FindGameObjectsWithTag("Hp");
        Array.Sort(Hearts, CompareObNames);

        Score = 0;
        GameIsPause = false;
        CurrentLevl = int.Parse(SceneManager.GetActiveScene().name[SceneManager.GetActiveScene().name.Length - 1].ToString());
        Debug.Log(string.Format("current lvl: {0}", CurrentLevl));
    }

    int CompareObNames(GameObject x, GameObject y)
    {
        return x.name.CompareTo(y.name);
    }

    // Update is called once per frame
    void Update()
    {
        ScorePoints.text = Score.ToString();

        if (Input.GetKeyDown("space"))
        {
            if (!GameIsPause)
            {
                PauseLogo.SetActive(true);
                Time.timeScale = 0;
                GameIsPause = !GameIsPause;
            }
            else
            {
                PauseLogo.SetActive(false);
                Time.timeScale = 1;
                GameIsPause = !GameIsPause;
            }
        }

        if (Input.GetKeyDown("escape"))
            SceneManager.LoadScene("Menu");

        if (GameObject.FindGameObjectWithTag("Block") == null && CurrentLevl + 2 <= LVL_MAX)
            SceneManager.LoadScene(CurrentLevl + 2);
    }

    public void SetHp(int value)
    {
        Debug.Log(value);

        if (value <= HP_MAX && value >= 0)
        {
            for (int i = 0; i < value; i++)
                Hearts[i].SetActive(true);
            for (int i = value; i < HP_MAX; i++)
                Hearts[i].SetActive(false);
        }

        if (value == -1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }
    }

    public void AddScore(int value)
    {
        Score += value;
    }
}

