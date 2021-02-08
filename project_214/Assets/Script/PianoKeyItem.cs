using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PianoKeyItem : MonoBehaviour
{
    [SerializeField]
    private Button m_btnKey;

    private PianoConfig m_config;

    private void Start()
    {
        m_btnKey.onClick.AddListener(OnPlaySound);
    }

    public void SetData(PianoConfig config)
    {
        m_config = config;
        FixPosition();
    }

    private void FixPosition()
    {
        if(m_config.type == "white")
        {
            transform.localPosition = new Vector3(90 * m_config.index,0,0);
        }
        else
        {
            transform.localPosition = new Vector3(90 + 90 * m_config.index,0,0);
        }
    }

    private void OnPlaySound()
    {

    }
}
