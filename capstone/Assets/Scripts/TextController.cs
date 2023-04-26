using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Transform target;
    public Text text;

    private void LateUpdate()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(target.position);
        text.transform.position = screenPosition;
    }

    // Call this method to set the text and font size
    public void SetText(string message, int fontSize)
    {
        text.text = message;
        text.fontSize = fontSize;
    }
}