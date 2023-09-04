using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectManager
{
    public PlayerController Player { get; private set; }
    public HashSet<MonsterController> Monsters { get; } = new HashSet<MonsterController>();
    public HashSet<ProjectileController> Projectiles { get; } = new HashSet<ProjectileController>();
    public HashSet<ExpController> Exps { get; } = new HashSet<ExpController>();

    public T Spawn<T>(Vector3 pos, int id = 0) where T : BaseController
    {
        //TODO : 아이디값에 따라 몬스터 및 아이템 변경

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
            //TODO : 몬스터 늘어나면 변경
            mc.Data = Managers.Data.MonsterDatas[0];
            Monsters.Add(mc);
            mc.Init();

            return mc as T;
        }
        else if(type == typeof(ProjectileController))
        {
            string name = Define.Projectile.Bolt.ToString();
            switch (id)
            {
                case (int)Define.Projectile.Bolt:
                    name = Define.Projectile.Bolt.ToString();
                    break;
                case (int)Define.Projectile.Charged:
                    name = Define.Projectile.Charged.ToString();
                    break;
                case (int)Define.Projectile.Crossed:
                    name = Define.Projectile.Charged.ToString();
                    break;
                case (int)Define.Projectile.Hits1:
                    name = Define.Projectile.Hits1.ToString();
                    break;
                case (int)Define.Projectile.Hits2:
                    name = Define.Projectile.Hits2.ToString();
                    break;
                case (int)Define.Projectile.Hits3:
                    name = Define.Projectile.Hits3.ToString();
                    break;
                case (int)Define.Projectile.Hits4:
                    name = Define.Projectile.Hits4.ToString();
                    break;
                case (int)Define.Projectile.Hits5:
                    name = Define.Projectile.Hits5.ToString();
                    break;
                case (int)Define.Projectile.Hits6:
                    name = Define.Projectile.Hits6.ToString();
                    break;
                case (int)Define.Projectile.Pulse:
                    name = Define.Projectile.Pulse.ToString();
                    break;
                case (int)Define.Projectile.Spark:
                    name = Define.Projectile.Spark.ToString();
                    break;
                case (int)Define.Projectile.WaveForm:
                    name = Define.Projectile.WaveForm.ToString();
                    break;

            } 
            GameObject go = Managers.Resource.Instantiate($"{name}.prefab");
            go.transform.position = pos;
            Animator anim = go.GetComponent<Animator>();
            anim.Play(name);

            ProjectileController pc = go.GetOrAddComponent<ProjectileController>();
        
            Projectiles.Add(pc);
            pc.Init();

            return pc as T;
        }
        else if (type == typeof(ExpController))
        {
            GameObject go = Managers.Resource.Instantiate("Exp.prefab");
            go.transform.position = pos;
            ExpController ec = go.GetOrAddComponent<ExpController>();
            Exps.Add(ec);
            ec.Init();

            string name = (UnityEngine.Random.Range(0, 2) == 0 ? "ExpBronze" : "ExpSilver");
            Sprite sprite = Managers.Resource.Load<Sprite>($"{name}.sprite");
            go.GetOrAddComponent<SpriteRenderer>().sprite = sprite;

            return ec as T;
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
