using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace ProjectG
{
    [System.Serializable]
    public class Character : MonoBehaviour
    {
        SpriteRenderer spriteRenderer;

        [SerializeField]
        SDCharacter character;

        [SerializeField]
        List<Skill> skills = new List<Skill>();

        private void Start()
        {
            GetComponent<SpriteRenderer>();            
        }
        public void SetCharacter(int index)
        {
            var staticLoader = GameManager.GetManager<DataManager>().SD;
            character = staticLoader.sdCharacter.Find(_ => _.index == index);

            for (int i = 0; i < 4; i++)
            {
                var skill = new Skill();
                skill.SetSkill(character.skill[i]);
                skills.Add(skill);
            }
        }
    }
}