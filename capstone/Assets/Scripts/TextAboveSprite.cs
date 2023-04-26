using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAboveSprite : MonoBehaviour
{
    public Transform target;
    public string displayText;
    public float fontSize = 12f;
    public float offset = 1.5f;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        if (text != null)
        {
            text.text = displayText;
            text.fontSize = (int)fontSize;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y + offset, target.position.z);
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetPosition);
            transform.position = screenPosition;
        }
    }
}