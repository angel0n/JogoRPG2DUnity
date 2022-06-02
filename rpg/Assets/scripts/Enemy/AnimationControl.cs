using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;

    private Animator anim;
    private PlayerAnim playerAnim;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    public void playAnim(int value) 
    {
        anim.SetInteger("transition", value);
        playerAnim = FindObjectOfType<PlayerAnim>();
    }

    public void attack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius,playerLayer);

        if(hit != null)
        {
            //detecta ataque no player
            playerAnim.onHit();
        }
        else
        {
            
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(attackPoint.position,radius);
    }
}
