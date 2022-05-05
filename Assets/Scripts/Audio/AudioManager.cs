using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Audio[] audioClips;
    void Awake()
    {
        foreach (Audio audioClip in audioClips) {
            audioClip.audioSource = gameObject.AddComponent<AudioSource>();
            audioClip.audioSource.clip = audioClip.clip;
            audioClip.audioSource.volume = audioClip.volume;
            audioClip.audioSource.pitch = audioClip.pitch;
            audioClip.audioSource.playOnAwake = audioClip.playOnAwake;
        }
    }

    public void PlaySound(string name)
    {
        Audio clip = Array.Find(audioClips, audioClip => audioClip.clipName == name);
        if (clip == null) {
            Debug.Log(name + " is not a valid name for an audio clip");
            return;
        }
        Debug.Log(name + " has been played");
        clip.audioSource.Play();
    }
}
