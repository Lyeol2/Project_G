using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjectG
{
    public class UITurnSlot : UIObject, IUISlot<Skill>,IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        // InfoPanel에 고정되어있는 턴슬롯인지 확인합니다
        public bool isStatic = false;

        UITurnPanel _uiTurnPanel = null;
        UITurnPanel uiTurnPanel
        {
            get
            {
                if(_uiTurnPanel == null)
                    _uiTurnPanel = GameManager.GetManager<UIManager>().GetUIWindow<UITurnPanel>();

                return _uiTurnPanel;
            }
        }

        UISkillInfoPanel _skillInfoPanel = null;
        UISkillInfoPanel skillInfoPanel 
        { 
            get
            {
                if (_skillInfoPanel == null)
                    _skillInfoPanel = GameManager.GetManager<UIManager>().GetUIWindow<UISkillInfoPanel>();

                return _skillInfoPanel;
            }
        }

        public Skill skill = new Skill();

        public override void InitUI()
        {
            base.InitUI();

        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            skillInfoPanel?.Show();
            skillInfoPanel?.SetSlot(this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            skillInfoPanel?.Hide();
        }

        public void SetSlot(Skill info)
        {
            skill = info;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (isStatic)
            {
                RegistTurnPanel();
            }
            else
            {
                RemoveTurnPanel();
            }
        }
        private void RemoveTurnPanel()
        {
            uiTurnPanel.RemoveSkill(this);
        }
        // 턴 패널에 등록합니다
        private void RegistTurnPanel()
        {
            uiTurnPanel.AddSkill(this);
        }
    }
}