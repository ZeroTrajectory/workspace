using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionForm : MonoBehaviour
{
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        //配置初始化
        ConfigMgr.GetInstance().InitConfig();
    }

    
}
