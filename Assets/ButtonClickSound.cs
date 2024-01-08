using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour {

    // Use this for initialization
    public AudioSource Audio;

    void Start () {

	}
	public void PlaySound()
    {
        Audio.Play();
    }

}
