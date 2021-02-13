using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;
public class QuestionPanel : MonoBehaviour
{
    [SerializeField]
    private Transform m_traAnswerRoot;
    [SerializeField]
    private AnswerItem m_answerTemp;
    [SerializeField]
    private Text m_txtDesc;

    private int m_maxQuestCount = 0;
    private int m_curQuestIndex = 0;
    private List<AnswerItem> m_answerList = new List<AnswerItem>();
    private Action<MainForm.Status> m_callback;

    public void Init(Action<MainForm.Status> callback)
    {
        m_callback = callback;
        m_maxQuestCount = ConfigMgr.GetInstance().GetQuestionCount();
        m_curQuestIndex = 0;
        RefreshQuestion();
    }

    private void NextQuestion()
    {
        if(m_curQuestIndex + 1 == m_maxQuestCount)
        {
            AllQuestionComplete();
        }
        else
        {
            m_curQuestIndex++;
            RefreshQuestion();
        }
    }

    private void AllQuestionComplete()
    {
        m_callback?.Invoke(MainForm.Status.Piano);
    }

    private void RefreshQuestion()
    {
        m_traAnswerRoot.GetComponent<CanvasGroup>().alpha = 0;
        m_traAnswerRoot.GetComponent<CanvasGroup>().DOFade(1,2f);
        var config = ConfigMgr.GetInstance().GetQuestionConfig(m_curQuestIndex);
        for(int i = 0; i < m_answerList.Count; i++)
        {
            m_answerList[i].gameObject.SetActive(false);
        }
        for(int i = 0; i < config.answer.Length; i++)
        {
            if(i >= m_answerList.Count)
            {
                var item = GameObject.Instantiate(m_answerTemp.gameObject,m_traAnswerRoot);
                item.transform.localScale = Vector3.one;
                var anwser = item.GetComponent<AnswerItem>();
                m_answerList.Add(anwser);
            }
            bool isTrue = config.answer[i] == config.trueAnswer;
            m_answerList[i].SetData(i,config.answer[i],isTrue,(o) => OnClickAnswer(o));
            m_answerList[i].gameObject.SetActive(true);
        }
        m_txtDesc.text = string.Format(config.question,"__");
    }

    private void OnClickAnswer(bool isTrue)
    {
        if(isTrue)
        {
            for(int i = 0; i < m_answerList.Count; i++)
            {
                m_answerList[i].SetClear();
            }
            var config = ConfigMgr.GetInstance().GetQuestionConfig(m_curQuestIndex);
            m_txtDesc.text = string.Format(config.question,config.trueAnswer);
            m_traAnswerRoot.GetComponent<CanvasGroup>().DOFade(0,2f);
            DOVirtual.DelayedCall(2f,() =>
            {
                NextQuestion();
            });         
        }
    }

    public void Clear()
    {

    }

    
}
