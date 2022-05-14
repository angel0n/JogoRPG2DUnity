using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{

    public float dialogueRange;
    public LayerMask playerLayer;

    public DialogueSettings dialogue;
    bool playerHit;
    private List<string> sentences = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        GetNPCInfo();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            DialogueControl.instance.Speech(sentences.ToArray());
        }
    }

    public void GetNPCInfo()
    {
        for(int i = 0; i < dialogue.dialogue.Count; i++)
        {
            switch(DialogueControl.instance.language){
                case DialogueControl.idiom.pt:
                    sentences.Add(dialogue.dialogue[i].sentence.portugueses);
                    break;
                case DialogueControl.idiom.eng:
                    sentences.Add(dialogue.dialogue[i].sentence.english);
                    break;
                case DialogueControl.idiom.spa:
                    sentences.Add(dialogue.dialogue[i].sentence.spanish);
                    break;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if (hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }

}
