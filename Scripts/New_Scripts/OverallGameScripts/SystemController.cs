using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemController : SurMonoBehaviour
{
    public static int CountScene = 16;

    [SerializeField] protected SystemConfig _SystemConfig;
    public SystemConfig SystemConfig => _SystemConfig;

    private static SystemController m_instance;
    public static SystemController Sys_Instance => m_instance;

    protected override void Awake()
    {
        base.Awake();

        if (m_instance != null) Debug.LogError("Allow only SystemController has been exist");

        m_instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadSystemConfig();
    }

    protected virtual void LoadSystemConfig()
    {
        if (this._SystemConfig != null) return;
        string namePath = "ScriptableObject/SystemConfig/SystemConfig";
        //Debug.Log(namePath);
        this._SystemConfig = Resources.Load<SystemConfig>(namePath);
    }

    public virtual void AddMoneyToSystem(ItemUnit itemUnit)
    {
        switch (itemUnit.TypeItem)
        {
            case TypeItemMoney.NoType:
                break;
            case TypeItemMoney.Gold:
                this._SystemConfig.Total_Golds += itemUnit.Value;
                break;
            case TypeItemMoney.Diamond:
                this._SystemConfig.Total_Diamonds += itemUnit.Value;
                break;
            default:
                break;
        }
    }
    public virtual bool DeductMoneyToSystem(TypeItemMoney typeItem, float value)
    {
        switch (typeItem)
        {
            case TypeItemMoney.NoType:
                break;

            case TypeItemMoney.Gold:
                if (this._SystemConfig.Total_Golds < value) break;
                this._SystemConfig.Total_Golds -= value;
                return true;

            case TypeItemMoney.Diamond:
                if (this._SystemConfig.Total_Diamonds < value) break;
                this._SystemConfig.Total_Diamonds -= value;
                return true;

            default:
                break;
        }
        return false;
    }
    protected virtual string GetNameSceneByOrder(int order) => "Level_" + order.ToString("D2");

    public virtual void StartLoadingSceneByOrderScene(int orderScene)
    {
        string nameScene = this.GetNameSceneByOrder(orderScene);

        StartCoroutine(LoadSceneWithWait(nameScene));
    }

    protected IEnumerator LoadSceneWithWait(string sceneName)
    {
        this.ConductActionWhileLoadingNewScene();
        
        yield return new WaitForSeconds(0.1f);

        // Bắt đầu load scene bất đồng bộ
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        // Đảm bảo scene sẽ không được kích hoạt ngay lập tức khi load xong
        asyncOperation.allowSceneActivation = false;

        // Chờ cho đến khi scene load xong (progress = 0.9)
        yield return new WaitUntil(() => asyncOperation.progress >= 0.9f);

        //  Debug.Log("Scene loaded. Activating scene now...");

        // Kích hoạt scene sau khi load xong
        asyncOperation.allowSceneActivation = true;
    }

    protected virtual void ConductActionWhileLoadingNewScene()
    {

    }

    protected virtual void OnApplicationQuit()
    {
        SaveManager.Instance.SaveGame(); // Lưu dữ liệu từ ScriptableObject xuống file
    }

    public virtual void ChangeAdsSettingPrivacy(bool accept)
    {
        //Set ads Setting
        this._SystemConfig.isAcceptAdsSetting = accept;

        //Save
        SaveManager.Instance.SaveGame();

        //if unaccept => quit game
        if (!accept) Application.Quit();

    }    
}
