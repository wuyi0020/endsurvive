using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using ExcelDataReader;
using System.Data;
using System;

public class Exceltest : MonoBehaviour
{
    public TalkList talkList=new TalkList();

    // Start is called before the first frame update
    void Start()
    {
        string ExcelPath = Path.Combine(Application.dataPath, "story", "test1.xlsx");
        string ExcelSheet = "a";
        var ExcelRowData = ReadExcel(ExcelPath, ExcelSheet);
        var ExcelcolumnData = ReadColumnExcel(ExcelPath, ExcelSheet);
        talkList.talks = ParseData(ExcelRowData);


    }
    //橫的讀取Excel
    DataRowCollection ReadExcel(string ExcelPath, string ExcelSheet)
    {
        using (FileStream fileStream = File.Open(ExcelPath, FileMode.Open, FileAccess.Read))
        {
            IExcelDataReader dataReader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
            var relsut = dataReader.AsDataSet();
            return relsut.Tables[ExcelSheet].Rows;
        }
    }
    //直的讀取Excel
    DataColumnCollection ReadColumnExcel(string ExcelPath, string ExcelSheet)
    {
        using (FileStream fileStream = File.Open(ExcelPath, FileMode.Open, FileAccess.Read))
        {
            IExcelDataReader dataReader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
            var relsut = dataReader.AsDataSet();
            return relsut.Tables[ExcelSheet].Columns;
        }
    }
    List<story> ParseData(DataRowCollection ExcelRowData)
    {
        List<story> s = new List<story>();
        string Name="";
        for (int i = 1; i < ExcelRowData.Count; i++)
        {
            story _story = new story();
            //檢查格式
            if (ExcelRowData[i][0].ToString() == "")
            {
                Name = ExcelRowData[i][1].ToString() == "" ? Name : ExcelRowData[i][1].ToString();
                _story.Name = Name;
                _story.Talk = ExcelRowData[i][2].ToString();
            }
            if (ExcelRowData[i][0].ToString() == "b"| ExcelRowData[i][0].ToString() == "B")
            {
                _story.Button1 = ExcelRowData[i][2].ToString();
                _story.Button2 = ExcelRowData[i][3].ToString();
                _story.Button3 = ExcelRowData[i][4].ToString();
                _story.Button4 = ExcelRowData[i][5].ToString();
            }
            
            s.Add(_story);


        }
        return s;
    }
    [Serializable]
    public class TalkList
    {
        public List<story> talks = new List<story>();
    }
    [Serializable]
    public class story
    {
        public string Mods;
        public string Name;
        public string Talk;
        public string Button1;
        public string Button2;
        public string Button3;
        public string Button4;
    }
    
}
