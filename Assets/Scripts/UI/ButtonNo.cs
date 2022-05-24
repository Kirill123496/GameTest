using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNo : MonoBehaviour
{
    public bool _clickNo;
    public bool ClickNo
    {
        get { return _clickNo; }
        set { _clickNo = value; }
    }
    public void OnMouseDown()
    {
        _clickNo = true;
    }
    public void OnMouseUp()
    {
        _clickNo = false;
    }
}
