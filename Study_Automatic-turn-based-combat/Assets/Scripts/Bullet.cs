using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Side = Defines.EBattleSide;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Side _side;

    WaitForSeconds wait = new WaitForSeconds(1f);

    private Rigidbody _rigidbody;

    private Vector3 _bulletPos = new Vector3(0.8f, 0f, 0f);

    private IEnumerator delete;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        delete = Delete();
        StartCoroutine(delete);
    }

    private IEnumerator Delete()
    {
        _rigidbody.velocity = _side == 0 ? Vector3.right * 0.5f : Vector3.left * 0.5f;
        yield return wait;
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        StopCoroutine(delete);
        gameObject.transform.position = _side == 0 ? transform.parent.position + _bulletPos : transform.parent.position + _bulletPos * -1f;
    }
}
