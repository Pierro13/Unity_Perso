using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        MeshRenderer mr = collision.gameObject.GetComponent<MeshRenderer>();
        if (mr)
        {
            mr.material.color = Random.ColorHSV();
        }
    }
}