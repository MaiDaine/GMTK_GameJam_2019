using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance = null;

    public AudioClip[] audioClips;
    public int volume = 2;

    private AudioSource audioSource;
    private int audioIndex = 1;
    private bool volumeSwitch = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = (float)volume * 0.4f;
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = audioClips[audioIndex];
            audioSource.Play();
            audioIndex = (audioIndex + 1) % audioClips.Length;
        }
    }

    public void ChangeVolume()
    {
        if (!volumeSwitch)
            volume -= 1;
        else
            volume += 1;
        if (volume == 0 || volume == 2)
            volumeSwitch = !volumeSwitch;
        audioSource.volume = 0.4f * (float)volume;
    }
}
