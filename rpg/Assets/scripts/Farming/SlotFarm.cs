using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Audio")]
   [SerializeField] private AudioSource audioSource;
   [SerializeField] private AudioClip holeSFX;
   [SerializeField] private AudioClip carrotSFX;

   [Header("Components")]
   [SerializeField] private SpriteRenderer spriteRender;
   [SerializeField] private Sprite hole;
   [SerializeField] private Sprite carrot;

   [Header("Settings")]
   [SerializeField] private int digAmount; // quantidade para aparecer o hole
   [SerializeField] private bool detecting; // detecta a agua
   [SerializeField] private bool detectingPlayer; // detecta o player
   [SerializeField] private float waterAmount; //total de agua para nascer

    private int initialDigAmount;
    private float currentWater;
    private bool dugHole;
    private bool plantedCarrot;

    PlayerItens playerItens;


    public void Start()
    {
        playerItens = FindObjectOfType<PlayerItens>();
        initialDigAmount = digAmount;
    }

    public void Update()
    {
        if(dugHole)
        {
            if (detecting)
            {
                currentWater += 0.01f;
            }

            //atingiu o total de agua
            if(currentWater >= waterAmount && !plantedCarrot)
            {
                audioSource.PlayOneShot(holeSFX);
                spriteRender.sprite = carrot;
                plantedCarrot = true;
                
            }
            if(Input.GetKeyDown(KeyCode.E) && detectingPlayer && plantedCarrot)
                {
                    audioSource.PlayOneShot(carrotSFX);
                    spriteRender.sprite = hole;
                    playerItens.totalCarrot++;
                    currentWater = 0;
                    plantedCarrot = false;
                }
        }
        
    }   

   public void onHit()
   {
       digAmount --;

       if(digAmount <= initialDigAmount / 2)
       {
           spriteRender.sprite = hole;
           dugHole = true;
       }
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
       if(collision.CompareTag("Dig"))
       {
           onHit();
       }
       if(collision.CompareTag("Water"))
       {
           detecting = true;
       }
       if(collision.CompareTag("Player"))
       {
           detectingPlayer = true;
       }
   }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Water"))
        {
            detecting = false;
        }
         if(collision.CompareTag("Player"))
       {
           detectingPlayer = false;
       }
    }

}
