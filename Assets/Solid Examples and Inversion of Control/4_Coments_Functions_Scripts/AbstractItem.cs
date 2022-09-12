using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public abstract class AbstractItem : MonoBehaviour
{
    public ItemTypes Type;

    protected abstract void OnCollisionEnter2D(Collision2D other);
}