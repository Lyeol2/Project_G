using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

/// <summary>
/// StaticData ������ �߰��Ǿ��� �� ��ó���� ����
/// excel ������ �߰��� �����ϰ�, json ���Ϸ� ��ȯ�Ѵ�.
/// </summary>
public static class StaticDataImporter
{
    public static void Import(string[] importedAssets, string[] deletedAssets,
        string[] movedAssets, string[] movedFromAssetPaths)
    {
        ImportNewOrModified(importedAssets);
        Delete(deletedAssets);
        Move(movedAssets, movedFromAssetPaths);
    }

    /// <summary>
    /// ������ ������ ��� ������ ���
    /// </summary>
    /// <param name="deletedAssets"></param>
    private static void Delete(string[] deletedAssets)
    {
        ExcelToJson(deletedAssets, true);
    }

    /// <summary>
    /// ������ �̵� ���� ��
    /// </summary>
    /// <param name="movedAssets">���ο� ���(�̵� ��)�� ���� ����</param>
    /// <param name="movedFromAssetPaths">���� ���(�̵� ��)�� ���� ����</param>
    private static void Move(string[] movedAssets, string[] movedFromAssetPaths)
    {
        // ���� ��� ���� ���� ��� ����
        Delete(movedFromAssetPaths);
        // ���ο� ��� ���� ����
        ImportNewOrModified(movedAssets);
    }

    /// <summary>
    /// ������ ���� ����Ʈ�ϰų� �������� ��
    /// </summary>
    /// <param name="importedAssets">����Ʈ�ϰų� ������ ���� ����</param>
    private static void ImportNewOrModified(string[] importedAssets)
    {
        ExcelToJson(importedAssets, false);
    }

    private static void ExcelToJson(string[] assets, bool isDeleted)
    {
        List<string> staticDataAssets = new List<string>();

        // �Ķ���ͷ� ���� ���� ��ο��� �������ϸ� �ɷ�����.
        foreach (var asset in assets)
        {
            if (IsStaticData(asset, isDeleted))
                staticDataAssets.Add(asset);
        }

        // �ɷ��� excel ��ȹ�����͸� json���� ��ȯ�� �õ��Ѵ�.
        foreach (var staticDataAsset in staticDataAssets)
        {
            try
            {
                // ��ο��� �����̸��� Ȯ���ڸ� �����.
                var fileName = staticDataAsset.Substring(staticDataAsset.LastIndexOf('/') + 1);
                // Ȯ���ڸ� �����ؼ� �����̸��� �����.
                fileName = fileName.Remove(fileName.LastIndexOf('.'));

                var rootPath = Application.dataPath;
                rootPath = rootPath.Remove(rootPath.LastIndexOf('/'));

                var fileFullPath = $"{rootPath}/{staticDataAsset}";

                var excelToJsonConvert = new ExcelToJsonConvert(fileFullPath,
                    $"{rootPath}/{DataConfig.SDJsonPath}");

                // ��ȯ ���� �� ����� ��ȯ�޾� �����ߴ��� Ȯ��
                if (excelToJsonConvert.SaveJsonFiles() > 0)
                {
                    AssetDatabase.ImportAsset($"{DataConfig.SDJsonPath}/{fileName}.json");
                    Debug.Log($"##### StaticData {fileName} reimported");
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                Debug.LogErrorFormat("Couldn't convert assets = {0}", staticDataAsset);
                EditorUtility.DisplayDialog("Error Convert", 
                    string.Format("Couldn't convert assets = {0}", staticDataAsset),
                    "OK");
            }
        }
    }

    /// <summary>
    /// ������ ���� �����̸鼭 ��ȹ���������� üũ
    /// </summary>
    /// <param name="path">�ش� ���� ���</param>
    /// <param name="isDeleted">���� �̺�Ʈ����?</param>
    /// <returns></returns>
    private static bool IsStaticData(string path, bool isDeleted)
    {
        // excel ������ �ƴ϶�� ����
        if (path.EndsWith(".xlsx") == false)
            return false;

        var absolutePath = Application.dataPath + path.Remove(0, "Assets".Length);

        // �����̺�Ʈ�̰ų� �����ϴ� ���Ͼ���ϰ�, ��δ� excel������ ��ο� �־���Ѵ�.
        return ((isDeleted || File.Exists(absolutePath)) && path.StartsWith(DataConfig.SDExcelPath));
    }
}
