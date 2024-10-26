using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _musicGroup;
    [SerializeField] private AudioMixerGroup _sfxGroup;

    [SerializeField] private List<Sound> _soundList;

    public static AudioManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        foreach (Sound sound in _soundList)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
          
            audioSource.outputAudioMixerGroup = sound.Name.StartsWith("M_") ? _musicGroup : _sfxGroup;
            audioSource.clip = sound.AudioClip;
            audioSource.volume = sound.Volume;
            audioSource.pitch = sound.Pitch;
            audioSource.loop = sound.Loop;
            
            sound.AudioSource = audioSource;
        }

        PlayAudio("M_Background");
    }

    public void PlayAudio(string name)
    {
        Sound sound = _soundList.Where(t => t.Name.Equals(name)).FirstOrDefault();
        sound?.AudioSource.Play();
    }
}
