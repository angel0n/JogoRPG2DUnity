using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player Player;
    private Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Player>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnRun();
    }


    #region Moviment

        void OnMove()
        {
            //altera a animação para a animação idle se estiver parado
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
                //altera a animação para andando se o personagem estiver andando
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
        }
        
        void OnRun()
        {
            if (Player.isRunning)
            {
                Anim.SetInteger("transition", 2);
            }
        }
    #endregion

}
