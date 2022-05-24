using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDialogNPC : MonoBehaviour
{
    #region Pole
    [SerializeField] private bool _questStarted;
    [SerializeField] private GameObject _buttonYesGameObject;
    [SerializeField] private GameObject _buttonNoGameObject;
    [SerializeField] private Button _buttonYes;
    [SerializeField] private Button _buttonNo;
    [SerializeField] private ButtonYes _yes;
    [SerializeField] private ButtonNo _no;
    [SerializeField] private Text _text;
    private bool _complete;
    public bool _questComplete;
    [SerializeField] private QuestTrigger _questTrigger;

    private IEnumerator _corourine = new WaitForSecondsRealtime(1);
    #endregion

    private string[] _questText = new string[] 
    {
        "ѕривет путник у мен€ проблема, не поможешь мне ?",
        "я тут немного превысил скорость и превернулс€!   “ы сможешь еЄ перевернуть?",
        "—лабак иди качайс€!",
        "Ќу и ладно сам справлюсь!",
        "—пасибо тебе!",
        "",
        " вест ¬ыполнен!"
    };
    private void Update()
    {
        if (_questStarted)
        {
            if (_yes.ClickYes == true)
            {
                Quest(1, true, 0, true);
                _complete = true;
                _yes.ClickYes = false;
                _questStarted = false;
            }
            if (_no.ClickNo == true)
            {
                Quest(3, false, 1, false);
                _no.ClickNo = false;
            }
        }
        if (_complete)
        {
            if (_yes.ClickYes == true)
            {
                Quest(4, false, 1, false);
                _questComplete = true;
                _yes.ClickYes = false;
            }
            if (_no.ClickNo == true)
            {
                Quest(2, false, 1, false);
                _no.ClickNo = false;
            }
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player" && _questComplete == false)
        {
            Quest(0, true, 0, true);
        }
        if(_questTrigger._questCongratulation == true)
        {
            Quest(6, false, 1, false);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
            Quest(5, false, 1, false);
    }
    private void ButtonVisible(bool visible)
    {
        _buttonYesGameObject.SetActive(visible);
        _buttonNoGameObject.SetActive(visible);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="text номер текста в массиве"></param>
    /// <param name="questStart запуск/остановка квеста"></param>
    /// <param name="timeStart запуск времени 1-запущенно 0-остановленно"></param>
    /// <param name="buttonVisible видимость кнопок"></param>
    private void Quest(int text, bool questStart, int timeStart,bool buttonVisible)
    {
        _text.text = _questText[text];
        _questStarted = questStart;
        Time.timeScale = timeStart;
        ButtonVisible(buttonVisible);
    }
}
