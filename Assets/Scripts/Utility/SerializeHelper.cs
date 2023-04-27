using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class SerializeHelper
{
    public static string ToJson<T>(T data)
    {
        return JsonConvert.SerializeObject(data);
    }
    public static T FromJson<T>(string data)
    {
        try
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
        catch (Exception ex)
        {
            throw new Exception("직렬화 오류! : " + ex);
        }
    }
    public static List<T> JsonToList<T>(string json)
    {
        try
        {
            return JsonConvert.DeserializeObject<List<T>>(json);
        }
        catch
        {
            Debug.Log(json);
            return null;
        }
    }

    public static string ByteToString(byte[] data)
    {
        return Encoding.UTF8.GetString(data);
    }
    public static byte[] StringToByte(string data)
    {
        return Encoding.UTF8.GetBytes(data);
    }
    public static byte[] DataToByte<T>(T data)
    {
        string json = ToJson(data);

        return Encoding.UTF8.GetBytes(json);
    }
    public static T ByteToData<T>(byte[] data)
    {
        string json = ByteToString(data);

        return FromJson<T>(json);
    }
}
