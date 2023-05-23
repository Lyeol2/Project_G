using UnityEngine;

namespace ProjectG
{
    // 이펙트
    [System.Serializable]
    public class Effector
    {
        public SDEffector sdEffector;


        public void SetEffector(int index)
        {
            var staticLoader = GameManager.GetManager<DataManager>().SD;
            sdEffector = staticLoader.sdEffector.Find(_ => _.index == index);
        }

    }



}