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
    private bool m_dispear = false;
    private float m_interval = 0;

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
        PlayMusic("questionbgm");
    }

    public void PlayMusic(string name,bool loop = false)
    {
        m_dispear = false;
        m_musicPlayer.volume = 1;
        m_musicPlayer.Stop();
        m_musicPlayer.loop = loop;
        if(m_musicPlayer.isPlaying == false)
        {
            var audioClip = Resources.Load<AudioClip>(string.Format(MUSIC_DIR,name));
            m_musicPlayer.clip = audioClip;
            m_musicPlayer.Play();
        }

    }

    public void DispearMusic()
    {
        m_dispear = true;
    }

    private void Update()
    {
        if(m_dispear)
        {
            m_interval += Time.deltaTime;
            if(m_interval >= 0.1f)
            {
                m_interval = 0;
                float vol = m_musicPlayer.volume;
                vol -= 0.02f;
                if(vol <= 0)
                {
                    vol = 0;
                    m_musicPlayer.volume = 0;
                    m_dispear = false;
                }
                else
                {
                    m_musicPlayer.volume = vol;
                }
            }
        }
    }

    public void PlaySound(string name)
    {
        var audioClip = Resources.Load<AudioClip>(string.Format(SOUND_DIR,name));
        m_SoundPlayer.clip = audioClip;
        m_SoundPlayer.Play();
    }
}
