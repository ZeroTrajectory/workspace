using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnswerItem : MonoBehaviour
{
    [SerializeField]
    private Button m_btnSelect;
    [SerializeField]
    private Text m_txtSelect;
    
    private bool m_isTrue = false;
    private void Start() 
    {
        m_btnSelect.onClick.AddListener(OnClick);
    }
    public void SetData(string select,bool isTrue)
    {
        m_txtSelect.text = select;
        m_isTrue = isTrue;
    }

    private void OnClick()
    {
        if(m_isTrue)
        {
            OnClickTrue();
        }
        else
        {
            OnClickFalse();
        }
    }

    private void OnClickTrue()
    {

    }

    private void OnClickFalse()
    {

    }
}
