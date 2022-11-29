using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;


public class TimeManager : MonoBehaviour
{
    public static TimeManager insteance;
    public TimeData data;
    float timer = 0;
    int y,d,h,s,m,min;
    int monthday;
    float speed = 0.3f;
    int speedbackup;
    bool bigyear =true;
    public TextMeshProUGUI timer_day , timer_s,timer_w;
    public UnityEvent hi ;
    bool pause = false;

    private void Update()
    {
        //Time.deltaTime 每次呼叫所使用的時間間隔(秒)
        //timer 累加時間，當累加超過1(秒)倒數1秒。
        //Data.timer 倒數 data.speed 秒
        timer += Time.deltaTime;
        if (timer >= speed)
        {
            timer = 0;
            data.count_down();
            
            second();
            
            datatime();
            
        }
    }

    void Awake()
    {
        //如果有其他靜態物件 銷毀該物件並重新註冊
        if (insteance != null)
        {
            Destroy(this);
        }
        else { insteance = this; }

        pause = false;
    }

    public void speedup()
    {
        speed -= 0.3f;
        if (speed < 0.05)
        {
            speed = 0.05f;
            data.speed += 31;
            if (data.speed > 61)
            {
                data.speed = 61;
            }
        }
    }
    public void spdown()
    {
        data.speed -= 32;
        if (data.speed < 1)
        {
            data.speed = 1;
            speed +=0.3f;
            if (speed > 0.3)
            {

                speed = 0.3f;

            }
        }
        
    }
    public void Timestop()
    {
        speedbackup = data.speed;
        data.speed = 0;
    }
    public void TimeResume()
    {
        data.speed = speedbackup;
    }

    public void pausebut()
    {
        pause = !pause;
        if (pause)
        {
            Timestop();
            return;
        }
        if (!pause)
        {
            TimeResume();
            return;
        }

    }


    private void Start()
    {
        datatime();
    }

    //呼叫取得時間，並格式化顯示時間。
    void datatime() 
    {
        year();
        month();
        day();
        second();
        minute();
        hours();

        int seanson = data.seanson;
        string str_se = seanson == 1 ? "春" : seanson == 2 ? "夏" : seanson == 3 ? "秋" : seanson == 4 ? "冬" : "";
        //0晴天 1陰天 2雨天 3雷雨天 4降雪 5大雪
        int w = data.weater;
        string str_w = w == 0 ? "晴天" : w == 1 ? "陰天" : w == 2 ? "雨天" : w == 3 ? "雷雨天" : w == 4 ? "降雪" : w == 5 ? "大雪" : "";
        timer_day.SetText($"{y:0000}年 {m:00}月 {d:00}日");
        timer_s.SetText($"{h:00}時 {min:00}分 {s:00}秒");
        timer_w.SetText($"天氣：{str_w} 季節：{str_se}");

    }

    // 秒 86400秒為一天
    void second() 
    {
        //如果歸零表示一天過完，天數增加1(day(Int)函數多型)，並且重置倒數。
        if (data.second <= 0) {
            day(1);
            data.second = 86400;
        };
        // 這天內經過的時間，每60秒進位一次(除以60)，取餘數顯示進位後剩餘多少秒(這分鐘經過多少秒)。
        s = ((86400 - data.second) % 60)/1;

    }


    void day() 
    {
        if ( m == 1 | m == 3 | m == 5 | m == 7 | m == 8 | m == 10 | m == 12) { monthday = 31; }
        if ( m == 4 | m == 6 | m == 9 | m == 11) { monthday = 30; }
        if ( m == 2 ) { if (bigyear) { monthday = 29; } else { monthday = 28; } }
        if (data.days > monthday) { data.days -= monthday;  month(1);  } 

        d = data.days;
    }
    void day(int a) 
    {
        data.days += a;
        day();
    }


    void month()
    {
        
        if (data.month > 12) {data.month = 1; year(1); }
        m = data.month;
    }
    void month(int a)
    {
        data.month += a;
        month();
    }


    void year()
    {
        y = data.year;
    }
    void year(int a)
    {
        data.year += a;
        year();
    }


    void hours()
    {
        h = ((86400 - data.second) / 3600)/1;
    }
    void minute()
    {
        min = ((86400 - data.second)/ 60 % 60)/1;
    }
    

}
