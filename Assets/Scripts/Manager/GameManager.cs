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
    /// 게임 자체를 관리
    /// 씬변경을 포함한 여러것..
    /// </summary>
    public class GameManager : Singleton<GameManager>
    {
        // 매니저 풀
        Dictionary<string, Manager> managers =  new Dictionary<string, Manager>();
        // 컨트롤러 풀 (FSM)
        Dictionary<SceneType, Controller> controllers = new Dictionary<SceneType, Controller>();


        public SceneType sceneType;
        // 현재 사용중인 컨트롤러

        public static Controller controller => Instance.controllers[Instance.sceneType];


        protected override void Awake()
        {
            DontDestroyOnLoad(this);


            // 매니저 초기화
            RegistManager();




            controllers.Add(SceneType.OutGame, LoadController<OutGameController>());
            controllers.Add(SceneType.InGame, LoadController<InGameController>());
            // 테스트용
            SelectController(SceneType.InGame);


        }
        public void RegistManager()
        {

            var mg = FindObjectsOfType<Manager>();
            foreach (var item in mg)
            {
                managers.Add(item.GetType().Name, item);
                item.InitManager();
            }
        }
        public void SelectController(SceneType sceneType)
        {
            this.sceneType = sceneType;
            controller.InitController();
        }
        public void Update()
        {
            controller?.UpdateController();

            foreach (var item in managers)
            {
                item.Value.UpdateManager();
            }
        }


        public void LoadScene(SceneType sceneType)
        {

        }



        /// <summary>
        /// 매니저 받아오는 함수
        /// </summary>
        /// <typeparam name="T">타입</typeparam>
        /// <returns>매니저</returns>
        public static T GetManager<T>() where T : Manager, new()
        {
            // 있으면 반환
            if(Instance.managers.TryGetValue(typeof(T).Name, out Manager value))
                return (T)value;

            return Instance.AddManager<T>();


        }
        public T LoadController<T>() where T : Controller
        {
            var ctrller = FindObjectOfType<T>();
            if (!ctrller) ctrller = CreateController<T>();
            return ctrller;
        }
        public static T GetController<T>() where T : Controller
        {
            return Instance.controllers as T;
        }
        public T CreateController<T>() where T : Controller
        {
            var go = new GameObject(typeof(T).Name);
            go.transform.SetParent(transform);
            return go.AddComponent<T>();
        }
        /// <summary>
        /// 매니저를 추가하는 함수
        /// </summary>
        /// <typeparam name="T">타입</typeparam>
        /// <returns>매니저</returns>
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

            // 매니저 등록
            managers.Add(typeof(T).Name, go);

            return go.GetComponent<T>();

        }
    }
}
