using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEditor.Progress;

namespace ProjectG
{
    public enum SpriteSortLayer
    {
        Default,
        Background,
        FrontCharacter,
        NightPanel,
        BackCharacter,


    }
    [System.Serializable]
    public class Character : MonoBehaviour
    {
        SpriteRenderer[] spriteRenderers;


        UICharacterInfoPanel characterInfoPanel;

        [SerializeField]
        public SDCharacter sdCharacter;

        public List<Skill> skills = new List<Skill>();


        public bool isActive = true;
        
        private void Start()
        {
            spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
            characterInfoPanel = GameManager.GetManager<UIManager>().GetUIWindow<UICharacterInfoPanel>();
            OrderActive(true);
        }

        public void PlayCharacter()
        {

        }
        
        private void OnMouseDown()
        {
            if (!isActive) return;

            SetUICharacterInfo();
        }

        public void OrderActive(bool active)
        {
            foreach (var item in spriteRenderers)
            {
                item.sortingLayerName = active ?
                    SpriteSortLayer.FrontCharacter.ToString() : SpriteSortLayer.BackCharacter.ToString();
            }
            isActive = active;

        }

        

        private void SetUICharacterInfo()
        {
            characterInfoPanel.SetSlot(this);
        }


        public void SetCharacter(int index)
        {
            var staticLoader = GameManager.GetManager<DataManager>().SD;
            sdCharacter = staticLoader.sdCharacter.Find(_ => _.index == index);

            for (int i = 0; i < sdCharacter.skills.Length; ++i)
            {
                var skill = new Skill();
                skill.SetSkill(sdCharacter.skills[i]);
                skills.Add(skill);
            }
        }
    }
}