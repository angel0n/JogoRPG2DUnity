using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AnimationControl animationControl;

    [Header("Stats")]
    public float currentHealth;
    public float totalHealth;
    public Image healthBar;
    public bool isDeath;

    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;
        player = FindObjectOfType<Player>();
        //impede que o navMesh rotacione o objeto 
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(!isDeath)
        {
            agent.SetDestination(player.transform.position);

            if(Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
            {
                //chegou no limite e distancia / está parado
                animationControl.playAnim(2);
            }
            else{
                //chegindo o player
                animationControl.playAnim(1);

                if((player.transform.position.x - transform.position.x) > 0)
                {
                    transform.eulerAngles = new Vector2(0,0);
                }
                else
                {
                    transform.eulerAngles = new Vector2(0,180);
                }
            }
        }
        
    }
}
