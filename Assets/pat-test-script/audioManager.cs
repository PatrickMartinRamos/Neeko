using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public static audioManager instance;

    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)]
        public float volume = 0.7f;
        public bool loop = false;
        public bool playonAwake = false;  
        public AudioSource source;
    }

    public List<Sound> sounds = new List<Sound>();

    void Awake()
    {
    
    }

    private void Update()
    {
        //if (instance == null)
        //{
        //    instance = this;
        //}
        //else
        //{
        //    Destroy(gameObject);
        //    return;
        //}

        foreach (Sound _sounds in sounds)
        {
            _sounds.source = gameObject.AddComponent<AudioSource>();
            _sounds.source.clip = _sounds.clip;
            _sounds.source.volume = _sounds.volume;
            _sounds.source.loop = _sounds.loop;
            _sounds.source.playOnAwake = _sounds.playonAwake;
        }
    }
    public void Play(string name)
    {
        // Find the Sound object in the sounds List where the name matches the provided 'name'.
        Sound _sounds = sounds.Find(sound => sound.name == name);

        if (_sounds == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        _sounds.source.Play();
    }

    public void Stop(string name)
    {
        Sound _sounds = sounds.Find(sound => sound.name == name);
        if (_sounds == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        _sounds.source.Stop();
    }


}
