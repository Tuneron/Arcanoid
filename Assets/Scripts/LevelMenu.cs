using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour {

    public void LevelLoad(int level)
    {
        SceneManager.LoadScene(string.Format("Level{0}", level));
    }

}
