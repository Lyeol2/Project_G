using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    // �� ������Ʈ�� ������ �ڽİ�ü�� �䷲������ ����մϴ�.
    public class ParallexScroll : MonoBehaviour
    {

        /* �䷲������ ������ ī�޶� ��ġ */
        private Vector3 m_cameraStartPos;
        /* �ҽ��� */
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
            // �����ϸ� �Ⱦ������� �����
#if UNITY_EDITOR
            CheckNewObject();
#endif

            foreach (var t in m_parallexPool)
            {
                SetParallexPosition(t);
            }

        }
        /// <summary>
        /// ī�޶� ���� ������Ʈ�� �䷲���� ��ũ�� ��ŵ�ϴ�.
        /// </summary>
        void SetParallexPosition(Transform pTransform)
        {
            // 0�� �䷲������ ������
            if (pTransform.position.z == 0) return;

            // Z ��ġ�� �ּҴ� �ҽ����� z ��ġ / �ִ�� ī�޶� Z ��ġ�̴�.
            if (pTransform.position.z > m_vanishingPoint.z && pTransform.position.z < m_parallexCam.transform.position.z)
            {
                Debug.LogWarning($"Didn't over the size between maxDepth and minDepth ::Remove {pTransform.name}::");
                Destroy(pTransform.gameObject);
                return;
            }

            Vector2 diff = m_parallexCamTF.position - m_cameraStartPos + m_vanishingPoint;
            // �ҽ����� �������� 1/2 �̴�.   IF : 10      10 / 20 = 0.5    5 = 0.25
            diff /= (m_vanishingPoint.z * 2) / pTransform.position.z;


            pTransform.position = new Vector3(diff.x, diff.y, pTransform.position.z);


        }
        /// <summary>
        /// Ǯ�� ���ο� ������Ʈ�� �ִ��� Ȯ���մϴ�.
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