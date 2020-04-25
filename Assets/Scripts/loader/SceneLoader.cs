using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : StateMachineBehaviour
{
    public static void loadScene(string level)
    {
        Varibles.coins = 0;
        string [] scenes = { "level1", "level2", "Main Menu" };
        foreach (var t in scenes)
        {
            Debug.Log("SUKA BLAT");
            if(t == level)
            {
                SceneManager.LoadScene(level, LoadSceneMode.Single);
                return;
            }
        }
        Debug.LogError("Level '" + level + "' dose not exist!");
    }
}
