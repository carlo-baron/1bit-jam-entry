using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBullet : Bullet
{
    [SerializeField] int heal;
    [SerializeField] float delay;
    PlayerMovement player;

    AudioManage audioPlayer;

    public override void Awake(){
        audioPlayer = FindObjectOfType<AudioManage>();
        base.Awake();
    }
    public override void Start(){
        audioPlayer.PlaySFX(audioPlayer.healBullet);
        base.Start();
    }
    
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("player")){
            player = other.GetComponent<PlayerMovement>();
            StartCoroutine(HealPlayer());
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("player")){
            StopCoroutine(HealPlayer());
            player = null;
        }
    }

    IEnumerator HealPlayer(){
        while(true){
            player?.Heal(heal);
            yield return new WaitForSeconds(delay);
        }
    }
}
