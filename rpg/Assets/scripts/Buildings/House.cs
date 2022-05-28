using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [Header("Amounts")]
    [SerializeField] private int woodAmount;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private float timeAmount;

    [Header("Components")]
    [SerializeField] private SpriteRenderer houseSprite;
    [SerializeField] private Transform point;
    [SerializeField] private GameObject colider;


    private bool detectingPlayer;
    private Player player;
    private float timeCount;
    private bool isBegining;
    private PlayerAnim playerAnim;
    private PlayerItens playerItens;
    

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        playerAnim = player.GetComponent<PlayerAnim>();
        playerItens = player.GetComponent<PlayerItens>();
    }

    // Update is called once per frame
    void Update()
    {
        if(detectingPlayer && Input.GetKeyDown(KeyCode.E) && playerItens.totalWood >= woodAmount )
        {
            //construção começa
            isBegining = true;
            playerAnim.onHammeringStarted();
            houseSprite.color = startColor;
            player.transform.position = point.position;
            player.isPaused = true;
            colider.SetActive(true);
            playerItens.totalWood -= woodAmount;
        }

        if(isBegining)
        {
            timeCount += Time.deltaTime;

            if(timeCount >= timeAmount)
            {
                //casa é finalizada 
                playerAnim.onHammeringEnded();
                houseSprite.color = endColor;
                player.isPaused = false;

            }
        }

    }
    //detecta a entrada 
    
    private void OnTriggerEnter2D(Collider2D collision)
   {
       if(collision.CompareTag("Player"))
       {
           detectingPlayer = true;
       }
   }
    //detecta a saida 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }
}
