using ProjectG;
using System.IO;
using UnityEngine;

public class DataManager : Manager
{

    public StaticDataModule SD = new StaticDataModule();
    public UserData UD;
    public override void InitManager()
    {
        base.InitManager();

        SD.Initialize();

        // -TODO- Sample ud load
        LoadUserData(1);

    }

    public void LoadUserData(int dataNum)
    {
        string path = $"{DataConfig.UDJsonPath}/user{dataNum}.json";

        var json = File.ReadAllText(path);

        UD = SerializeHelper.FromJson<UserData>(json);
        
    }




}