using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinSound : MonoBehaviour {

    GameObject Player;
    AudioSource music;
    bool playerLastState;
	// Use this for initialization
	void Start () {
        music = GetComponent<AudioSource>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<PlayerBehaviour>().GetState() == PlayerBehaviour.State.Hidding && playerLastState == false)
        {
            music.Play();
            playerLastState = true;
        }
        if (Player.GetComponent<PlayerBehaviour>().GetState() != PlayerBehaviour.State.Hidding && playerLastState == true)
        {
            music.Play();
            playerLastState = false;
        }


    }
}
