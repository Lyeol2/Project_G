﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ProjectG
{

    public class UISkillInfoPanel : UIWindow, IUISlot<UITurnSlot>
    {
        RectTransform rect;

        public override void Show()
        {
            SetCanvasGroup(true, false);
        }
        public override void Hide()
        {
            SetCanvasGroup(false, false);
        }
        public override void InitUI()
        {
            base.InitUI();
            rect = GetComponent<RectTransform>();

        }
        public override void UpdateUI()
        {
            base.UpdateUI();

            SetPivot();
            if (IsActive())
            {
                transform.position = Input.mousePosition;
            }

        }
        public override void DestroyUI()
        {
            base.DestroyUI();


        }
        public void SetPivot()
        {
            var point = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            var vec = new Vector2(
                (point.x > 0.5f) ? 1 : 0,
                (point.y > 0.5f) ? 1 : 0
                );

            rect.pivot = vec;
        }

        public void SetSlot(UITurnSlot info)
        {
        }
    }
}