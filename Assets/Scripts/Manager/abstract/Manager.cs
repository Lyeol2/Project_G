using UnityEngine;

namespace ProjectG
{
    public abstract class Manager : MonoBehaviour
    {

        bool isInit = false;
        /// <summary>
        /// 매니저를 초기화합니다. (초기상태로 돌림)
        /// </summary>
        public virtual void InitManager()
        {
            isInit = false;


            isInit = true;
        }

        /// <summary>
        /// 매니저의 업데이트 함수입니다.
        /// </summary>
        public virtual void UpdateManager()
        {
            if (!isInit) return;
        }


        /// <summary>
        /// 매니저를 삭제합니다.
        /// </summary>
        public virtual void DestroyManager()
        {

        }
    }



}