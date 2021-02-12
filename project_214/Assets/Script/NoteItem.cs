using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NoteItem : MonoBehaviour
{
    [SerializeField]
    private Text m_txtNote;

    private string m_note = string.Empty;

    public void SetData(string note)
    {
        m_note = note;
        // transform.localPosition = new Vector3(-350 + index * 50,0,0);
        SetPass(false);
    }

    public void SetPass(bool isPass)
    {
        if(isPass)
        {
            m_txtNote.color = new Color(0,255,0);
        }
        else
        {
            m_txtNote.color = new Color(255,0,0);
        }
    }

    public string GetNote()
    {
        return m_note;
    }
}
