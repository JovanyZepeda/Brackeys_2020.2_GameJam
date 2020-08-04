using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public SoundList[] sounds;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {

        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }



        DontDestroyOnLoad(gameObject);



        foreach(SoundList s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        
    }

    public void PlaySound (string name)
    {
        SoundList s = Array.Find(sounds, sound => sound.name == name);

        if(s == null)
        {
            Debug.LogWarning("Song with name< " + name + " >was not found");
            return;
        }

        s.source.Play();
    }



    private void Start()
    {
        PlaySound("Theme");

    }


}
