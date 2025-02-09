using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyShooterCtrl : WeaponCharacterCtrl
{
    public ObjTriigerImpactTargetPlayerAndHidenMode BulletEnemyShooterImpact => this.WeaponCharacterImpact as ObjTriigerImpactTargetPlayerAndHidenMode;
    public BulletEmemyShooterDamReceiver BulletEmemyShooterDamReceiver => this.WeaponCharacterDamReceiver as BulletEmemyShooterDamReceiver;

    protected override string GetNameFolderTypeObjectUsing()
    {
        return "Enemy" + "/";
    }
}
