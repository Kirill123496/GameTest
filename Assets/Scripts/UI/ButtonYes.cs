using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonYes : MonoBehaviour
{
    public bool _clickYes;
    public bool ClickYes
    {
        get { return _clickYes; }
        set { _clickYes = value; }
    }

    public void OnMouseDown()
    {
        _clickYes = true;
    }
    public void OnMouseUp()
    {
        _clickYes = false;
    }
}
