using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Data.Common;

public class TypingEffect : MonoBehaviour
{
     [SerializeField] private float typeWriterSpeed = 40f;

    public Coroutine Run(string textToType, TMP_Text textLabel)
    {
       return StartCoroutine(TypeText(textToType, textLabel));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {   
        textLabel.text = string.Empty;
        float t = 0;
        int charIndex = 0;

        while(charIndex < textToType.Length)
        {   
            t += Time.deltaTime * typeWriterSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);
            
            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }

        textLabel.text = textToType;
    }
}
