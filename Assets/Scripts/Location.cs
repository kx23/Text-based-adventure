using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TBA
{
    [CreateAssetMenu(menuName = "TBA/Location")]
    public class Location : ScriptableObject
    {
        [TextArea]
        public string description;
        public string roomName;
        public Exit[] exits;


    }
}


