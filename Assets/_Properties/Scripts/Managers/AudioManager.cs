using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioSource audioSource;
    public static AudioClip[] clips;

    [SerializeField] AudioClip[] loadClips;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        clips = new AudioClip[loadClips.Length];
        for (int index = 0; index < loadClips.Length; index++)
        {
            clips[index] = loadClips[index];
        }
    }
    private void Start()
    {
        PlayClip(0);
    }

    public static void PlayClip(int index)
    {
        audioSource.clip = clips[index];
        audioSource.Play();
    }

    public static void PlayClipOnce(int index)
    {
        audioSource.PlayOneShot(clips[index]);
    }
}
