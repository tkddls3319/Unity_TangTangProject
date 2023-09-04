using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillController : BaseController
{
    public SkillData Skilldata { get; set; }

    Coroutine _coDestroy;

    public void StartDestroy(float lifeTime)
    {
        SkillDestory();
        _coDestroy = StartCoroutine(CoDestroy(lifeTime));
    }
    public void SkillDestory()
    {
        if (_coDestroy != null)
        {
            StopCoroutine(_coDestroy);
            _coDestroy = null;
        }
    }
    IEnumerator CoDestroy(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);

        if (this.IsNotNullActive())
        {
            Managers.Object.Dspawn(this);
        }
    }
}
