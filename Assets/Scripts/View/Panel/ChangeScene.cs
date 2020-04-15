using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void ChangeSceneVirus(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGameVirus()
    {
        Application.Quit();
    }
}
