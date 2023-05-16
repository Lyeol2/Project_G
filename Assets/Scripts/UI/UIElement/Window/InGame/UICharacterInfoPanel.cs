using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

namespace ProjectG
{
    public class UICharacterInfoPanel : UIWindow, IUISlot<Character>
    {
        [SerializeField]
        Image figureImage;

        [SerializeField]
        TMP_Text characterNameText;

        [SerializeField]
        TMP_Text characterDescriptionText;

        [SerializeField]
        UITurnSlot[] uiTurnSlots = new UITurnSlot[4];



        public override void InitUI()
        {
            base.InitUI();


        }
        public override void Show()
        {
        }
        public override void Hide()
        {
        }

        public void SetSlot(Character info)
        {

            characterNameText.text = info.sdCharacter.name;
            
            for (int i = 0; i < info.skills.Count; ++i)
            {
                uiTurnSlots[i].SetSlot(info.skills[i]);
            }
        }
    }


}