using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentA : MonoBehaviour
{
    void Awake()
    {
        MyTools.LOG(this, "Awake");
    }

    void OnEnable()
    {
        MyTools.LOG(this, "OnEnable");
    }
    void OnDisable()
    {
        MyTools.LOG(this, "OnEnable");
    }

    void OnDestroy()
    {
        MyTools.LOG(this, "OnDestroy");
    }
    
    void Start()
    {
        MyTools.LOG(this, "Start");
    }

    void Update()
    {
        MyTools.LOG(this, "Update");
    }

    void FixedUpdate()
    {
        MyTools.LOG(this, "FixedUpdate");
    }

    void LateUpdate()
    {
        MyTools.LOG(this, "LateUpdate");
    }
}
