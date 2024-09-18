using UnityEngine;
using System;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{
    public Sound[] musicSounds; 
    public Sound[] sfxSounds;

    public static AudioManager instance;


    [SerializeField] public Slider musicSlider;
    [SerializeField] public Slider sfxSlider;

    public float musicSettingVolume;
    public float sfxSettingVolume;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);


        foreach(Sound s in musicSounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;

            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;
        }
        foreach (Sound s in sfxSounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;

            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;
        }

        
    }
    private void Start()
    {
        Play("Theme");
        Play("Nature");
    }
    public void setVolumeSFX(float volume)
    {
        sfxSettingVolume = volume;
        foreach(Sound s in sfxSounds)
        {
            if (sfxSettingVolume == 0)
            {
                s.audioSource.volume = 0;
            }
            else
            {
                s.audioSource.volume = s.volume * (sfxSettingVolume / 100.0f);
            }
        }
    }
    public void setVolumeMusic(float volume)
    {
        musicSettingVolume = volume;
        
        foreach (Sound s in musicSounds)
        {
            if (musicSettingVolume == 0)
            {
                s.audioSource.volume = 0;
            }
            else
            {
                s.audioSource.volume = s.volume * (musicSettingVolume / 100.0f);
            }
        }
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sfxSounds, sound => sound.name == name);
        if (s == null) {
            s = Array.Find(musicSounds, sound => sound.name == name);
            if (s == null)
            {
                return;
            }
        }
        s.audioSource.Play();
    }
    public void StopPlaying(string name)
    {
        Sound s = Array.Find(sfxSounds, sound => sound.name == name);
        if (s == null)
        {
            s = Array.Find(musicSounds, sound => sound.name == name);
            if(s == null)
            {
                return ;
            }
        }
        s.audioSource.Stop();

    }

    public void ButtonHover()
    {
        Play("Hover");
    }
    public void ButtonClicked()
    {
        instance.Play("click");
    }
}
