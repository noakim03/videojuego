using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{
    public string _minigameSceneName;


    private void Start()
    {
        SceneManager.LoadSceneAsync(_minigameSceneName, LoadSceneMode.Additive);
    }

    public void ReturnToMainScene()
    {
        SceneManager.UnloadSceneAsync(_minigameSceneName);
    }
}
