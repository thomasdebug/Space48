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
        // Use the generic display function for the intro
        ShowTimedText(introductionField,
            "Welcome to Space 4 8.\nMove with arrows or WASD.\nShoot with SPACE.\nGather pickups with 'E'.",
            5f);
    }

    public void ShowMessage(string message)
    {
        // Reuse the same display function
        ShowTimedText(messageField, message, 3f);
    }

    /// <summary>
    /// Generic function to display any TMP_Text field for a given duration.
    /// </summary>
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
