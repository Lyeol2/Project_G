using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    // 이 컴포넌트를 가지면 자식객체가 페럴렉스를 사용합니다.
    public class ParallexScroll : MonoBehaviour
    {

        /* 페럴렉스를 시작할 카메라 위치 */
        private Vector3 m_cameraStartPos;
        /* 소실점 */
        [SerializeField] private Vector3 m_vanishingPoint;

        List<Transform> m_parallexPool = new List<Transform>();


        private Camera m_parallexCam;
        private Transform m_parallexCamTF;


        void Awake()
        {
            m_parallexCam = Camera.main;
            m_parallexCamTF = m_parallexCam.transform;
            m_cameraStartPos = m_parallexCamTF.position;
            m_parallexPool.AddRange(transform.GetComponentsInChildren<Transform>());
        }

        void LateUpdate()
        {
            // 빌드하면 안쓸꺼같은 기능임
#if UNITY_EDITOR
            CheckNewObject();
#endif

            foreach (var t in m_parallexPool)
            {
                SetParallexPosition(t);
            }

        }
        /// <summary>
        /// 카메라에 의해 오브젝트를 페럴렉스 스크롤 시킵니다.
        /// </summary>
        void SetParallexPosition(Transform pTransform)
        {
            // 0은 페럴렉스의 기준점
            if (pTransform.position.z == 0) return;

            // Z 위치의 최소는 소실점의 z 위치 / 최대는 카메라 Z 위치이다.
            if (pTransform.position.z > m_vanishingPoint.z && pTransform.position.z < m_parallexCam.transform.position.z)
            {
                Debug.LogWarning($"Didn't over the size between maxDepth and minDepth ::Remove {pTransform.name}::");
                Destroy(pTransform.gameObject);
                return;
            }

            Vector2 diff = m_parallexCamTF.position - m_cameraStartPos + m_vanishingPoint;
            // 소실점의 오차도가 1/2 이다.   IF : 10      10 / 20 = 0.5    5 = 0.25
            diff /= (m_vanishingPoint.z * 2) / pTransform.position.z;


            pTransform.position = new Vector3(diff.x, diff.y, pTransform.position.z);


        }
        /// <summary>
        /// 풀에 새로운 오브젝트가 있는지 확인합니다.
        /// </summary>
        void CheckNewObject()
        {
            if (transform.childCount > m_parallexPool.Count)
            {
                m_parallexPool.Add(transform.GetChild(transform.childCount - 1));
            }
        }
    }
}