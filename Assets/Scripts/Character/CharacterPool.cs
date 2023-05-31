using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ProjectG
{
    public class CharacterPool : MonoBehaviour
    {
        [SerializeField]
        GameObject playerCharacterPrefab;
        [SerializeField]
        SpriteRenderer spriteRenderer;

        Dictionary<ECampPos, CharacterCamp> camps = new Dictionary<ECampPos, CharacterCamp>();


        public void Initialize()
        {

            var child = transform.GetChild(0);
            camps.Add(ECampPos.PlayerFront, child.GetChild(0).GetComponent<CharacterCamp>());
            camps.Add(ECampPos.PlayerMiddle, child.GetChild(1).GetComponent<CharacterCamp>());
            camps.Add(ECampPos.PlayerBack, child.GetChild(2).GetComponent<CharacterCamp>());

            child = transform.GetChild(1);
            camps.Add(ECampPos.EnemyBack, child.GetChild(2).GetComponent<CharacterCamp>());
            camps.Add(ECampPos.EnemyMiddle, child.GetChild(1).GetComponent<CharacterCamp>());
            camps.Add(ECampPos.EnemyFront, child.GetChild(0).GetComponent<CharacterCamp>());

        }
        public void SetLocalScale()
        {
            foreach (var camp in camps)
            {
                foreach (var item in camp.Value.characters)
                {
                    item.transform.localScale = Vector3.one;
                }
            }
        }
        public void AddCharacter(ECampPos pos, int index)
        {
            var obj = Instantiate(playerCharacterPrefab);

            obj.transform.SetParent(camps[pos].transform);
            obj.transform.localPosition = Vector3.zero;

           var character = obj.GetComponent<Character>();
            character.SetCharacter(index);

            if(pos.HasFlag(ECampPos.Enemy) || pos.HasFlag(ECampPos.EnemyBack) || pos.HasFlag(ECampPos.EnemyMiddle) || pos.HasFlag(ECampPos.EnemyFront))
            {
                character.isEnemy = true;
            }

            camps[pos].characters.Add(character);
        }
        public void SetOnPanelCharacter(ECampPos pos)
        {
            PanelActive(true);

            uint bit = 0b00000001;

            foreach (var camp in camps)
            {
                foreach (var item in camp.Value.characters)
                {
                    item?.OrderActive(false);
                }
            }
            while (bit != 0) 
            {
                if(pos.HasFlag((ECampPos)bit))
                {
                    foreach (var item in camps[(ECampPos)bit].characters)
                    {
                        item.OrderActive(true);
                    }
                }
                bit <<= 1;
            }
            
        }
        public void PanelActive(bool active)
        {
            spriteRenderer.color = active ? new Color(0, 0, 0, 0.5f) : new Color(0, 0, 0, 0f);

        }

    }
}