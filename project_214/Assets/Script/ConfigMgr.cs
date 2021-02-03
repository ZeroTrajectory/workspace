using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConfigMgr
{
    private static ConfigMgr m_instance = null;
    public static ConfigMgr GetInstance()
    {
        if(m_instance == null)
        {
            m_instance = new ConfigMgr();
        }
        return m_instance;
    }

    public void InitConfig()
    {
        PasreQuestionConfig();
    }

    private List<QuestionConfig> m_questionList;

    private void PasreQuestionConfig()
    {
        if(m_questionList == null)
        {
            m_questionList = new List<QuestionConfig>();
        }
        m_questionList.Clear();
        var configText = Resources.Load("Config/Question") as TextAsset;
        var streamReader = new StreamReader(configText.text);
        string line = string.Empty;
        while(true)
        {
            line = streamReader.ReadLine();
            if(line == null) break;
            var strSplit = line.Split(',');
            var config = new QuestionConfig();
            config.id = Convert.ToInt32(strSplit[0]);
            config.question = strSplit[1];
            config.answer = strSplit[2].Split('|');
            config.trueNum = Convert.ToInt32(strSplit[3]);
            m_questionList.Add(config);
        }
    }
}
