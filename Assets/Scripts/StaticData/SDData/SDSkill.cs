namespace ProjectG
{
    [System.Serializable]
    public class SDSkill : StaticData
    {
        public string name;
        public string description;
        public int turnCost;
        public int[] effector;
        public float damage;
        public string iconPath;
    }
}