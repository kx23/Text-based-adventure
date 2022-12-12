using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TBA
{
    public class LocationNavigation : MonoBehaviour
    {
        public Location currentLocation;

        private GameController controller;

        private void Awake()
        {
            controller = GetComponent<GameController>();
        }

        public void UnpackExitsInLocation()
        {
            foreach (Exit e in currentLocation.exits)
            {
                    controller.blocsList.Add(e.exitDescription);
            }
        }
    }
}

