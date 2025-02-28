using System.Collections.Generic;
using System.IO;
using SaveLoadSystem;
using UnityEngine;

namespace Services
{
    public class SaveLoadService : BaseServiceSingleton<SaveLoadService>
    {
        private static string SavePath => Application.persistentDataPath + "/Assets/SaveLoadData" + "/game_save.json";
        public override void Init()
        {
            base.Init();
            Debug.Log($"SaveLoadService Initializing. Save path: {SavePath}");
        }

        public static void Save(ISaveLoadObject objectToSave)
        {
            GameSaveData saveData;

            // 1. Загружаем существующий JSON (если файл есть)
            if (File.Exists(SavePath))
            {
                string existingJson = File.ReadAllText(SavePath);
                saveData = JsonUtility.FromJson<GameSaveData>(existingJson);
            }
            else
            {
                saveData = new GameSaveData();
            }

            // 2. Обновляем или добавляем новый ключ
            string key = objectToSave.SaveKey;
            string jsonData = JsonUtility.ToJson(objectToSave.GetSaveData());
            saveData.Data[key] = jsonData;

            // 3. Записываем обновлённые данные обратно в файл
            string updatedJson = JsonUtility.ToJson(saveData, true);
            File.WriteAllText(SavePath, updatedJson);

            Debug.Log($"[SaveSystem] Данные {key} сохранены.");
        }
        
        public static void Load(ISaveLoadObject obj)
        {
            if (!File.Exists(SavePath))
            {
                Debug.LogWarning($"[SaveSystem] Файл сохранения не найден. Используется новое сохранение для {obj.SaveKey}.");
                return;
            }

            string json = File.ReadAllText(SavePath);
            GameSaveData saveData = JsonUtility.FromJson<GameSaveData>(json);

            string key = obj.SaveKey;
            if (saveData.Data.TryGetValue(key, out string jsonData))
            {
                object data = JsonUtility.FromJson(jsonData, obj.GetSaveData().GetType());
                obj.LoadFromSaveData(data);
                Debug.Log($"[SaveSystem] {key} загружен.");
            }
            else
            {
                Debug.LogWarning($"[SaveSystem] В сохранении нет данных для {key}.");
            }
        }
    }
}