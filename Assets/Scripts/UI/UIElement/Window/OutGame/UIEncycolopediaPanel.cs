
namespace ProjectG
{
    public class UIEncycolopediaPanel : UIWindow
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