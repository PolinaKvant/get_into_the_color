using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    public float AttackRange => _attackRange;
    private Player _player;
    public void TryAttackPlayer()
    {

    }
    void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    void Update()
    {
        
    }
}
