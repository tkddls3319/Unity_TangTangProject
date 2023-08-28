using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ObjectManager
{
    public PlayerController Player { get; private set; }

    public HashSet<MonsterController> Monsters { get; } = new HashSet<MonsterController>();
    public HashSet<ProjectileController> Projectiles { get; } = new HashSet<ProjectileController>();

    public T Spawn<T>(Vector3 pos, int id = 0) where T : BaseController
    {
        Type type = typeof(T);

        if (type == typeof(PlayerController))
        {
            GameObject go = Managers.Resource.Instantiate("Player.prefab");
            go.name = "Player";
            go.transform.position = pos;    

            Player = go.GetOrAddComponent<PlayerController>();
            Player.Init();

            return Player as T;
        }
        else if (type == typeof(MonsterController))
        {
            string name = (id == 0 ? "Zombe" : "Zombe");

            GameObject go = Managers.Resource.Instantiate($"{name}.prefab");
            go.transform.position = pos;

            MonsterController mc = go.GetOrAddComponent<MonsterController>();
            Monsters.Add(mc);
            mc.Init();

            return mc as T;
        }
        else if(type == typeof(ProjectileController))
        {
            string name = (id == 0 ? "bullets_0" : "bullets_0");
            GameObject go = Managers.Resource.Instantiate($"{name}.prefab");
            go.transform.position = pos;

            ProjectileController pc = go.GetOrAddComponent<ProjectileController>();
        
            Projectiles.Add(pc);
            pc.Init();

            return pc as T;
        }
        return null;
    }

    public void Dspawn<T>(T obj) where T : BaseController
    {
        if (obj.gameObject.IsNotNullActive() == false)
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
    }
}
