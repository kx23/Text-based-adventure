using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TBA
{
    public class GameController : MonoBehaviour
    {
        public TextBoxController dialogBoxController;
        [HideInInspector] public LocationNavigation locationNavigation;

        [HideInInspector] public List<TextBlock> interactionDescriptionsInLocation = new List<TextBlock>();
         public List<TextBlock> blocsList = new List<TextBlock>();

        private List<string> actionLog = new List<string>();
        private void Awake()
        {
            locationNavigation = GetComponent<LocationNavigation>();
        }
        private void Start()
        {
            DisplayLocationText();
            DisplayLoggedText();
        }
        public void DisplayLocationText()
        {
            blocsList.Add(locationNavigation.currentLocation.description);
            UnpackLocation();

        }



        public void DisplayLoggedText()
        {
            foreach (TextBlock tb in blocsList)
            {
                dialogBoxController.AddToQueue(tb);
            }
            
        }

        private void UnpackLocation()
        {
            locationNavigation.UnpackExitsInLocation();
        }


    }
}