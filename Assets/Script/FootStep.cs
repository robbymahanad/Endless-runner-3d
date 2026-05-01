using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    public AudioClip[] footStepSound;
    public AudioSource footStepSource;


    public void FootStepPlay()
    {
        int index = Random.Range(0, footStepSound.Length);
        footStepSource.PlayOneShot(footStepSound[index]);
    }
}
