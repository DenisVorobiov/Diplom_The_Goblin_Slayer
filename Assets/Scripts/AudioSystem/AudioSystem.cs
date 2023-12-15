
using System;
using UnityEngine;

public interface IAudioSystem
{
     float MusicVolume { get; set; }
     float SFXVolume { get; set; }

    event Action<float> SFXVolumeChanged;
    event Action<float> MusicVolumeChanged;

    event Action<SoundSettings> OnSFX;
    event Action<SoundSettings> OnMusic;

    void PlaySFX(string key);
    void PlaySFX(SoundSettings setting);
    void PlayMusic(string key);
    void PlayMusic(SoundSettings setting);
}

public class AudioSystem : IAudioSystem

{
    public float SFXVolume { get; set; }
    public float MusicVolume { get; set; }
    public event Action<float> SFXVolumeChanged;
    public event Action<float> MusicVolumeChanged;
    public event Action<SoundSettings> OnSFX;
    public event Action<SoundSettings> OnMusic;

    public void PlaySFX(string key)
    {
        PlaySFX(new SoundSettings(key));
    }

    public void PlaySFX(SoundSettings setting)
    {
        OnSFX?.Invoke(setting);
    }

    public void PlayMusic(string key)
    {
        PlayMusic(new SoundSettings(key));
    }

    public void PlayMusic(SoundSettings setting)
    {
        OnMusic?.Invoke(setting);
    }
}

