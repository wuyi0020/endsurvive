using UnityEngine;

[DisallowMultipleComponent]
[AddComponentMenu("�ɶ��ƭ�")]
public class TimeData : MonoBehaviour
{
    [Header("���a����"), TooltipAttribute("�Щ�J���a����")]
    public object player;

    [Header("�ɶ�")]
    [Range(0,86400),TooltipAttribute("�C���ɶ�(��� �C���`��� �k0����)")]
    public int second = 86400;

    [Header("��"), TooltipAttribute("�C���ɶ�(��� 365��)")]
    public int days = 1;

    [Header("��"), TooltipAttribute("�C���ɶ�(���)")]
    public int month = 1;

    [Header("�~"), TooltipAttribute("�C���ɶ�(�~��)")]
    public int year = 2020;

    [Header("�u�`"), TooltipAttribute("�C���ɶ�(�u�`) \n1���K\n2���L\n3����\n4���V")]
    [Range(1, 4)]
    public int seanson = 1;

    [Header("�ɶ����v"), TooltipAttribute("�ɶ����v(��� �{��C�� �C���ɶ��g�L�X��)")]
    [Range(1, 60)]
    public int speed = 1;

    [Header("�Ѯ�"), TooltipAttribute("0������\n1������\n2���B��\n3���p�B��\n4������")]
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
