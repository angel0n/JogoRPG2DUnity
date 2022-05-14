using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Dialogue", menuName= "New Dialogue/Dialogue")]
public class DialogueSettings : ScriptableObject
{
    [Header("settings")]
    public GameObject actor;

    [Header("Dialogue")]
    public Sprite speakerSprite;
    public string sentence;

    public List<Setences> dialogue = new List<Setences>();
}

[System.Serializable]
public class Setences
{
    public string actorName;
    public Sprite profile;
    public Languages sentence;
}

[System.Serializable]
public class Languages
{
    public string portugueses;
    public string english;
    public string spanish;
}

#if UNITY_EDITOR
//cria um botão no editor da unity
    [CustomEditor(typeof(DialogueSettings))]

    public class BuilderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            DialogueSettings ds = (DialogueSettings)target;
            Languages l = new Languages();
            l.portugueses = ds.sentence;

            Setences s = new Setences();
            s.profile = ds.speakerSprite;
            s.sentence = l;

        if (GUILayout.Button("Create Dialogue"))
        {
            if (ds.sentence != "")
            {
                ds.dialogue.Add(s);

                ds.speakerSprite = null;
                ds.sentence = "";
            }
        }
            
        }
           
    }


#endif