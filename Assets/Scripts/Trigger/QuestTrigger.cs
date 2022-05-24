using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestTrigger : MonoBehaviour
{
    public bool _questCongratulation;
    [SerializeField] private QuestDialogNPC _questNPC;
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Прикосновение");
        if(collider.gameObject.tag == "Ground" && _questNPC._questComplete == true)
        {
            _questCongratulation = true;
        }
    }
}
