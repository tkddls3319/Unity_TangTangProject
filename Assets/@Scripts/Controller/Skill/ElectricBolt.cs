using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBolt : RepeatSkill
{
    private void Awake()
    {
        //todo : 타입정의 다시
        SkillType = Define.SkillType.ElectricBolt;
    }

    protected override void DoSkillJob()
    {
        StartCoroutine(SetEnergeBolt());
    }
    IEnumerator SetEnergeBolt()
    {
        if (Managers.Game.Player != null)
        {
            List<MonsterController> targets = Managers.Object.GetNearsMonster();
            if (targets == null)
                yield break;

            foreach (MonsterController target in targets)
            {
                Vector3 dir = Managers.Game.Player.MoveDir;
                Vector3 startPos = Managers.Game.Player.CenterPosition;

                GenerateProjectile(Owner, startPos, dir, target.CenterPosition, this);

                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
