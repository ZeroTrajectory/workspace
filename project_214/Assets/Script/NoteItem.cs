using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NoteItem : MonoBehaviour
{
    [SerializeField]
    private Text m_txtNote;

    public void SetData(int index, string note)
    {
        m_txtNote.text = note;
        transform.localPosition = new Vector3(-350 + index * 50,0,0);
        SetPass(false);
    }

    public void SetPass(bool isPass)
    {
        if(isPass)
        {
            m_txtNote.color = new Color(255,0,0);
        }
        else
        {
            m_txtNote.color = new Color(255,255,255);
        }
    }
}
