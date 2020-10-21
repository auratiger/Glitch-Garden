using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private int timeToWait = 4;
    
    private int _currentSceneIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (_currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    private IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(_currentSceneIndex + 1);
    }

    public void LoadSettingsScreen()
    {
        SceneManager.LoadScene("Settings Screen");
    }

    public void LoadStartScreen()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadLevelMenu()
    {
        SceneManager.LoadScene("Menu Screen");
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void RetryLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_currentSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
