using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] AudioClip[] buttonSounds;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonSounds[UnityEngine.Random.Range(2, buttonSounds.Length)]);
    }

    public void PlayQuitButtonSound()
    {
        audioSource.PlayOneShot(buttonSounds[UnityEngine.Random.Range(0,2)]);
    }
}
