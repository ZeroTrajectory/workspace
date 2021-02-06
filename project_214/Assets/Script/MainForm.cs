using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainForm : MonoBehaviour
{
    [SerializeField]
    private QuestionPanel m_questionPanel;
    [SerializeField]
    private PianoPanel m_pianoPanel;
    [SerializeField]
    private ResultPanel m_resultPanel;

    public enum Status
    {
        Question,
        Piano,
        Result,
    }

    private void Start()
    {
        //配置初始化
        ConfigMgr.GetInstance().InitConfig();
        
        SwitchStatus(Status.Question);
    }

    private void SwitchStatus(Status status)
    {
        switch(status)
        {
            case Status.Question:
                ShowQuestion();
                break;
            case Status.Piano:
                ShowPiano();
                break;
            case Status.Result:
                ShowResult();
                break;
        }
    }

    private void ShowQuestion()
    {

    }

    private void ShowPiano()
    {

    }

    private void ShowResult()
    {

    }
}
