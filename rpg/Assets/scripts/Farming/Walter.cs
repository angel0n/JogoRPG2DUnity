using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walter : MonoBehaviour
{   
    [SerializeField] private bool detectingPlayer;
    [SerializeField] private int waterValue;
    
    private PlayerItens player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerItens>();
    }

    // Update is called once per frame
    void Update()
    {
        if(detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            player.waterIncrement(waterValue);
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
