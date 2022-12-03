using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TBA
{
    public class DialogBoxController : MonoBehaviour
    {
        private Queue<string> blocksQueue=new Queue<string>();
        public TMP_Text textDisplay;
        TypewriterEffect a;

        private void Start()
        {
           a= GetComponent<TypewriterEffect>();
           
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)&&blocksQueue.Count!=0)
            {
                ShowNextBlock();
            }
        }
        private void ShowNextBlock()
        {
            a.WriteText("\n" + blocksQueue.Dequeue(), textDisplay);
        }
        public void AddToQueue(string block)
        {
            blocksQueue.Enqueue(block);
        }
    }
}