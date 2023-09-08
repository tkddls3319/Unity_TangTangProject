using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPool : MonoBehaviour
{
    float _monsterInterval = 0.5f;
    int _maxMonsterCount = 10;
    Coroutine _coUpdateSpaningPool;

    public void StartSpawn()
    {
        if (_coUpdateSpaningPool == null)
            _coUpdateSpaningPool = StartCoroutine(CoUpdateSpaningPool());
    }
    IEnumerator CoUpdateSpaningPool()
    {
        while (true)
        {
            int monsterCount = Managers.Object.Monsters.Count;
            if (_maxMonsterCount <= monsterCount)
                continue;

            Vector3 randPos = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
            MonsterController mc = Managers.Object.Spawn<MonsterController>(randPos, Random.Range(0, 2));

            yield return new WaitForSeconds(_monsterInterval);
        }
    }

}
