namespace ProjectG
{
    public class UITurnSlot : UIObject, IUISlot<Skill>
    {
        public Skill skill;
        
        public void SetSlot(Skill info)
        {
            skill = info;
        }
    }
}