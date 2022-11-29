using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public SmallDialogueSystem story;

    public void say()
    {
        FindObjectOfType<textcontrle>().SmallDialogue(story);
    }
}
