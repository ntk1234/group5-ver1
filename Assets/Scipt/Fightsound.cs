using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fightsound : MonoBehaviour

  


{
    public AudioClip fightSound;
    private AudioSource myAduioSource;
    // Start is called before the first frame update
    void Start()
    {
        myAduioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        myAduioSource.PlayOneShot(fightSound);
    }
}
