using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PianoPanel : MonoBehaviour
{   
    [SerializeField]
    private PianoKeyItem m_whiteKeyTemp;
    [SerializeField]
    private PianoKeyItem m_blackKeyTemp;
    [SerializeField]
    private Transform m_traWhiteRoot;
    [SerializeField]
    private Transform m_traBlackRoot;
    [SerializeField]
    private Transform m_traNoteRoot;
    [SerializeField]
    private NoteItem m_NoteItemTemp;

    private Action<MainForm.Status> m_callback;
    private List<PianoKeyItem> m_whiteList = new List<PianoKeyItem>();
    private List<PianoKeyItem> m_blackList = new List<PianoKeyItem>();
    private int m_curIndex = 0;
    private List<string> m_noteList = null;
    private List<NoteItem> m_noteItemList = new List<NoteItem>();
    public void Init(Action<MainForm.Status> callback)
    {
        m_callback = callback;
        InitPiano(m_whiteList,m_traWhiteRoot,m_whiteKeyTemp,"white");
        InitPiano(m_blackList,m_traBlackRoot,m_blackKeyTemp,"black");
        InitNoteList();
        m_curIndex = 0;
    }

    private void InitPiano(List<PianoKeyItem> itemList,Transform root,PianoKeyItem temp,string type)
    {
        for(int i = 0; i < itemList.Count; i++)
        {
            itemList[i].gameObject.SetActive(false);
        }
        var configList = ConfigMgr.GetInstance().GetPianoConfigList(type);
        for(int i = 0; i < configList.Count; i++)
        {
            if(i >= itemList.Count)
            {
                var obj = GameObject.Instantiate(temp.gameObject,root);
                obj.transform.localScale = Vector3.one;
                var item = obj.transform.GetComponent<PianoKeyItem>();
                itemList.Add(item);
            }
            itemList[i].SetData(configList[i],OnClickPianoKey);
            itemList[i].gameObject.SetActive(true);
        }
    }

    private void InitNoteList()
    {
        m_noteList = ConfigMgr.GetInstance().GetNoteList();
        for(int i = 0; i < m_noteItemList.Count; i++)
        {
            m_noteItemList[i].gameObject.SetActive(false);
        }
        var trueAnswerList = ConfigMgr.GetInstance().GetTrueAnswerList();
        for(int i = 0; i < trueAnswerList.Count; i++)
        {
            if(i >= m_noteItemList.Count)
            {
                var obj = GameObject.Instantiate(m_NoteItemTemp.gameObject,m_traNoteRoot);
                obj.transform.localScale = Vector3.one;
                var item = obj.transform.GetComponent<NoteItem>();
                m_noteItemList.Add(item);
            }
            m_noteItemList[i].SetData(i,trueAnswerList[i]);
            m_noteItemList[i].gameObject.SetActive(true);
        }
    }

    private void OnClickPianoKey(string note)
    {
        if(m_noteList == null)
        {
            Debug.LogError("note list not init!");
            return;
        }
        if(m_curIndex >= m_noteList.Count)
        {
            AllKeyComplete();
        }
        else
        {
            if(m_noteList[m_curIndex] == note)
            {
                ClickTrue();
            }
            else
            {
                ClickFalse();
            }
        }
    }

    private void ClickTrue()
    {
        m_noteItemList[m_curIndex].SetPass(true);
        m_curIndex++;
    }

    private void ClickFalse()
    {
        m_curIndex = 0;
        for(int i = 0; i < m_noteItemList.Count; i++)
        {
            m_noteItemList[i].SetPass(false);
        }
    }

    private void AllKeyComplete()
    {
        m_callback?.Invoke(MainForm.Status.Result);
    }

    public void Clear()
    {
        
    }
}
