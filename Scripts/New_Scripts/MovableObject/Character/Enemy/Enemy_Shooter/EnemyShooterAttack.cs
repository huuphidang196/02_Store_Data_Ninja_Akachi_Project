using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterAttack : EnemyAttack
{
    [SerializeField] protected bool canSpawn = false;
    [SerializeField] protected Transform _Pos_Spawn_Bullet;
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadPosSpawnBullet();
    }


    protected virtual void LoadPosSpawnBullet()
    {
        if (this._Pos_Spawn_Bullet != null) return;

        this._Pos_Spawn_Bullet = transform.Find("Pos_Spawn_Bullet");
    }

    protected override void Update()
    {
        base.Update();

        if (!this.EnemyCtrl.EnemyAttackActionVFXManager.VFX_Attack.activeInHierarchy) return;

        ParticleSystem ps = this.EnemyCtrl.EnemyAttackActionVFXManager.VFX_Attack.GetComponent<ParticleSystem>();
        if (this.canSpawn == ps.isPlaying) return;

        this.canSpawn = ps.isPlaying;

        if (!this.canSpawn) return;

        this.EnemyAttackShoot();

        //this.ResetAllFigure();
    }

    protected virtual void EnemyAttackShoot()
    {
        // Spawn bullet
        Transform bullet = WeaponCharacterSpawner.Instance.Spawn(WeaponCharacterSpawner.Name_Bullet_Enemy_Shooter, this._Pos_Spawn_Bullet.position, Quaternion.identity);

        //Set Direction fly
        BulletEnemyShooterCtrl bulletEnemyShooterCtrl = bullet.GetComponent<BulletEnemyShooterCtrl>();
        bulletEnemyShooterCtrl.WeaponCharacterMovement.SetDirectionFly(this._CharacterCtrl.transform);

        bullet.localScale = Vector3.one;
        bulletEnemyShooterCtrl.name = WeaponCharacterSpawner.Name_Bullet_Enemy_Shooter;
        bulletEnemyShooterCtrl.gameObject.SetActive(true);
        //Debug.Log("Shoot");
    }
}
