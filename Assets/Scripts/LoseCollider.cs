using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    [SerializeField] AudioClip[] looseSounds;

    AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(looseSounds[UnityEngine.Random.Range(0, looseSounds.Length)]);
        StartCoroutine(Wait(1.5f));
    }

    private IEnumerator Wait(float sec)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene("Game Over Scene");
    }
}
