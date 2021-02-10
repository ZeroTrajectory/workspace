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

    private Action<MainForm.Status> m_callback;
    private List<PianoKeyItem> m_whiteList = new List<PianoKeyItem>();
    private List<PianoKeyItem> m_blackList = new List<PianoKeyItem>();
    public void Init(Action<MainForm.Status> callback)
    {
        m_callback = callback;
        InitPiano(m_whiteList,m_traWhiteRoot,m_whiteKeyTemp,"white");
        InitPiano(m_blackList,m_traBlackRoot,m_blackKeyTemp,"black");
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
            itemList[i].SetData(configList[i]);
            itemList[i].gameObject.SetActive(true);
        }
    }

    public void Clear()
    {
        
    }
}
