using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField][Tooltip("Chars per second")] private float typewriterSpeed;
    private Coroutine _coroutine;
    private int _alreadyTyped;
    private string _typingString;

    public bool inProcess { get; private set; } = false;


    public void WriteText(string textToWrite, TMP_Text textDisplay)
    {

        _coroutine = StartCoroutine(TypeText(textToWrite, textDisplay));
    }
    private IEnumerator TypeText(string textToWrite, TMP_Text textDisplay)
    {
        _alreadyTyped = 0;
        _typingString=textToWrite;
        inProcess = true;
        float timebetchar = 1f / typewriterSpeed;

        foreach (char c in textToWrite)
        {
            textDisplay.text += c;
            _alreadyTyped++;
            yield return new WaitForSeconds(timebetchar);
        }
        inProcess = false;

        
        //textDisplay.text = textToWrite;
    }

    public void SkipTyping(TMP_Text textDisplay)
    {
        StopCoroutine(_coroutine);
        textDisplay.text = textDisplay.text.Substring(0, textDisplay.text.Length - _alreadyTyped)+_typingString;
        inProcess = false;
    }
}
