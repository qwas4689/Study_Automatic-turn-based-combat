using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] private PlayerInfo _playerInfo;
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private PlayerDamge _playerDamge;

    [SerializeField] private GameObject _defenseProportionalBullet;
    [SerializeField] private GameObject _hugeBullet;
    [SerializeField] private GameObject _doubleBullet;

    private IEnumerator _textUpAndChangeColor;

    private const float FIXED_DAMAGE = 50f;

    private float _defenseProportionalAttackDamage;
    private float _hugeAttackDamage;
    private float _doubleAttackDamage;

    /// <summary>
    /// �ִ� ü���� 20%�� ȸ��
    /// </summary>
    public float Skill_Hill(PlayerInfo me)
    {
        me.PlayerHP += me.MaxHP * 0.2f;

        _textUpAndChangeColor = _playerDamge.TextUpAndChangeColor(Color.green);

        StartCoroutine(_textUpAndChangeColor);

        return me.MaxHP * 0.2f;
    }

    /// <summary>
    /// �⺻ ����� 50 + �ڽ��� ������ 10% �� ����
    /// </summary>
    public float Skill_DefenseProportionalAttack(Collider enemy)
    {
        _defenseProportionalAttackDamage = FIXED_DAMAGE + enemy.GetComponentInParent<PlayerInfo>().PlayerDefensivePower * 0.1f;

        return _defenseProportionalAttackDamage;
    }
    public void Skill_DefenseProportionalAttack()
    {
        _defenseProportionalBullet.SetActive(true);
    }


    /// <summary>
    /// ���ݷ��� 130%�� ����
    /// </summary>
    public float Skill_HugeAttack(Collider enemy)
    {
        _hugeAttackDamage = enemy.GetComponentInParent<PlayerInfo>().PlayerDamage * 1.3f;

        return _hugeAttackDamage;
    }
    public void Skill_HugeAttack()
    {
        _hugeBullet.SetActive(true);
    }

    /// <summary>
    /// ���ݷ��� 90%�� ���ظ� �ι� ����
    /// </summary>
    public float Skill_DoubleAttack(Collider enemy)
    {
        _doubleAttackDamage = enemy.GetComponentInParent<PlayerInfo>().PlayerDamage * 1.8f;

        return _doubleAttackDamage;
    }
    public void Skill_DoubleAttack()
    {
        _doubleBullet.SetActive(true);
    }
}
