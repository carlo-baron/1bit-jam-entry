using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManage : MonoBehaviour
{
    [Header("Sources")]
    [SerializeField] AudioSource BGM;
    [SerializeField] AudioSource SFX;

    [Header("CLIPS")]
    public AudioClip background; 
    public AudioClip win; 
    public AudioClip boostCollect; 
    public AudioClip boostSpawn; 
    public AudioClip bullet; 
    public AudioClip cannon; 
    public AudioClip enemiesHit; 
    public AudioClip gameOver; 
    public AudioClip healBullet; 
    public AudioClip playerHit; 
    public AudioClip retry; 
    public AudioClip tileBreak; 
    public AudioClip death; 
    
    void Start()
    {
        BGM.clip = background;
        BGM.Play();
    }

    public void PlaySFX(AudioClip sfx)
    {
        SFX.PlayOneShot(sfx);
    }
}
