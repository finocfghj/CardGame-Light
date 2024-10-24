using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PracticeUI : UIBase
{
    public TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    public void ChangeTxt(string s)
    {
        text.text = s;
    }
}
