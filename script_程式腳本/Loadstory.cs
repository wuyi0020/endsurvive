using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;
using System;

public class Loadstory : MonoBehaviour
{
    [Rename("對話框")]
    public TextMeshProUGUI didalogua;
    [Rename("名字框")]
    public TextMeshProUGUI Name;

    public List<GameObject> Buttonlist;
    public GameObject ButCanvas;
    public StoryData storyData;


    int button_order=1;
    int i;
    string _LoadFilleName;
    string[] talkbutvar = {""};

    //Queue 是儲列 這種變數型態遵循先進先出原則 此處應用為 一行行讀取劇本 並在後面解析出來 
    private Queue<string> storyload;

    void Start()
    {
        
        storyload = new Queue<string>();
    }

    public void loadstory(string LoadFileName)
    {
        _LoadFilleName = LoadFileName;
        //"/story/" 
        string[] storydata = File.ReadAllLines(Application.dataPath +"/"+  LoadFileName + ".txt");
        Debug.Log("讀取劇本:" + Application.dataPath + "/story/" + LoadFileName + ".txt");
        storyload.Clear();
        i = 0;
        button_order = 1;
        foreach (string s in storydata)
        {
            storyload.Enqueue(s);
            Debug.Log(s);

        }
        loadnext();
    }

    //讀取下一段
    public void loadnext()
    {
        if (storyload.Count == 0)
        {
            //EndDialogue();
            return;
        }
        i++;
        //將storyload 這個Queue變數儲存的資料 拿出一個並刪除 由於先進先出的特性 只要是順序閱讀的劇本就能順序解析。
        string s = storyload.Dequeue();
        //解析讀取出來的資料，以英文逗號分割。
        string[] talk = s.Split(',');

        //用來做最後分割後的最後段 重新解析的一維數列變數
        //int t = 0;
        try
        {
            //如果讀到 "//" 省略這一行
            if (talk[0].Substring(0,2)=="//") { Debug.Log($"省略{i}行"); loadnext(); return; }


            //如果讀到 "button" 才執行以下動作
            if (talk[0].Contains("button"))
            {

                //讀取按鈕名稱
                string[] talkbut = talk[1].Split("|");
                Debug.Log(talk.Length);
                //讀取按下按鈕後改變的變數名稱
                if (talk.Length >=3)
                {
                     
                     talkbutvar = talk[2].Split("|");
                }
                Debug.Log(talkbutvar.Length);
                //確認按鈕數量，此處變數為易讀性所做的效能犧牲
                int talkbutL = talkbut.Length;
                Debug.Log("Loadstory : 有幾個按鈕被呼叫 : " + talkbut.Length + " 個");

               
                //呼叫按鈕顯示函數
                if (talkbutL == 1)
                {
                    //Debug.Log(talkbut[t]);
                    but(talkbut[0]);
                    return;
                }
                else if (talkbutL == 2)
                {
                    //Debug.Log(talkbut[t] + talkbut[t+1]);
                    but(talkbut[0], talkbut[1]);
                    return;
                }
                else if (talkbutL == 3)
                {
                    //Debug.Log(talkbut[0] + talkbut[1] + talkbut[2]);
                    but(talkbut[0], talkbut[1], talkbut[2]);
                    return;
                }
                else if (talkbutL == 4)
                {
                    //Debug.Log(talkbut[0] + talkbut[1] + talkbut[2] + talkbut[3]);
                    but(talkbut[0], talkbut[1], talkbut[2], talkbut[3]);
                    return;
                }

            }

            if (talk[0] == "if") { return; }
            
            //如果解析的第一個字為 "stop" 那就跳過並將對話框收下去。
            if (talk[0] == "stop") { /*EndDialogue();*/ return; }

            //諾為正常劇本，最後會送來這裡。
            //顯示名字
            Name.SetText(talk[1]);
            //顯示文字
            didalogua.SetText(talk[0]);
            Debug.Log("Loadstory : NAME:" + talk[1] + "\n 說了" + talk[0]);
        }
        catch (IOException e) 
        { 
            Debug.Log($"第{i}行內容:" + s + $"\n格式錯誤\n正確格式為[對話,對話者]諾要換行請用\\n"+$"\n{e.Source}");
            
            loadnext();
            throw;
        }
        
    }

    /// <summary>
    /// //顯示一個按鈕
    /// </summary>
    /// <param name="s1"></param>
    void but(string s1)
    {
        

        ButCanvas.SetActive(true);
        List<string> slist = new List<string> { s1 };
        for (int i = 0; i < 1; i++)
        {
            Buttonlist[i].SetActive(true);
            Buttonlist[i].GetComponentInChildren<TextMeshProUGUI>().SetText(slist[i]);
            RectTransform butobj = Buttonlist[i].GetComponent<RectTransform>();
            Debug.Log("x" + butobj.localPosition.x + "y" + butobj.localPosition.y + "z" + butobj.localPosition.z);
        }
        Debug.Log(s1);
        Debug.Log("顯示一個按鈕");

    }
    /// <summary>
    /// 顯示兩個按鈕
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    void but(string s1, string s2)
    {
        //顯示兩個按鈕
        ButCanvas.SetActive(true);
        List<string> slist = new List<string> { s1, s2 };
        for (int i = 0; i < 2; i++)
        {
            Buttonlist[i].SetActive(true);
            Buttonlist[i].GetComponentInChildren<TextMeshProUGUI>().SetText(slist[i]);
            RectTransform butobj = Buttonlist[i].GetComponent<RectTransform>();
            Debug.Log("x" + butobj.localPosition.x + "y" + butobj.localPosition.y + "z" + butobj.localPosition.z);
        }
        Debug.Log(s1 + s2);
        Debug.Log("顯示兩個按鈕");

    }
    /// <summary>
    /// 顯示三個按鈕
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <param name="s3"></param>
    void but(string s1, string s2, string s3)
    {
        //顯示三個按鈕
        ButCanvas.SetActive(true);
        List<string> slist = new List<string> { s1, s2, s3 };
        for (int i = 0; i < 3; i++)
        {
            Buttonlist[i].SetActive(true);
            Buttonlist[i].GetComponentInChildren<TextMeshProUGUI>().SetText(slist[i]);
            RectTransform butobj = Buttonlist[i].GetComponent<RectTransform>();
            Debug.Log("x" + butobj.localPosition.x + "y" + butobj.localPosition.y + "z" + butobj.localPosition.z);
        }
        Debug.Log(s1 + s2 + s3);
        Debug.Log("顯示三個按鈕");
    }
    /// <summary>
    /// 顯示四個按鈕
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <param name="s3"></param>
    /// <param name="s4"></param>
    void but(string s1, string s2, string s3, string s4)
    {
        //顯示四個按鈕
        ButCanvas.SetActive(true);
        List<string> slist = new List<string> { s1, s2, s3, s4 };
        for (int i = 0; i < 4; i++)
        {
            Buttonlist[i].SetActive(true);
            Buttonlist[i].GetComponentInChildren<TextMeshProUGUI>().SetText(slist[i]);
            RectTransform butobj = Buttonlist[i].GetComponent<RectTransform>();
            Debug.Log(slist[i] + ":x" + butobj.localPosition.x + "|y" + butobj.localPosition.y + "|z" + butobj.localPosition.z);
        }
        Debug.Log("顯示四個按鈕");
    }

    /// <summary>
    /// 關閉所有按鈕
    /// </summary>
    public void butfalse()
    {
        //關閉4個按鈕
        foreach (var item in Buttonlist)
        {
            item.SetActive(false);
        }
    }
    
    //與按鈕綁定，按鈕1被按下時觸發這個
    public void but1()
    {
        var savename = Buttonlist[0].GetComponentInChildren<TextMeshProUGUI>().text;
        if (talkbutvar.Length > 0)
        {
            string s = talkbutvar[0];
            storyData.lists.Add( $"{_LoadFilleName}_{button_order}, {savename} " );
            Array.Clear(talkbutvar, 0, talkbutvar.Length);
        }
        button_order += 1;
        Debug.Log("劇本:"+_LoadFilleName+"按了" + savename);
    }
    //與按鈕綁定，按鈕2被按下時觸發這個
    public void but2()
    {
        var savename = Buttonlist[1].GetComponentInChildren<TextMeshProUGUI>().text;
        if (talkbutvar.Length > 0)
        {
            string s = talkbutvar[1];
            storyData.lists.Add($"{_LoadFilleName}_{button_order}, {savename} ");
            Array.Clear(talkbutvar, 0, talkbutvar.Length);
        }
        button_order += 1;
        Debug.Log("劇本:" + _LoadFilleName + "按了"+savename );
        
    }
    //與按鈕綁定，按鈕3被按下時觸發這個
    public void but3()
    {
        var savename = Buttonlist[2].GetComponentInChildren<TextMeshProUGUI>().text;
        if (talkbutvar.Length > 0)
        {
            string s = talkbutvar[2];
            storyData.lists.Add($"{_LoadFilleName}_{button_order}, {savename} ");
            Array.Clear(talkbutvar, 0, talkbutvar.Length);
        }
        button_order += 1;
        Debug.Log("劇本:" + _LoadFilleName + "按了" + savename);
    }
    //與按鈕綁定，按鈕4被按下時觸發這個
    public void but4()
    {
        var savename = Buttonlist[3].GetComponentInChildren<TextMeshProUGUI>().text;
        if (talkbutvar.Length > 0)
        {
            string s = talkbutvar[3];
            storyData.lists.Add($"{_LoadFilleName}_{button_order}, {savename} ");
            Array.Clear(talkbutvar, 0, talkbutvar.Length);
        }
        button_order += 1;
        Debug.Log("劇本:" + _LoadFilleName + "按了" + savename);
    }
}
