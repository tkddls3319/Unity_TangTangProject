using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyWave : RepeatSkill
{
    private void Awake()
    {
        SkillType = Define.SkillType.EnergyWave;
    }

    protected override void DoSkillJob()
    {
        StartCoroutine(SetEnergeBolt());
    }
    IEnumerator SetEnergeBolt()
    {
        if (Managers.Game.Player != null)
        {
            List<MonsterController> targets = Managers.Object.GetNearsMonster(SkillData.ShotCount);
            if (targets == null)
                yield break;

            foreach (MonsterController target in targets)
            {
                Vector3 dir = (target.CenterPosition - Managers.Game.Player.CenterPosition).normalized;
                Vector3 startPos = Managers.Game.Player.CenterPosition;

                GenerateProjectile(Owner, startPos, dir, target.CenterPosition, this);

                yield return new WaitForSeconds(SkillData.ShotTime);
            }
        }
    }
}
