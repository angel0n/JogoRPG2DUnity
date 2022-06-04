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
    private Skeleton skeleton;

    private void Start() {
        anim = GetComponent<Animator>();
        //pega componente do obj pai
        skeleton = GetComponentInParent<Skeleton>();
    }

    public void playAnim(int value) 
    {
        anim.SetInteger("transition", value);
        playerAnim = FindObjectOfType<PlayerAnim>();
    }

    public void attack()
    {
        if(!skeleton.isDeath)
        {
            Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius,playerLayer);

            if(hit != null)
            {
                //detecta ataque no player
                playerAnim.onHit();
            }
        }
        
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(attackPoint.position,radius);
    }

    public void onHit()
    {

        if(skeleton.currentHealth <= 0)
        {
            skeleton.isDeath = true;
            anim.SetTrigger("death");
            Destroy(skeleton.gameObject,1f);
        }
        else
        {
            anim.SetTrigger("hit");
            skeleton.currentHealth--;

            skeleton.healthBar.fillAmount = skeleton.currentHealth / skeleton.totalHealth;
        }
    }
}
