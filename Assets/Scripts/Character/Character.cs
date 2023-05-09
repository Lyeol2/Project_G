using System.Collections.Generic;
using UnityEngine;

namespace ProjectG
{
    [System.Serializable]
    public class Character : MonoBehaviour
    {
        [SerializeField]
        SDCharacter character;

        [SerializeField]
        List<Skill> skills = new List<Skill>();
    }
}