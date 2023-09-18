using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    TextMeshPro _damageText;

    public void SetInfo(Vector2 pos, float damage = 0, float healAmount = 0, Transform parent = null)
    {

        _damageText = GetComponent<TextMeshPro>();
        transform.position = pos;

        if(healAmount > 0)
        {
            _damageText.text = $"{Mathf.RoundToInt(healAmount)}";
            _damageText.color = HexToColor("4EEE6F");
        }
        else
        {
            _damageText.text = $"{Mathf.RoundToInt(damage)}";
            _damageText.color = Color.white;
        }

        if(parent != null)
        {
            GetComponent<MeshRenderer>().sortingOrder = 321;
        }

        DamageAnimation();

    }
    public Color HexToColor(string color)
    {
        Color parsedColor;
        ColorUtility.TryParseHtmlString("#" + color, out parsedColor);

        return parsedColor;
    }
    void DamageAnimation()
    {
        Sequence seq = DOTween.Sequence();

        transform.localScale = new Vector3(0, 0, 0);

        seq.Append(transform.DOScale(1.3f, 0.3f).SetEase(Ease.InOutBounce))
                .Join(transform.DOMove(transform.position + Vector3.up, 0.3f).SetEase(Ease.Linear))
                .Append(transform.DOScale(1.0f, 0.3f).SetEase(Ease.InOutBounce))
                .Join(transform.GetComponent<TMP_Text>().DOFade(0, 0.3f).SetEase(Ease.InQuint))
                //.Append(GetComponent<TextMeshPro>().DOFade(0, 1f).SetEase(Ease.InBounce))
                .OnComplete(() =>
                {
                    Managers.Resource.Destroy(gameObject);
                });
    }

}
