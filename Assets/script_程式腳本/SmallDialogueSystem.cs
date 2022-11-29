using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SmallDialogueSystem 
{
    
    
    public string Name;
    public string ScenceName;
    public string StoryName;
    public int StoryNamber;

    [TextArea(3, 10)]
    public string[] dialogcontens;

}
