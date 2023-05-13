using System.Collections.Generic;
using UnityEngine.TextCore.Text;

namespace ProjectG
{
    public class Skill
    {
        public SDSkill sdSkill;
        public List<Effector> effector = new List<Effector>();
        // 이 스킬이 턴 슬롯에 올라와 있는지
        // 올라와 있다면 사용할 수 없음
        public bool isSetting = false;
        public int leftCost = 0;
        public int speed = 0;

        public void SetSkill(int index)
        {
            var staticLoader = GameManager.GetManager<DataManager>().SD;
            sdSkill = staticLoader.sdSkill.Find(_ => _.index == index);

            for (int i = 0; i < sdSkill.effectors.Length; i++)
            {
                Effector item = new Effector();
                item.SetEffector(sdSkill.effectors[i]);
                effector.Add(item);
            }

        }
    
    }
}