using UnityEngine;

namespace ProjectG
{
    /// <summary>
    /// 모든 종류의 스크립팅된 UIObject는 이 오브젝트를 상속받습니다.
    /// </summary>
    public abstract class UIObject : MonoBehaviour
    {
        public virtual void InitUI()
        {
            GameManager.GetManager<UIManager>().RegistUIObject(this);
        }
        public virtual void UpdateUI()
        {

        }
        public virtual void DestroyUI()
        {

        }
    }





}