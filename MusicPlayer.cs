using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] songs;
    private AudioSource audioSource;
    private int currentSongIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayNextSong();
    }

    void Update()
    {
        // Check if the current song has finished playing
        if (!audioSource.isPlaying)
        {
            // Play the next song when the current one finishes
            PlayNextSong();
        }
    }

    void PlayNextSong()
    {
        // Play the current song
        audioSource.clip = songs[currentSongIndex];
        audioSource.Play();

        // Move to the next song index, and loop back to the start if at the end
        currentSongIndex = (currentSongIndex + 1) % songs.Length;
    }
}
