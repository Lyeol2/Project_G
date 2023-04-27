namespace ProjectG
{
    public class UIPickupPanel : UIWindow
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