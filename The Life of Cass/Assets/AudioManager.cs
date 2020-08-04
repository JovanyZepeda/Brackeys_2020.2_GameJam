using UnityEngine.Audio; //This namespace is added so that we can deal with audio sources and interactions with them in unity
using UnityEngine;
using System;



//To access this class, we use the following cammmand:
//FindObjectOfType<AudioManager>()."Method Name"
//or creat an instance of the AudioManager class and use it that way



public class AudioManager : MonoBehaviour
{
    public SoundList[] sounds; //using the costum class SoundList, we make an array with it. We make an array because we want mutlitple sound clips

    public static AudioManager instance; //We create this so that we can onle havve one instance of AudioManager. Hence it is Static

    // Start is called before the first frame update
    void Awake()
    {
        //Here we check if there is alraedy an instance of the AudioManager object
        //if there is one we will destory it so that there can only be one instance of AudioManager
        if(instance == null) //if there is no instance of AudioManager 
        {
            instance = this; //set instance equal to this gameobject
        } else // If there already is an object of AudioManager
        {
            Destroy(gameObject); // we will destory this new one that survived the transition of scenes
            return; //prevent anymore code from being read
        }


        ///This works with the if else statement above
        ///the argument "gameObject" refers to the object that has this scripe attached
        ///Essentially whenever a new scene is loaded in, this method will prevent an object from being destroy durng the transition
        ///thus the gameobject will persist in all scenes
        DontDestroyOnLoad(gameObject);


        //This code will copy and paste the properties listed in the custom class SoundList to the AudioManager
        //We do this so that we can see the individual cliips and thier properties in the inspector
        foreach(SoundList s in sounds) // This will go through the array of "sounds" which is an objject of the class "SoundList"
        {
            s.source = gameObject.AddComponent<AudioSource>(); //This will add every song as a comonant in the AudioManager object

            //Here we are essentially coppying data from every instance of the custom class "SoundList" and 
            //Pasting it to the componant Audio Source
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        
    }


    //This method willplay a song from the soundlist
    //It will need the name of the clip in order to find and play it
    //this name is configures in the inspector
    public void PlaySound (string name)
    {
        SoundList s = Array.Find(sounds, sound => sound.name == name); //Find a particula element in the array

        if(s == null) //if we could not find the specified sound clip
        {
            Debug.LogWarning("Song with name< " + name + " >was not found");
            return;
        }

        s.source.Play(); //Play that song
    }


    //This is done so that the main them is played 
    private void Start()
    {
        PlaySound("Theme");

    }


}
