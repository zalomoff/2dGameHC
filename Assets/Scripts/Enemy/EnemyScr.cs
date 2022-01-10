using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyScr : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _rewads;

    private Player _target;

    public event UnityAction<EnemyScr> Dying;
    public int Rewards => _rewads;
    

    public Player Target => _target;
    public void Init(Player target)
    {
        _target = target;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Dying?.Invoke(this);
            Destroy(gameObject);
        }
    }



}
