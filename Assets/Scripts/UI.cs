using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text introductionField;
    [SerializeField] private TMP_Text messageField;

    private void Start()
    {
        
        ShowTimedText(introductionField,
            "Welcome to Space 4 8.\nMove with arrows or WASD.\nShoot with SPACE.\nGather pickups with 'E'.",
            5f);
    }

    public void ShowMessage(string message)
    {
        ShowTimedText(messageField, message, 3f);
    }

   
    private void ShowTimedText(TMP_Text textField, string message, float duration)
    {
        StartCoroutine(DisplayTextCoroutine(textField, message, duration));
    }

    private IEnumerator DisplayTextCoroutine(TMP_Text textField, string message, float duration)
    {
        textField.enabled = true;
        textField.text = message;
        yield return new WaitForSeconds(duration);
        textField.enabled = false;
    }
}
