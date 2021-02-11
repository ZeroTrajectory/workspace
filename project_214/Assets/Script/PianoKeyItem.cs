using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PianoKeyItem : MonoBehaviour
{
    [SerializeField]
    private Button m_btnKey;

    private PianoConfig m_config;
    private Action<string> m_callback;

    private void Start()
    {
        m_btnKey.onClick.AddListener(OnPlaySound);
    }

    public void SetData(PianoConfig config,Action<string> callback)
    {
        m_config = config;
        m_callback = callback;
        FixPosition();
    }

    private void FixPosition()
    {
        if(m_config.type == "white")
        {
            transform.localPosition = new Vector3(90 * m_config.index - 495,0,0);
        }
        else
        {
            transform.localPosition = new Vector3(45 + 90 * m_config.index - 495,0,0);
        }
    }

    private void OnPlaySound()
    {
        AudioManager.GetInstance().PlaySound(m_config.note);
        m_callback?.Invoke(m_config.note);
    }
}
