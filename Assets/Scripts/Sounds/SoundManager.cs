using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource soundObj;

    private void Awake()
    {
        instance = this;
    }

    public void playSoundClip(AudioClip audio, Transform transform, float vol)
    {
        AudioSource source = Instantiate(soundObj, transform.position, Quaternion.identity);
        source.clip = audio;
        source.volume = vol;

        source.Play();
        float clipLenght = source.clip.length;
        Destroy(source.gameObject, clipLenght);
    }
}
