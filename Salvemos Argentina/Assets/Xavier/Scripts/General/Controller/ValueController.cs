using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ValueController<T> {
    [SerializeField] private T _value;
    public T Value { get => _value;
        set {
            _value = value;
        }
    }
}
