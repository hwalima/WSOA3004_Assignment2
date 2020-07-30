using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public AudioSource walkingAudio;
    public AudioSource jumpingAudio;
    public AudioSource tba1Audio;
    public AudioSource tba2Audio;

    
    // Start is called before the first frame update
    void Start()
    {
        // script needs to be attached to the main camera with an audio listener as well
        // audiosource gameobjs(with correlating name) should be dragged and dropped onto the script
        //ASN means Action Script's Name.
        // the ASN should have booleans to know when these actions are happeneing and the very same booleans to trigger sounds
        // by checking them from your script by iits name 
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<PlayerMovement>().walking == true)   // if statement to know when DRINKING
        {
            //audios have to be made onto 4 seperate gameobjs with audio sources
           walkingAudio.Play();
           walkingAudio.volume = 1;
        }
        else
        {
            FindObjectOfType<PlayerMovement>().walking = false;
        }

        if (FindObjectOfType<PlayerMovement>().jumping == true) // if statement to know when jumping
        {
            jumpingAudio.Play();
            jumpingAudio.volume = 1;
        }
        else
        {
            FindObjectOfType<PlayerMovement>().jumping = false;
         }

    }
}
