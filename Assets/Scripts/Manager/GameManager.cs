using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace ProjectG
{
    public enum SceneType
    {
        Title,
        InGame,
        OutGame,
        Loadig,
        Test,
    }
    /// <summary>
    /// ���� ��ü�� ����
    /// �������� ������ ������..
    /// </summary>
    public class GameManager : Singleton<GameManager>
    {
        // �Ŵ��� Ǯ
        Dictionary<string, Manager> managers =  new Dictionary<string, Manager>();
        // ��Ʈ�ѷ� Ǯ (FSM)
        Dictionary<SceneType, Controller> controllers = new Dictionary<SceneType, Controller>();

        // ���� ������� ��Ʈ�ѷ�
        Controller _controller;
        public static Controller controller => Instance._controller;


        protected override void Awake()
        {
            DontDestroyOnLoad(this);

            // �Ŵ��� �ʱ�ȭ
            GetManager<UIManager>().InitManager();
            GetManager<DataManager>().InitManager();

            // ��Ʈ�ѷ� fsm ���
            controllers.Add(SceneType.OutGame, new OutGameController());
            // �׽�Ʈ��
            SelectController(SceneType.OutGame);


        }
        public void SelectController(SceneType sceneType)
        {
            _controller = controllers[sceneType];
            _controller.InitController();
        }
        public void Update()
        {
            _controller?.UpdateController();

            foreach (var item in managers)
            {
                item.Value.UpdateManager();
            }
        }


        public void LoadScene(SceneType sceneType)
        {

        }



        /// <summary>
        /// �Ŵ��� �޾ƿ��� �Լ�
        /// </summary>
        /// <typeparam name="T">Ÿ��</typeparam>
        /// <returns>�Ŵ���</returns>
        public static T GetManager<T>() where T : Manager, new()
        {
            // ������ ��ȯ
            if(Instance.managers.TryGetValue(typeof(T).Name, out Manager value))
                return (T)value;

            return Instance.AddManager<T>();


        }
        public static T GetController<T>() where T : Controller
        {
            return Instance.controllers as T;


        }
        /// <summary>
        /// �Ŵ����� �߰��ϴ� �Լ�
        /// </summary>
        /// <typeparam name="T">Ÿ��</typeparam>
        /// <returns>�Ŵ���</returns>
        public T AddManager<T>() where T : Manager, new()
        {
            if (managers.ContainsKey(typeof(T).Name))
            {
                Debug.Log($"Already exist {typeof(T).Name} so didn't add Manager");
                return null;
            }

            var go = new GameObject(typeof(T).Name)
                .AddComponent<T>();

            go.transform.SetParent(transform);

            // �Ŵ��� ���
            managers.Add(typeof(T).Name, go);

            return go.GetComponent<T>();

        }
    }
}
