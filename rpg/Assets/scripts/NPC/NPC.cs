using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
   //velocidade 
   public float speed;
   private float initialSpeed;
   //proximo path
   private int index;
   //seta a animação do npc
   private Animator anim;
   //lista com os Paths
   public List<Transform> paths = new List<Transform>();

    private void Start()
    {
        initialSpeed = speed;
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(DialogueControl.instance.isShowing)
        {
            speed = 0f;
            anim.SetBool("isWalking", false);
        }
        else
        {
            speed = initialSpeed;
            anim.SetBool("isWalking", true);
        }
        //move o npc 1 parametro posição atual, 2 parametro posição destino, 3 parametro velocidade
        transform.position = Vector2.MoveTowards(transform.position,paths[index].position, speed * Time.deltaTime);

        // verifica se o npc está no lugar de chegada, devolve a subtração de uma posição da outra
        if(Vector2.Distance(transform.position,paths[index].position) < 0.1f)
        {
            if(index < paths.Count - 1)
            {
                //index++;
                index = Random.Range(0,paths.Count - 1);
            }
            else
            {
                index = 0;
            }
        }
        //verifica o lado que o npc esta indo
        Vector2 direction = paths[index].position - transform.position;
        //se o eixo x for positivo indo para direita
        if(direction.x > 0)
        {
            //eulerAngles é a rotação
            transform.eulerAngles = new Vector2(0,0);
        }
        //se o eixo x for negativo indo para esquerda
        if(direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0,180);
        }
    }
}
