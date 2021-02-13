using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class AnswerItem : MonoBehaviour
{
    [SerializeField]
    private Button m_btnSelect;
    [SerializeField]
    private Text m_txtSelect;
    
    private int m_index = 0;
    private bool m_isTrue = false;
    private Action<bool> m_callback = null;
    private bool m_isClear = false;
    private void Start() 
    {
        m_btnSelect.onClick.AddListener(OnClick);
    }
    public void SetData(int index, string select,bool isTrue,Action<bool> callback)
    {
        m_isClear = false;
        m_index = index;
        m_txtSelect.text = string.Format("{0}.{1}",SwitchIndexToABCD(),select);
        m_isTrue = isTrue;
        m_callback = callback;
        transform.localPosition = new Vector3(-160 + (index % 2) * 320,50 - (index / 2) * 80 ,0);
    }

    private void OnClick()
    {
        if(m_isClear) return;
        if(m_isTrue)
        {            
            OnClickTrue();
        }
        else
        {
            OnClickFalse();
        }
        m_callback?.Invoke(m_isTrue);
    }

    private void OnClickTrue()
    {
        
    }

    private void OnClickFalse()
    {
        // Debug.Log("anwser error");
        var pos = transform.localPosition;
        transform.DOMove(new Vector3(pos.x,pos.y-100,pos.z),0.5f);
    }

    private string SwitchIndexToABCD()
    {
        string str = string.Empty;
        switch(m_index)
        {
            case 0:
                str = "A";
                break;
            case 1:
                str = "B";
                break;
            case 2:
                str = "C";
                break;
            case 3:
                str = "D";
                break;
            default:
                str = "E";
                break;
        }
        return str;
    }

    public void SetClear()
    {
        m_isClear = true;
    }
}
