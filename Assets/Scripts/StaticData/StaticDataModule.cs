using ProjectG;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class StaticDataModule
{
    public List<SDCharacter> sdCharacter;
    public List<SDSkill> sdSkill;
    public List<SDEffector> sdEffector;

    public void Initialize()
    {
        var loader = new StaticDataLoader();

        loader.Load(out sdCharacter);
        loader.Load(out sdSkill);
        loader.Load(out sdEffector);
    }


    /// <summary>
    /// 기획데이터를 불러올 로더
    /// </summary>
    private class StaticDataLoader
    {
        private string path;

        public StaticDataLoader()
        {
            path = $"{Application.dataPath}/StaticData/Json";
        }

        public void Load<T>(out List<T> data) where T : StaticData
        {
            // 파일이름이 타입이름에서 SD만 제거하면 동일하다는 규칙이 있음..
            var fileName = typeof(T).Name.Remove(0, "SD".Length);

            var json = File.ReadAllText($"{path}/{fileName}.json");

            data = SerializeHelper.JsonToList<T>(json);
        }
    }
}
