using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageTaker : MonoBehaviour {
    public float Health { get; private set; }
    public float MaxHealth { get; private set; }
    public virtual void Init(float health) {
        MaxHealth = Health = health;
    }
    public void TakeDamage(float damage) {
        var effectiveDamage = EffectiveDamage(damage);
        Health -= effectiveDamage;
        OnDamageTaken(effectiveDamage);
        Debug.Log("Oof");
        if (Health <= 0)
            Die();
    }
    protected virtual float EffectiveDamage(float damage) {
        return damage;
    }
    public virtual void Die() {
        Destroy(gameObject);
    }
    protected virtual void OnDamageTaken(float amount) {
    }
}
