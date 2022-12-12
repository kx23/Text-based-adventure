using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TBA
{
    public class TextBoxController : MonoBehaviour
    {
        private Queue<TextBlock> blocksQueue=new Queue<TextBlock>();
        public TMP_Text textDisplay;
        private TypewriterEffect _typewriterEffect;
        private bool _blockInProcess = false;
        private Coroutine _coroutine;
        //add queue for strings from block
        public TextBlock tempTestTB = new TextBlock();

        private void Start()
        {
            _typewriterEffect = GetComponent<TypewriterEffect>();
            blocksQueue.Enqueue(tempTestTB);
            ShowTextBlock(blocksQueue.Dequeue());
           
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_typewriterEffect.inProcess)
                {
                    _typewriterEffect.SkipTyping(textDisplay);
                }
                else if(!_blockInProcess && blocksQueue.Count != 0)
                {
                    ShowTextBlock(blocksQueue.Dequeue());
                }
            }
        }
        public void ShowTextBlock(TextBlock textBlock)
        {
            _blockInProcess = true;
            StartCoroutine(StepThroughTextBlock(textBlock));
            
        }
        private IEnumerator StepThroughTextBlock(TextBlock textBlock)
        {
            Debug.Log("start block");
            foreach (string block in textBlock.blocks)
            {
                Debug.Log(block);
                _typewriterEffect.WriteText("\n" + "\n" + block, textDisplay);
                yield return new WaitUntil(() => _typewriterEffect.inProcess);
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space)&&!_typewriterEffect.inProcess);
            }
            Debug.Log("end block");
            _blockInProcess = false;
        }
        private void ShowNextBlock()
        {
            _typewriterEffect.WriteText("\n" + blocksQueue.Dequeue(), textDisplay);
        }
        public void AddToQueue(TextBlock block)
        {
            //added
            Debug.Log("Added");
            blocksQueue.Enqueue(block);
        }
    }
}