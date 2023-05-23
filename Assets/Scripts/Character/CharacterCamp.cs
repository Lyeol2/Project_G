using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ProjectG
{
    [System.Serializable]
    public class CharacterCamp : MonoBehaviour
    {
        public ECampPos campPos;
        [SerializeField]
        public List<Character> characters = new List<Character>();

    }
}