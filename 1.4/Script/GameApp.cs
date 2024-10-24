using SaveSystemTutorial;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameApp : MonoBehaviour
{
    public static GameApp instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        PlayerManager.Instance.Init();

        UIManager.Instance.ShowUI<LoginUI>("LoginUI");

        // 播放音乐...

        if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)//第一次打开时清除可能的存档
        {
            SaveSystem.DeleteSaveFile("Player.save");

            PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Save()
    {
        PlayerInfo saveData = new PlayerInfo();
        for (int i = 0; i < 3; i++)
        {
            saveData.eqiupments[i] = i<PlayerManager.Instance.equipments.Count ? PlayerManager.Instance.equipments[i].EquipmentName : "";
        }
        saveData.numberOfLayer = LevelManager.Instance.level;
        SaveSystem.SaveByJson("Player.save", saveData);
    }

    public void Load()
    {
        PlayerInfo saveData = SaveSystem.ReadFromJson<PlayerInfo>("Player.save");
        if (saveData == default) return;
        for (int i = 0; i < 3; i++)
        {
            if (saveData.eqiupments[i]!="")
            {
                EquipmentBase eq = EquipmentInventory.Instance.GetEquipment(saveData.eqiupments[i]);
                UIManager.Instance.GetUI<EquipmentUI>("EquipmentUI").CreateEquipmentItem(eq.sprite, eq.EquipmentName, eq.description, eq.descriptionPos);
            }
        }
        LevelManager.Instance.level=saveData.numberOfLayer;
    }

    public void StartPractice()
    {
        GetComponent<Practice>().StartPractice();
    }
}
