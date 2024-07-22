using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public static audioManager instance;
    [SerializeField] private Volumes sfx;

    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)]
        public float volume = 0.7f;
        public bool loop = false;
        public bool playonAwake = false;

        [HideInInspector]
        public AudioSource source;
    }

    public List<Sound> sounds = new List<Sound>();
    private float currrentVolume;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound _sounds in sounds)
        {
            _sounds.source = gameObject.AddComponent<AudioSource>();
            _sounds.source.clip = _sounds.clip;
            _sounds.source.volume = sfx.volume;
            currrentVolume = _sounds.volume;
            _sounds.source.loop = _sounds.loop;
            _sounds.source.playOnAwake = _sounds.playonAwake;
        }
    }
    private void Update()
    {
        if (sfx.volume != currrentVolume)
        {
            foreach (Sound _sounds in sounds)
            {
                _sounds.source.volume = sfx.volume;
                currrentVolume = _sounds.source.volume;
            }
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
