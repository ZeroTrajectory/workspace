using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource m_musicPlayer;
    [SerializeField]
    private AudioSource m_SoundPlayer;

    private const string MUSIC_DIR = "Music/{0}";

    private const string SOUND_DIR = "Sound/{0}";

    private static AudioManager m_instance = null;
    public static AudioManager GetInstance()
    {
        if(m_instance == null)
        {
            Debug.LogError("AudioManager instance is null!");
            return null;
        }
        return m_instance;
    }

    private void Start()
    {
        m_instance = this;
    }

    public void PlayMusic(string name)
    {
        m_musicPlayer.Stop();
        if(m_musicPlayer.isPlaying == false)
        {
            var audioClip = Resources.Load<AudioClip>(string.Format(MUSIC_DIR,name));
            m_musicPlayer.clip = audioClip;
            m_musicPlayer.Play();
        }

    }

    public void PlaySound(string name)
    {
        var audioClip = Resources.Load<AudioClip>(string.Format(SOUND_DIR,name));
        m_SoundPlayer.clip = audioClip;
        m_SoundPlayer.Play();
    }
}
