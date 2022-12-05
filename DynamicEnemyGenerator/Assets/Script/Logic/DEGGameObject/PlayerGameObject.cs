using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DEGGameObject
{
    public class PlayerGameObject : MonoBehaviour
    {
        public float Damage;
        public float HP;
        public float AttackFreq;
        public float AttackRange;
        public float MoveSpeed;

        public bool isDamaged = false;
        public bool isDead = false;

        private void Awake()
        {
#if UNITY_EDITOR
            PlayerScriptableObject playerScript = ScriptableObject.CreateInstance<PlayerScriptableObject>();
            SerializedObject so = new SerializedObject(playerScript);
            Damage = so.FindProperty("Damage").floatValue;
            HP = so.FindProperty("HP").floatValue;
            AttackFreq = so.FindProperty("AttackFreq").floatValue;
            AttackRange = so.FindProperty("AttackRange").floatValue;
            MoveSpeed = so.FindProperty("MoveSpeed").floatValue;
#endif
        }

        public void TakeDamage(float damage)
        {
            if (HP > 0)
            {
                HP -= damage;
            }
            if (HP < 0)
            {
                HP = 0;
            }
            isDamaged = true;
        }
        public class PlayerScriptableObject : ScriptableObject
        {
            public float Damage = 10f;
            public float HP = 100f;
            public float AttackFreq = 2f;
            public float AttackRange = 1f;
            public float MoveSpeed = 2f;
        }
    }
}

