using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public PlayerController playerController;
    public AudioClip[] musicTracks;
    private int trackIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trackIndex = 0;
        musicAudioSource.loop = false;
        musicAudioSource.PlayOneShot(musicTracks[0]);
        Debug.Log("Starting with track #" + trackIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (!musicAudioSource.isPlaying && !playerController.isGameOver)
        {
            trackIndex++;
            if (trackIndex >= musicTracks.Length)
            {
                trackIndex = 0;
            }
            Debug.Log("Now playing track #" + trackIndex);
            musicAudioSource.PlayOneShot(musicTracks[trackIndex]);
        }

    }
}
