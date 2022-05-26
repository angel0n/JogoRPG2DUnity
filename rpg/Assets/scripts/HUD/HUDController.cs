using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //biblioteca de controle de UI

public class HUDController : MonoBehaviour
{

    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;

    private PlayerItens playerItens;

    //chamado antes do Start
    private void Awake()
    {
        playerItens = FindObjectOfType<PlayerItens>();
    }

    // Start is called before the first frame update
    void Start()
    {
        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        waterUIBar.fillAmount = playerItens.currentWater / playerItens.waterLimit;
        woodUIBar.fillAmount = playerItens.totalWood / playerItens.woodLimit;
        carrotUIBar.fillAmount = playerItens.totalCarrot / playerItens.carrotLimit;
    }
}
