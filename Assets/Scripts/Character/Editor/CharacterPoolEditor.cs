using System;
using UnityEditor;
using UnityEngine;

namespace ProjectG
{
    public class CharacterPoolEditor : Editor
    {
        CharacterPool characterPool;

        [SerializeField]
        Character[] front = new Character[3];
        [SerializeField]
        Character[] middle = new Character[3];
        [SerializeField]
        Character[] back = new Character[3];
        void OnEnable()
        {
            characterPool = target as CharacterPool;
        }

        public override void OnInspectorGUI()
        {


            EditorUtility.SetDirty(characterPool);
        }



    }



}