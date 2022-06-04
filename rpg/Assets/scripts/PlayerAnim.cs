using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player Player;
    private Animator Anim;
    private Casting cast;
    private bool isHitting;
    private float recoveryTime = 1f;
    private float timeCount;

    [Header("Attack Seting")]
    [SerializeField] private Transform attackPointer;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask enemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Player>();
        Anim = GetComponent<Animator>();
        cast = FindObjectOfType<Casting>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnRun();
        if(isHitting)
        {
            timeCount += Time.deltaTime;

            if(timeCount >= recoveryTime)
            {
                isHitting = false;
                timeCount = 0f;
            }
        }
        
    }


    #region Moviment

        void OnMove()
        {
            //altera a anima��o para a anima��o idle se estiver parado
            if (Player.direction.sqrMagnitude > 0)
            {

                if (Player.isRolling)
                {
                    Anim.SetTrigger("isRoll");
                }else
                {
                    Anim.SetInteger("transition", 1);
                }

            }else
            {
                //altera a anima��o para andando se o personagem estiver andando
                Anim.SetInteger("transition", 0);
            }

            //rotaciona o personagem para direita se estiver indo para direita
            if (Player.direction.x > 0)
            {
                transform.eulerAngles = new Vector2(0, 0);
            }
            //rotaciona o personagem para esquerda se estiver indo para esquerda
            if (Player.direction.x < 0)
            {
                transform.eulerAngles = new Vector2(0, 180);
            }

            //animação de cortar
            if(Player.isCutting)
            {
                Anim.SetInteger("transition", 3);
            }
            //animação de cavar
            if(Player.isDigging)
            {
                Anim.SetInteger("transition", 4);
            }
             //animação de regar
            if(Player.isWaltering)
            {
                Anim.SetInteger("transition", 5);
            }
             //animação de ataque
            if(Player.isAttack)
            {
                Anim.SetInteger("transition", 6);
            }

        }
        
        void OnRun()
        {
            if (Player.isRunning)
            {
                Anim.SetInteger("transition", 2);
            }
        }

        
    #endregion

    #region Attack

        public void onAttack()
        {
            Collider2D hit = Physics2D.OverlapCircle(attackPointer.position,radius,enemyLayer);

            if(hit != null)
            {
                //pega um objeto filho
                hit.GetComponentInChildren<AnimationControl>().onHit();
            }
        }

        private void OnDrawGizmosSelected() {
            Gizmos.DrawWireSphere(attackPointer.position,radius);
        }

    #endregion



    //chamado quando jogador presiona botão de ação na agua
    public void onCastingStarted()
    {
        Anim.SetTrigger("isCasting");
        Player.isPaused = true;
    }
    //chamado quando termina a animação de pesca
    public void onCastingEnded()
    {
        cast.onCasting();
            Player.isPaused = false;
    }

    public void onHammeringStarted()
    {
        Anim.SetBool("hammering",true);
    }
    public void onHammeringEnded()
    {
        Anim.SetBool("hammering",false);
    }
    public void onHit()
    {
        if(!isHitting)
        {
            Anim.SetTrigger("isHit");
            isHitting = true;
        }
    }
}
