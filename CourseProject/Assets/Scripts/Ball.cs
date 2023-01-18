using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] LayerMask m_ColorizableLayerMask;
    private void OnCollisionEnter(Collision collision)
    {

        // IDENTIFICATION PAR CHAINE DE CARACTERES
        //if(collision.gameObject.name.ToUpper().Contains("CUBE"))
        //{
        //    MyTools.ColorizeRandom(collision.gameObject);
        //}

        // IDENTIFICATION PAR TAG
        //if (collision.gameObject.tag == "Colorizable")
        //{
        //    MyTools.ColorizeRandom(collision.gameObject);
        //}

        // IDENTIFICATION PAR LAYER
        //if ((m_ColorizableLayerMask.value & (1 << collision.gameObject.layer)) != 0)
        //{
        //    MyTools.ColorizeRandom(collision.gameObject);
        //}

        // IDENTIFICATION PAR COMPONENT TAG
        //if (null != collision.gameObject.GetComponent<ColorizableTag>())
        //{
        //    MyTools.ColorizeRandom(collision.gameObject);
        //}

        // IDENTIFICATION PAR INTERFACE
        IDestroyable destroyable = collision.gameObject.GetComponent<IDestroyable>();
        if (null != destroyable)
        {
            destroyable.Kill();
        }
    }
}