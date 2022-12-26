using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerDamge : MonoBehaviour
{
    [SerializeField] private PlayerInfo _playerInfo;
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private TextMeshProUGUI _damageText;

    private IEnumerator _textUpAndChangeColor;

    private Vector2 _textPos = new Vector2(0f, 0.3f);
    private Vector2 _textMoveVector = new Vector2(0f, 0.005f);
    private Color _color = new Color(0f, 0f, 0f, 0.005f);

    private Action _hit;

    private void Start()
    {
        _hit = Hit;
    }

    private void Hit()
    {
        _textUpAndChangeColor = TextUpAndChangeColor();
        StartCoroutine(_textUpAndChangeColor);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Bullet"))
        {
            _playerInfo.PlayerHP -= other.GetComponentInParent<PlayerInfo>().PlayerDamage;
            _damageText.text = other.GetComponentInParent<PlayerInfo>().PlayerDamage.ToString();
            _hit.Invoke();
        }
    }

    private IEnumerator TextUpAndChangeColor()
    {
        while (true)
        {
            if (_damageText.color.a <= 0f)
            {
                _damageText.rectTransform.anchoredPosition = _textPos;
                _damageText.color = Color.black;
                _damageText.text = null;
                yield break;
            }
            else
            {
                _damageText.rectTransform.anchoredPosition += _textMoveVector;
                _damageText.color -= _color;
            }
            
            yield return null;
        }
    }
}
