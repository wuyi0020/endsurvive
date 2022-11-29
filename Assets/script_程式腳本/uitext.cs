using UnityEngine;
using TMPro;

public class uitext : MonoBehaviour
{
    public void eat(TextMeshProUGUI game){
        
        TextMeshProUGUI textMeshPro = game.GetComponent<TextMeshProUGUI>();
        textMeshPro.SetText("從倉庫裡翻出了一個罐頭，簡單地吃了，恢復了一點體力。");


    }

}
