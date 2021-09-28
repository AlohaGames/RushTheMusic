using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class EnemyInstantier : Singleton<EnemyInstantier>
    {
        [SerializeField] private List<GameObject> EnemyPrefabs;

        public GameObject InstantiateEnemy(int id, int hp)
        {
            GameObject instance = Instantiate(EnemyPrefabs[id]);
            instance.GetComponent<Enemy>().Init(hp);
            return instance;
        }

        public GameObject InstantiateEnemy(EnemyType type, int hp)
        {

            return InstantiateEnemy((int) type, hp);
        }


    }
    public enum EnemyType
    {
        generic = 0
    }
}