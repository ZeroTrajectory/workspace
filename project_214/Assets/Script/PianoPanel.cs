using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PianoPanel : MonoBehaviour
{   
    [SerializeField]
    // private Piano

    private Action<MainForm.Status> m_callback;
    private List<PianoKeyItem> m_whiteList = new List<PianoKeyItem>();
    private List<PianoKeyItem> m_blackList = new List<PianoKeyItem>();
    public void Init(Action<MainForm.Status> callback)
    {
        m_callback = callback;
    }

    private void InitPiano()
    {

    }
}
