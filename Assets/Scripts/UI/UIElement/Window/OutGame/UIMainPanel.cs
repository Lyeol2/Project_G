namespace ProjectG
{
    public class UIMainPanel : UIWindow
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