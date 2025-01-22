using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopControllerSO", menuName = "ScriptableObject/Shop/ShopControllerSO", order = 0)]
public class ShopControllerSO : SystemConfigCtrl
{
    public bool WasRemoved_Ads;

    [SerializeField] protected DisguiseConfigSO _DisguiseConfigSO;
    public DisguiseConfigSO DisguiseConfigSO => this._DisguiseConfigSO;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadDisguiseConfigSO();
    }

    protected virtual void LoadDisguiseConfigSO()
    {
        if (this._DisguiseConfigSO != null) return;

        this._DisguiseConfigSO = Resources.Load<DisguiseConfigSO>("ScriptableObject/SystemConfig/Shop/DisguiseConfigSO");
    }
}
