using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    public enum Sound
    {
        MenuSound,
        BombExplosion,
        PlayerHurt,
        PlayerDie
    }
    public static void PlaySound(Sound sound, float volume)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(sound), volume);
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAsset.SoundAudioClip soundAudioClip in GameAsset.Instance.soundAudioClipsArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.Log("Sound: "+sound+" not found!");
        return null;
    }
    
}
