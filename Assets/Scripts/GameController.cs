using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TBA
{
    public class GameController : MonoBehaviour
    {
        public DialogBoxController dialogBoxController;
        [HideInInspector] public LocationNavigation locationNavigation;
        [HideInInspector] public List<string> interactionDescriptionsInLocation = new List<string>();
        [HideInInspector] public List<string> blocsList = new List<string>();

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
            string logAsText = string.Join("\n", actionLog.ToArray());
            foreach (string s in blocsList)
            {
                dialogBoxController.AddToQueue(s);
            }
            
        }

        private void UnpackLocation()
        {
            locationNavigation.UnpackExitsInLocation();
        }


    }
}