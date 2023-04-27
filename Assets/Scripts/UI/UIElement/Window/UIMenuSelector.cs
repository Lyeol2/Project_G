using System;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectG
{
    public class UIMenuSelector : UIWindow
    {
        [SerializeField]
        Button mainButton;

        [SerializeField]
        Button partyButton;

        [SerializeField]
        Button pickupButton;

        [SerializeField]
        Button encycolopediaButton;

        [SerializeField]
        Button optionButton;

        public override void InitUI()
        {
            base.InitUI();

        }

        public void BindingButton(OutGameController controller)
        {

            mainButton.onClick.AddListener(() => controller.ChangeState(OutGameStateType.Main));
            partyButton.onClick.AddListener(() => controller.ChangeState(OutGameStateType.Party));
            pickupButton.onClick.AddListener(() => controller.ChangeState(OutGameStateType.Pickup));
            encycolopediaButton.onClick.AddListener(() => controller.ChangeState(OutGameStateType.Encycolopedia));
        }


        public override void Hide()
        {
        }

        public override void Show()
        {
        }
    }
}