using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace I2743
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class ObjectCollisionController : MonoBehaviour
    {
        EnemyPatrol[] allEnemies;

        [Space(15)]
        public UnityEvent collision;

        private void Awake()
        {
            allEnemies = FindObjectsOfType<EnemyPatrol>();
        }

        public void SetVelocityForAllEnemies(float value)
        {
            foreach (EnemyPatrol item in allEnemies)
                item.EnemyVelocity = value;
        }

        private void OnValidate()
        {
            if (GetComponent<Collider2D>().isTrigger == false)
                GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
