using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace ProjectG
{
    public class UIManager : Manager
    {
        private Dictionary<string, UIWindow> cachedUIWindow = new Dictionary<string, UIWindow>();

        private List<UIObject> uiObjects = new List<UIObject>();

        public override void InitManager()
        {
            uiObjects.Clear();

            var objs = FindObjectsOfType<UIObject>();

            foreach (var item in objs)
            {
                item.InitUI();
            }
        }
        public override void UpdateManager()
        {
            foreach (var item in uiObjects)
            {
                item.UpdateUI();
            }

        }
        public override void DestroyManager()
        {

        }
        public T GetUIWindow<T>() where T : UIWindow
        {
            if(cachedUIWindow.TryGetValue(typeof(T).Name, out UIWindow window))
            {
                return window as T;
            }
            Debug.LogWarning($"didn't find ui : {typeof(T).Name}");
            return null;
        }
        public void RegistUIObject(UIObject obj)
        {
            uiObjects.Add(obj);
        }
        public void RegistUIWindow(UIWindow window)
        {
            string name = window.GetType().Name;
            if (cachedUIWindow.ContainsKey(name))
            {
                Debug.LogWarning($"you try same type ui : {name}");
                return;
            }
            cachedUIWindow.Add(name, window);
        }
    }
}