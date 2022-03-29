using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelState : MonoBehaviour
{
    [SerializeField] int blocksCount;

    [SerializeField] Ball ball;
    SceneLoader sceneLoader;
    SceneLoader winSceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        winSceneLoader = FindObjectOfType<SceneLoader>();
        ball = FindObjectOfType<Ball>();
    }

    public void BlocksCount()
    {
        blocksCount++;
    }

    public void BreakBlock()
    {
        blocksCount--;
        if (blocksCount <= 0)
        {
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                ball.SlowBall();
                winSceneLoader.DelayLoadWinScene();
            }
            ball.SlowBall();
            sceneLoader.DelayLoadNextScene();
        }
    }
}
