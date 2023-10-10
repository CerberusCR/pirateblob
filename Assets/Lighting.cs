using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour
{
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Die", waitTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Die (float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);
    }
}
