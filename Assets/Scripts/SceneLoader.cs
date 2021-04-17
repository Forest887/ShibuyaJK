using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    string loadScene;

    public void SceneLoad(string loadScene)
    {
        SceneManager.LoadScene(loadScene);
    }

    public void DelayLoad(string loadScene)
    {
        this.loadScene = loadScene;
        Invoke("Load", 1);
    }

    void Load()
    {
        SceneManager.LoadScene(loadScene);
    }
}
