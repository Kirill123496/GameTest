using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookTriger : MonoBehaviour
{
    [SerializeField] private Text _textUI;

    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player")
        {
            _textUI.text = "Книга о приключениях!";
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        _textUI.text = null;
    }
}
