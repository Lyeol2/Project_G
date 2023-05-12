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

            mainButton.onClick.AddListener(() => controller.ChangeState(EOutGameStateType.Main));
            partyButton.onClick.AddListener(() => controller.ChangeState(EOutGameStateType.Party));
            pickupButton.onClick.AddListener(() => controller.ChangeState(EOutGameStateType.Pickup));
            encycolopediaButton.onClick.AddListener(() => controller.ChangeState(EOutGameStateType.Encycolopedia));
        }


        public override void Hide()
        {
        }

        public override void Show()
        {
        }
    }
}