using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    WaitForSeconds wait = new WaitForSeconds(1f);

    private Rigidbody _rigidbody;

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
        _rigidbody.velocity = Vector3.right * 0.5f;
        yield return wait;
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        StopCoroutine(delete);
        gameObject.transform.position = Vector3.zero;
    }
}
