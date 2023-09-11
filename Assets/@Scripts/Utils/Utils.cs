using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : Object
    {
        if (go == null)
            return null;

        if (recursive == false)
        {
            Transform transform = go.transform.Find(name);
            if (transform != null)
                return transform.GetComponent<T>();
        }
        else
        {
            foreach (T componenet in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || componenet.name == name)
                    return componenet;
            }
        }
        return null;
    }

    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);

        if (transform != null)
            return transform.gameObject;

        return null;
    }
    public static Vector2 GenerateMonsterSpawnPosition(Vector2 characterPosition, float minSpawnDistance = 20f, float maxSpawnDistance = 25f)
    {
        float angle = Random.Range(0, 360) * Mathf.Deg2Rad;
        float distance = Random.Range(minSpawnDistance, maxSpawnDistance);

        float xDist = Mathf.Cos(angle) * distance;
        float yDist = Mathf.Sin(angle) * distance;

        // 원 모양으로 생성
        Vector2 spawnPosition = characterPosition + new Vector2(xDist, yDist);

        // 맵 경계를 벗어나는 경우 타원 모양으로 생성
        float size = /*Managers.Game.CurrentMap.MapSize.x*/10 * 0.5f;
        if (Mathf.Abs(spawnPosition.x) > size || Mathf.Abs(spawnPosition.y) > size)
        {
            float ellipseFactorX = Mathf.Lerp(1f, 0.5f, Mathf.Abs(characterPosition.x) / size);
            float ellipseFactorY = Mathf.Lerp(1f, 0.5f, Mathf.Abs(characterPosition.y) / size);

            xDist *= ellipseFactorX;
            yDist *= ellipseFactorY;

            spawnPosition = Vector2.zero + new Vector2(xDist, yDist);

            // 생성 위치를 맵 사이즈 범위 내로 조정
            spawnPosition.x = Mathf.Clamp(spawnPosition.x, -size, size);
            spawnPosition.y = Mathf.Clamp(spawnPosition.y, -size, size);
        }

        return spawnPosition;

    }

}
