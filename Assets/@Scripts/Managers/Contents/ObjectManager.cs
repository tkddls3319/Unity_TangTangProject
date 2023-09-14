using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ObjectManager
{
    public PlayerController Player { get; private set; }
    public HashSet<MonsterController> Monsters { get; } = new HashSet<MonsterController>();
    public HashSet<ProjectileController> Projectiles { get; } = new HashSet<ProjectileController>();
    public HashSet<ExpController> Exps { get; } = new HashSet<ExpController>();
    public HashSet<DropItemController> DropItems { get; } = new HashSet<DropItemController>();

    public void Init()
    {

    }

    public T Spawn<T>(Vector3 pos, int id = 0) where T : BaseController
    {
        //TODO : 아이디값에 따라 몬스터 및 아이템 변경
        Type type = typeof(T);

        if (type == typeof(PlayerController))
        {
            CreatureData data = null;
            if (Managers.Data.MonsterDatas.TryGetValue(id, out data) == false)
                return null;

            GameObject go = Managers.Resource.Instantiate("Player");
            go.name = "Player";
            go.transform.position = pos;

            Player = go.GetComponent<PlayerController>();
            //Player.Init();
            Player.Data = data.DeepCopy();

            Managers.Game.Player = Player;
            return Player as T;
        }
        else if (type == typeof(MonsterController))
        {
            CreatureData data = null;
            if (Managers.Data.MonsterDatas.TryGetValue(id, out data) == false)
                return null;

            GameObject go = Managers.Resource.Instantiate("Monster");
            go.transform.position = pos;

            MonsterController mc = go.GetOrAddComponent<MonsterController>();
            Monsters.Add(mc);

            mc.SetInfo(data);


            return mc as T;
        }
        else if (type == typeof(ProjectileController))
        {
            SkillData data = null;
            if (Managers.Data.SkillDatas.TryGetValue(id, out data) == false)
                return null;

            GameObject go = Managers.Resource.Instantiate("Skill");
            go.transform.position = pos;

            ProjectileController pc = go.GetOrAddComponent<ProjectileController>();
            Projectiles.Add(pc);

            return pc as T;
        }
        else if (type == typeof(ExpController))
        {
            GameObject go = Managers.Resource.Instantiate("Exp");
            go.transform.position = pos;
            ExpController ec = go.GetOrAddComponent<ExpController>();
            Exps.Add(ec);
            ec.Init();

            Managers.Game.Ground.Add(ec);

            return ec as T;
        }
        else if( type == typeof(BombController))
        {
            GameObject go = Managers.Resource.Instantiate("Bomb");
            go.transform.position = pos;
            BombController bc = go.GetOrAddComponent<BombController>();
            DropItems.Add(bc);
            bc.Init();

            Managers.Game.Ground.Add(bc);
            return bc as T;
        }
        return null;
    }

    public void Dspawn<T>(T obj) where T : BaseController
    {
        if (obj.gameObject.IsMyNotNullActive() == false)
            return;

        Type type = typeof(T);

        if (type == typeof(PlayerController))
        {
            //TODO : 플레이어 죽었을경우.
        }
        else if (type == typeof(MonsterController))
        {
            Monsters.Remove(obj as MonsterController);
            Managers.Resource.Destroy(obj.gameObject);
        }
        else if (type == typeof(ProjectileController))
        {
            Projectiles.Remove(obj as ProjectileController);
            Managers.Resource.Destroy(obj.gameObject);
        }
        else if (type == typeof(ExpController))
        {
            Exps.Remove(obj as ExpController);
            Managers.Resource.Destroy(obj.gameObject);
            Managers.Game.Ground.Remove(obj as ExpController);
        }
        else if (type == typeof(BombController))
        {
            DropItems.Remove(obj as ExpController);
            Managers.Resource.Destroy(obj.gameObject);
            Managers.Game.Ground.Remove(obj as BombController);
        }
    }

    public void KillALLMonster()
    {
        UI_GameScene scene = Managers.UI.SceneUI as UI_GameScene;

        if (scene != null)
            scene.EffectFlash();

        foreach (MonsterController monster in Monsters.ToList())
        {
            if (monster.ObjectType == Define.ObjectType.Monster)
                monster.OnDead();
        }
    }

    public void CollectAllDropItem()
    {

    }
    public void Clear()
    {
        Monsters.Clear();
        Exps.Clear();
        Projectiles.Clear();
        DropItems.Clear();
    }

}
