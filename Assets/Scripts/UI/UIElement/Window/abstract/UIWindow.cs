using UnityEngine;

namespace ProjectG
{

    /// <summary>
    /// 창 형식이 될 UIObject
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class UIWindow : UIObject
    {
        CanvasGroup _canvasGroup;
        public CanvasGroup canvasGroup
        {
            get
            {
                if(!_canvasGroup)
                {
                    _canvasGroup = GetComponent<CanvasGroup>();
                }
                return _canvasGroup;
            }
        }

        public override void InitUI()
        {
            base.InitUI();
            GameManager.GetManager<UIManager>().RegistUIWindow(this);

        }
        public override void DestroyUI()
        {
            base.DestroyUI();
        }

        public abstract void Show();

        public abstract void Hide();

        protected void SetCanvasGroup(bool isActive, bool blocksRaycast = true)
        {
            canvasGroup.alpha = (isActive ? 1 : 0);
            canvasGroup.interactable = isActive;
            canvasGroup.blocksRaycasts = isActive && blocksRaycast;
        }

        public bool IsActive()
        {
            return canvasGroup.alpha != 0;
        }



    }



}