using System.Collections;
using System.Collections.Generic;
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

    private Dictionary<int,QuestionConfig> m_questionDict;

    private bool PasreQuestionConfig()
    {
        return true;
    }
}
