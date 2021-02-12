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
        //适配
        var widthRate = Screen.width / (float)1024;
        var heightRate = Screen.height / (float)720;
        var scale = widthRate > heightRate ? heightRate : widthRate;
        transform.localScale = new Vector3(scale,scale,scale);
        //配置初始化
        ConfigMgr.GetInstance().InitConfig();
        m_questionPanel.Init(OnStatusOver);
        m_pianoPanel.Init(OnStatusOver);
        m_resultPanel.Init(OnStatusOver);
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
        m_questionPanel.gameObject.SetActive(true);
        m_pianoPanel.gameObject.SetActive(false);
        m_resultPanel.gameObject.SetActive(false);
    }

    private void ShowPiano()
    {
        m_questionPanel.gameObject.SetActive(true);
        m_pianoPanel.gameObject.SetActive(true);
        m_resultPanel.gameObject.SetActive(false);
        m_pianoPanel.ShowNoteList();
    }

    private void ShowResult()
    {
        m_questionPanel.gameObject.SetActive(true);
        m_pianoPanel.gameObject.SetActive(true);
        m_resultPanel.gameObject.SetActive(true);
        m_resultPanel.ShowEndComponent();
    }

    private void OnStatusOver(Status status)
    {
        SwitchStatus(status);
    }
}
