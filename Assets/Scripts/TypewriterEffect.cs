using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField][Tooltip("Chars per second")] private float typewriterSpeed;
    private Coroutine typewriterCoroutin;


    public void WriteText(string textToWrite, TMP_Text textDisplay)
    {
        typewriterCoroutin=StartCoroutine(TypeText(textToWrite, textDisplay));
        //StopCoroutine(typewriterCoroutin);
    }
    private IEnumerator TypeText(string textToWrite, TMP_Text textDisplay)
    {
        float timebetchar = 1f / typewriterSpeed;

        foreach (char c in textToWrite)
        {
            textDisplay.text += c;
            yield return new WaitForSeconds(timebetchar);
        }
        
        //textDisplay.text = textToWrite;
    }
}
