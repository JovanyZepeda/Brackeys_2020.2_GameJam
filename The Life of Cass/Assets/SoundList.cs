using UnityEngine.Audio; //This namespace is added so that we can deal with audio sources and interactions with them in unity
using UnityEngine;

//This is a custom class made for the audio manager
//It will store all the atributes of a sound clip

[System.Serializable] //This will allow the inspector to show the public fields in the class
public class SoundList
{
    public string name;

    public AudioClip clip;


    
    [Range(0f, 1f)] //This is added so in the inspector, one can change this particular property
    public float volume; //This field is affected by the range above
    [Range(.1f,3f)]
    public float pitch;

    public bool loop; //This will loop a clip: true or false

    [HideInInspector] //We add this so that what ever is under it cannot be shown in the inspector
    public AudioSource source; //This is an object that will be used in AudioManager
 
}
