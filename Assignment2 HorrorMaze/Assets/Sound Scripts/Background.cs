using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public AudioSource backdropAudio;
    public AudioSource dangerComingAudio;
    public AudioSource cricketsAudio;

   
    // Start is called before the first frame update
    void Start()
    {
        // script needs to be attached to the main camera with an audio listener as well
        // audiosource gameobjs(with correlating name) should be dragged and dropped onto the script
        //ASN means Action Script's Name.
    }

    // Update is called once per frame
    void Update()               
    {
       // if (/*ASN.safe == true*/) // needs an boolean on the actions script where the player in danger is false, and safety is true
       // {
            //audios have to be made onto 2 seperate gameobjs audio sources, one for other backdrop and one for danger.
        //    backdropAudio.volume = 1;
      //      cricketsAudio.volume = 1;
      //  }
      ///  if (/*ASN.safe == false*/) // needs an boolean on the actions script where the players safety is false
       // {
      //      backdropAudio.volume = 0;
       //     cricketsAudio.volume = 0;
       //     dangerComingAudio.Play();
     //   }



    }
}
