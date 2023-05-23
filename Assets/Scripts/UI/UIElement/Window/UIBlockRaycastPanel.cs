
using UnityEngine;

namespace ProjectG
{
    public class UIBlockRaycastPanel : UIWindow
    {

        public override void Show()
        {
            SetCanvasGroup(true);
        }
        public override void Hide()
        {
            SetCanvasGroup(false);
        }

    }
}
