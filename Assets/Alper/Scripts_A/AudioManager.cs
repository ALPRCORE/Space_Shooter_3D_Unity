using UnityEngine.Audio;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sources;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(gameObject);


        foreach (Sound s in sources)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
    }
    private void Start()
    {
        PlaySound("Theme");
    }
    private void Update()
    {
        if (GameManager.score >= 25)
        {
            Destroy(gameObject);
        }
    }
    public void PlaySound(string name)
    {
        Sound source = Array.Find(sources, source => source.name == name);
        if (source == null) return;
        source.source.Play();
      
    }
}
