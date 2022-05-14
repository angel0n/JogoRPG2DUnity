using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    //aparece no menu da unity
    [System.Serializable]
    public enum idiom{
        pt,
        eng,
        spa
    }

    public idiom language;

    [Header("components")]
    public GameObject dialogueObj;//janela do dialogo
    public Image profileSprite;//sprite do perfil
    public Text speenchText;//texto da fala
    public Text actorNameText; //nome do npc

    [Header("Settings")]
    public float typingSpreed;//velocidade da fala

    private bool isShowing; // se a janela de dialogo está visível
    private int index; //index das sentenças
    private string[] sentences;

    public static DialogueControl instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speenchText.text += letter;
            yield return new WaitForSeconds(typingSpreed);

        }
    }

    //pular pra proxima fala
    public void NextSentence()
    {
        //verifica se o texto terminou
        if(speenchText.text == sentences[index]){
            //verifica se ainda tem texto
            if(index < sentences.Length - 1 ){
                /**
                    passa para o proximo index fala
                    zera o texto da tela 
                    faz aparecer o novo texto na tela
                */
                index++;
                speenchText.text = "";
                StartCoroutine(TypeSentence());
            }else{
                speenchText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                isShowing = false;
            }
        }
    }

    //chamar a fala do npc
    public void Speech(string[] txt)
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }

    }
}
