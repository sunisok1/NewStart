using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ResourcePathSetter : EditorWindow
{
    [MenuItem("Tools/SetAll")]
    private static void SetAllResourcePaths()
    {
        // 获取Resources文件夹下的所有可加载的资源
        string[] allResourcePaths = GetAllResourcePaths();

        // 生成所有字段字符串，并一次性写入ViewConst文件
        GenerateAndWriteFields(allResourcePaths);

        // 刷新Unity编辑器
        AssetDatabase.Refresh();
    }

    private static string[] GetAllResourcePaths()
    {
        // 获取所有Resources文件夹下的资源路径
        string[] allResourceGuids = AssetDatabase.FindAssets("", new[] { "Assets/Resources" });
        string[] allResourcePaths = new string[allResourceGuids.Length];

        for (int i = 0; i < allResourceGuids.Length; i++)
        {
            string assetPath = RemoveResourcesPath(AssetDatabase.GUIDToAssetPath(allResourceGuids[i]));
            assetPath = Path.ChangeExtension(assetPath, null);
            allResourcePaths[i] = assetPath;
        }

        return allResourcePaths;
    }

    private static void GenerateAndWriteFields(string[] allResourcePaths)
    {
        // ViewConst文件路径
        string viewConstPath = "Assets/Scripts/Game/Core/ViewConst.cs";

        // 生成所有字段字符串
        List<string> fieldStrings = new List<string>();
        foreach (string resourcePath in allResourcePaths)
        {
            // 在ViewConst中创建静态字符串字段，字段名为资源相对路径（不包含后缀名）
            string fieldName = $"    public const string {MakeValidIdentifier(resourcePath)} = \"{resourcePath}\";";
            fieldStrings.Add(fieldName);
        }

        // 将所有字段一次性写入ViewConst文件
        System.IO.File.WriteAllText(viewConstPath, $"public class ViewConst\n{{\n{string.Join("\n", fieldStrings)}\n}}\n");
    }

    private static string RemoveResourcesPath(string path)
    {
        return path["Assets/Resources/".Length..];
    }

    private static string MakeValidIdentifier(string input)
    {
        // 将字符串转换为有效的 C# 标识符
        input = input.Replace(" ", "_"); // 替换空格为下划线
        input = input.Replace("/", "_"); // 替换/为下划线
        if (!char.IsLetter(input[0])) // 如果首字符不是字母，则在前面加上下划线
        {
            input = "_" + input;
        }

        return input;
    }
}
