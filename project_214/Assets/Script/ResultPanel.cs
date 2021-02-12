using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ResultPanel : MonoBehaviour
{
    [SerializeField]
    private List<CanvasGroup> m_canvasEndList;
    private Action<MainForm.Status> m_callback;
    public void Init(Action<MainForm.Status> callback)
    {
        m_callback = callback;
    }

    public void ShowEndComponent()
    {
        for(int i = 0; i < m_canvasEndList.Count; i++)
        {
            int index = i;
            DOVirtual.DelayedCall(7 + 7 * i, () =>
            {
                m_canvasEndList[index].DOFade(1f,3f);
            });           
        }
    }

    public void Clear()
    {

    }
}
