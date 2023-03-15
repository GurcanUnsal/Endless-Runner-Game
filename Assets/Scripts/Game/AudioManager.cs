using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<Sound> sounds;
    void Start()
    {
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.loop = sound.loop;
            sound.source.volume = sound.volume;
        }

        PlaySound("MainTheme");
    }

    public void PlaySound(string name)
    {
        foreach (Sound sound in sounds)
        {
            if(sound.name.Equals(name))
            {
                sound.source.Play();
            }
        }
    }
}
