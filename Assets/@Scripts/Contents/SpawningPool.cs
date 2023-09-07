using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPool : MonoBehaviour
{
    float _monsterInterval = 0.5f;
    int _maxMonsterCount = 10;
    Coroutine _coUpdateSpaningPool;

    public bool Stopped { get; set; } = false;

    void Start()
    {
        _coUpdateSpaningPool = StartCoroutine(CoUpdateSpaningPool());
    }

    IEnumerator CoUpdateSpaningPool()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(_monsterInterval);
        }
    }

    void Spawn()
    {
        if (Stopped)
            return;

      int monsterCount =  Managers.Object.Monsters.Count;
        if (_maxMonsterCount <= monsterCount)
            return;

        Vector3 randPos = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        MonsterController mc = Managers.Object.Spawn<MonsterController>(randPos, Random.Range(0, 2));
    }

}
