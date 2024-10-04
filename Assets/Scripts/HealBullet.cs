using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBullet : Bullet
{
    [SerializeField] int heal;
    [SerializeField] float delay;

    PlayerMovement player;
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
        }
    }

    IEnumerator HealPlayer(){
        while(true){
            player.Heal(heal);
            print("healed");
            yield return new WaitForSeconds(delay);
        }
    }
}
