using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    public float Health { get; private set; }
    public virtual void Init(float health) {
        Health = health;
    }
    public void TakeDamage(float damage) {
        Health -= EffectiveDamage(damage);
    }
    protected virtual float EffectiveDamage(float damage) {
        return damage;
    }
}
