using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    WaitForSeconds wait = new WaitForSeconds(1f);

    private void Start()
    {
        IEnumerator delete = Delete();
        StartCoroutine(delete);
    }

    private IEnumerator Delete()
    {
        yield return wait;
        Destroy(gameObject);
    }
}
