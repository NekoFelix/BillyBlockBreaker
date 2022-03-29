using UnityEngine;

public class TimeScale : MonoBehaviour
{
    [Range(0.1f, 10f)][SerializeField] private float gameSpeed = 1f;

    void Update()
    {
        Time.timeScale = gameSpeed;
    }
}
