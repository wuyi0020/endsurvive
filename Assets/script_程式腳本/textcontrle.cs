using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class textcontrle : MonoBehaviour
{
    [Header("文字物件")]
    public TextMeshProUGUI didalogua;
    [Header("名字")]
    public TextMeshProUGUI Name;

    Queue<string> story;
    void Start()
    {
        story = new Queue<string>();
    }

    public void SmallDialogue(SmallDialogueSystem dialog)
    {
        story.Clear();
        Name.SetText(dialog.Name);
        foreach (string s in dialog.dialogcontens)
        {
            story.Enqueue(s);
        }
        
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (story.Count == 0)
        {
            //EndDialogue();
            return;
        }

        string sentence = story.Dequeue();
        Debug.Log(sentence);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string str)
    {
        string s;
        didalogua.SetText("");
        foreach (char letter in str.ToCharArray())
	    {
            s = didalogua.text;
            s += letter;
            didalogua.SetText(s);
            
            yield return new WaitForSeconds(0.01f);
            
	    }
    }
    
}
