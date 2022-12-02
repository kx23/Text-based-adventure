using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TBA
{
    public class GameController : MonoBehaviour
    {
        public Text displayText;
        [HideInInspector] public LocationNavigation locationNavigation;
        [HideInInspector] public List<string> interactionDescriptionsInLocation = new List<string>();

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
            UnpackLocation();
            string joinedInteractionDescriptionsInLocation = string.Join("\n", interactionDescriptionsInLocation.ToArray());
            string combinedText = locationNavigation.currentLocation.description + "\n"+joinedInteractionDescriptionsInLocation;
            LogStringWithReturn(combinedText);
        }

        public void LogStringWithReturn(string stringToAdd)
        {
            actionLog.Add(stringToAdd + "\n");
        }

        public void DisplayLoggedText()
        {
            string logAsText = string.Join("\n", actionLog.ToArray());
            displayText.text = logAsText;
        }

        private void UnpackLocation()
        {
            locationNavigation.UnpackExitsInLocation();
        }


    }
}