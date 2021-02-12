using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
    private Text m_txtAllAnswer;
    [SerializeField]
    private Transform m_traNoteRoot;
    [SerializeField]
    private Transform m_traNoteLineRoot;
    [SerializeField]
    private Transform m_traKeyboard;
    [SerializeField]
    private List<NoteItem> m_noteItemList;

    private Action<MainForm.Status> m_callback;
    private List<PianoKeyItem> m_whiteList = new List<PianoKeyItem>();
    private List<PianoKeyItem> m_blackList = new List<PianoKeyItem>();
    private int m_curIndex = 0;
    // private List<string> m_noteList = null;
    public void Init(Action<MainForm.Status> callback)
    {
        m_callback = callback;
        InitPiano(m_whiteList,m_traWhiteRoot,m_whiteKeyTemp,"white");
        InitPiano(m_blackList,m_traBlackRoot,m_blackKeyTemp,"black");
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

    public void ShowNoteList()
    {
       if(m_noteItemList == null)
       {
           return;
       }
       AudioManager.GetInstance().DispearMusic();
       var noteList = ConfigMgr.GetInstance().GetNoteList();
       m_txtAllAnswer.GetComponent<CanvasGroup>().alpha = 0;
       m_traNoteRoot.GetComponent<CanvasGroup>().alpha = 0;
       m_traNoteLineRoot.GetComponent<CanvasGroup>().alpha = 0;
       m_txtAllAnswer.GetComponent<CanvasGroup>().DOFade(1,3f);       
       DOVirtual.DelayedCall(3f,() =>
       {
           m_traNoteRoot.GetComponent<CanvasGroup>().DOFade(1,2f);
       });
       DOVirtual.DelayedCall(6f,() =>
       {
            for(int i = 0; i < m_noteItemList.Count; i++)
            {
                m_noteItemList[i].SetData(noteList[i]);
                m_noteItemList[i].transform.DOLocalMove(new Vector3(-150 + i * 25,0,0),2f);
            }
       });
       DOVirtual.DelayedCall(8f,() =>
       {
           m_traNoteLineRoot.GetComponent<CanvasGroup>().DOFade(1,2f);
       });
       DOVirtual.DelayedCall(7f,() =>
       {
           m_traKeyboard.transform.DOLocalMove(new Vector3(0,-180,0),3f);
       });

    }

    private void OnClickPianoKey(string note)
    {
        if(m_noteItemList == null)
        {
            Debug.LogError("note list not init!");
            return;
        }
        if(m_curIndex >= m_noteItemList.Count)
        {
            // AllKeyComplete();
        }
        else
        {
            if(m_noteItemList[m_curIndex].GetNote() == note)
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
        if(m_curIndex >= m_noteItemList.Count)
        {
            AllKeyComplete();
        }
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
        AudioManager.GetInstance().PlayMusic("lemon",false);
        m_traKeyboard.transform.DOLocalMove(new Vector3(0,-720,0),3f);
        DOVirtual.DelayedCall(7f,() =>
        {
            AudioManager.GetInstance().PlayMusic("lemonfull",false);           
        });
    }

    public void Clear()
    {
        
    }
}
