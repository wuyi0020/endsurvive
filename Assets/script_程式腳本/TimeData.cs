using UnityEngine;

[DisallowMultipleComponent]
[AddComponentMenu("時間數值")]
public class TimeData : MonoBehaviour
{
    [Header("玩家物件"), TooltipAttribute("請放入玩家物件")]
    public object player;

    [Header("時間")]
    [Range(0,86400),TooltipAttribute("遊戲時間(單位 每日總秒數 歸0換日)")]
    public int second = 86400;

    [Header("日"), TooltipAttribute("遊戲時間(單位 365日)")]
    public int days = 1;

    [Header("月"), TooltipAttribute("遊戲時間(月份)")]
    public int month = 1;

    [Header("年"), TooltipAttribute("遊戲時間(年份)")]
    public int year = 2020;

    [Header("季節"), TooltipAttribute("遊戲時間(季節) \n1為春\n2為夏\n3為秋\n4為冬")]
    [Range(1, 4)]
    public int seanson = 1;

    [Header("時間倍率"), TooltipAttribute("時間倍率(單位 現實每秒 遊戲時間經過幾秒)")]
    [Range(1, 60)]
    public int speed = 1;

    [Header("天氣"), TooltipAttribute("0為晴天\n1為陰天\n2為雨天\n3為雷雨天\n4為降雪")]
    [Range(0,4)]
    public int weater = 0;

    [SerializeField]
    int ts=0;
    
    public void count_down()
    {
        second -= speed;
    }
    /*
    public void speed_up() 
    {
        //1 30 60 600 1800 3600
        ts += 1;
        if (ts > 4) { ts = 4; }
        speed = ts == 0 ?  10 : ts == 1 ?  100 : ts == 2 ?  200 : ts == 3 ?  2000 : ts == 4 ? 6000 : 1 ;
        


        //speed += s;
        //if (speed >= 600) { speed = 1; }

    }
    public void speed_down()
    {
        ts -= 1;
        if (ts<0) { ts = 0; } 
        speed = ts == 0 ? 1 : ts == 1 ? 30 : ts == 2 ? 60 : ts == 3 ? 600 : ts == 4 ? 1800 : 1;
        //speed -= s;
        //if (speed <= 1) { speed = 1; }
    }
    */
}
