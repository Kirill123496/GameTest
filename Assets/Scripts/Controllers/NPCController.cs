using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] private QuestTrigger _questTrigger;
    [SerializeField] private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (_questTrigger._questCongratulation == true)
        {
            _animator.SetTrigger("Yes");
        }
    }
}
