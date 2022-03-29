using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadCreditScene()
    {
        SceneManager.LoadScene("Credits Scene");
    }

    public void DelayLoadStartScene()
    {
        StartCoroutine(WaitLoadStartScene(2.5f));
    }

    private IEnumerator WaitLoadStartScene(float sec)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(0);
        FindObjectOfType<Score>().ScoreReset();
    }

    public void DelayLoadWinScene()
    {
        StartCoroutine(WaitLoadWinScene(1.5f));
    }

    private IEnumerator WaitLoadWinScene(float sec)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene("Game Win Scene");
    }

    public void DelayLoadNextScene()
    {
        StartCoroutine(WaitLoadNextScene(1.0f));
    }

    private IEnumerator WaitLoadNextScene(float sec)
    {
        yield return new WaitForSeconds(sec);
        int _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(_currentSceneIndex + 1);
    }

    public void LoadPreviousScene()
    {
        int _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(_currentSceneIndex - 1);
    }

    public void DelayQuitGame()
    {
        StartCoroutine(WaitQuitGame(1.5f));
    }

    private IEnumerator WaitQuitGame(float sec)
    {
        yield return new WaitForSeconds(sec);
        Application.Quit();
    }
}
