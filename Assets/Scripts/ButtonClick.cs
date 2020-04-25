using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public void LevelChose(string level)
    {
        SceneLoader.loadScene(level);
    }
    
    public void exit()
    {
        Application.Quit();
    }
}
