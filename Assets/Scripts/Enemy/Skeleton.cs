using System;
using Enemy.Interfaces;
using UnityEngine;

namespace Enemy
{
    public class Skeleton : Enemy, IMeleeEnemy
    {
        private void Start()
        {
            Debug.Log($"My name is {this.attributes.enemyName}");
        }

        public void MeleeAttack()
        {
            throw new NotImplementedException();
        }
    }
}