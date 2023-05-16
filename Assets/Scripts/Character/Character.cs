using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace ProjectG
{
    [System.Serializable]
    public class Character : MonoBehaviour
    {
        SpriteRenderer spriteRenderer;


        UICharacterInfoPanel characterInfoPanel;

        [SerializeField]
        public SDCharacter sdCharacter;

        public List<Skill> skills = new List<Skill>();

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            characterInfoPanel = GameManager.GetManager<UIManager>().GetUIWindow<UICharacterInfoPanel>();
        }

        public void PlayCharacter()
        {

        }
        
        private void OnMouseDown()
        {
            SetUICharacterInfo();
        }

        private void SetUICharacterInfo()
        {
            characterInfoPanel.SetSlot(this);
        }

        public void SetCharacter(int index)
        {
            var staticLoader = GameManager.GetManager<DataManager>().SD;
            sdCharacter = staticLoader.sdCharacter.Find(_ => _.index == index);

            for (int i = 0; i < 4; ++i)
            {
                var skill = new Skill();
                skill.SetSkill(sdCharacter.skill[i]);
                skills.Add(skill);
            }
        }
    }
}