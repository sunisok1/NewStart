using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Assets.Scripts.Game.Core;

namespace Assets.Scripts.Common.Manager
{
    public class ConfigManager : ManagerBase
    {
        private readonly Dictionary<string, object> configDictionary = new();
        private const string configPath = "Config";

        public override void Init()
        {
            base.Init();
            LoadAllConfigs();
        }

        private void LoadAllConfigs()
        {
            LoadConfig<List<Card>>("Cardpile");
            // Add more configurations as needed
        }

        private void LoadConfig<T>(string key)
        {
            string filePath = $"{configPath}/{key}";
            var temp = Resources.Load(filePath);
            if (temp is TextAsset textAsset)
            {
                string json = textAsset.text;
                T result = JsonConvert.DeserializeObject<T>(json);

                if (configDictionary.ContainsKey(key))
                {
                    Debug.LogWarning($"Config data for key '{key}' is being overwritten.");
                    configDictionary[key] = result;
                }
                else
                {
                    configDictionary.Add(key, result);
                    Debug.Log($"Config data for key '{key}' loaded successfully.");
                }
            }
            else
            {
                Debug.LogError($"Config file not found at: {filePath}");
            }
        }

        public T GetConfig<T>(string key)
        {
            if (configDictionary.TryGetValue(key, out object configData) && configData is T t)
            {
                return t;
            }
            else
            {
                Debug.LogError($"Config data not found for key: {key}");
                return default;
            }
        }
    }
}
