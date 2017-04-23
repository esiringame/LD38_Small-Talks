using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    GameObject Player;

    AudioSource[] music;
	// Use this for initialization
	void Start () {
        music = GetComponents<AudioSource>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(music[0].clip.name);
        Debug.Log(music[1].clip.name);
        //1 is slow, 0 is fast
        music[0].Play();
    }
	
	// Update is called once per frame
	void Update () {
        if(Player.GetComponent<PlayerBehaviour>().GetState() == PlayerBehaviour.State.Talking)
        {
            Debug.Log("talking");
            if (!music[1].isPlaying)
            {
                music[1].Play();
                music[0].Pause();
            }
        } else
        {
            if (!music[0].isPlaying)
            {
                music[0].Play();
                music[1].Stop();
            }
        }

    }


}
