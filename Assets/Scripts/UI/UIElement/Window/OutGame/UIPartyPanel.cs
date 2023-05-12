namespace ProjectG
{
    public class UIPartyPanel : UIWindow
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