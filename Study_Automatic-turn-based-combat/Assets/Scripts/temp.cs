using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    private Vector3 _attackLeftPosition = new Vector3(1f, 0.5f, -1f);
    private Vector3 _position = new Vector3(-2.5f, 0.5f, -1f);

    private WaitForSeconds _waitAttack = new WaitForSeconds(1f);

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        StartCoroutine(AAA());
    }

    // Update is called once per frame
    void Update()
    {
        // _rigidbody.velocity = Vector3.right * 1.5f;
    }

    private IEnumerator AAA()
    {
        while (true)
        {
            if (transform.position.x >= _attackLeftPosition.x)
            {
                _rigidbody.velocity = Vector3.zero;
                break;
            }
            else
            {
                _rigidbody.velocity = Vector3.right * 1.5f;
            }

            yield return null;
        }

        yield return _waitAttack;

        while (true)
        {
            if (transform.position.x <= _position.x)
            {
                _rigidbody.velocity = Vector3.zero;
                yield break;
            }
            else
            {
                _rigidbody.velocity = -Vector3.right * 3f;
            }

            yield return null;
        }
    }
}
