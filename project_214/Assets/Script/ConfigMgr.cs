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
        ParseQuestionConfig();
        ParsePianoConfig();
    }

    private List<QuestionConfig> m_questionList;
    private List<PianoConfig> m_pianoList;

    private void ParseQuestionConfig()
    {
        if(m_questionList == null)
        {
            m_questionList = new List<QuestionConfig>();
        }
        m_questionList.Clear();
        var configText = Resources.Load("Config/Question") as TextAsset;
        var stringReader = new StringReader(configText.text);
        string line = string.Empty;
        while(true)
        {
            line = stringReader.ReadLine();
            if(line == null) break;
            var strSplit = line.Split(',');
            var config = new QuestionConfig();
            config.id = Convert.ToInt32(strSplit[0]);
            config.question = strSplit[1];
            config.answer = strSplit[2].Split('|');
            config.trueAnswer = strSplit[3];
            config.note = strSplit[4];
            m_questionList.Add(config);
        }
    }

    private void ParsePianoConfig()
    {
        if(m_pianoList == null)
        {
            m_pianoList = new List<PianoConfig>();
        }
        m_pianoList.Clear();
        var configText = Resources.Load("Config/Piano") as TextAsset;
        var stringReader = new StringReader(configText.text);
        string line = string.Empty;
        while(true)
        {
            line = stringReader.ReadLine();
            if(line == null) break;
            var strSplit = line.Split(',');
            var config = new PianoConfig();
            config.index = Convert.ToInt32(strSplit[0]);
            config.type = strSplit[1];
            config.note = strSplit[2];
            m_pianoList.Add(config);
        }
    }

    public int GetQuestionCount()
    {
        if(m_questionList == null)
        {
            Debug.LogError("question config not init!");
            return 0;
        }
        return m_questionList.Count;
    }

    public QuestionConfig GetQuestionConfig(int index)
    {
        if(m_questionList == null)
        {
            Debug.LogError("question config not init!");
            return null;
        }
        return m_questionList[index];
    }

    public List<PianoConfig> GetPianoConfigList(string type)
    {
        if(m_pianoList == null)
        {
            Debug.LogError("piano config not init!");
            return null;
        }
        var list = new List<PianoConfig>();
        foreach(var config in m_pianoList)
        {
            if(config.type == type)
            {
                list.Add(config);
            }
        }
        return list;
    }
}
