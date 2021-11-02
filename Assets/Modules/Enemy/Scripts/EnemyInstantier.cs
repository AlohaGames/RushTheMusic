using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class EnemyInstantier : Singleton<EnemyInstantier>
    {
        [SerializeField]
        private List<GameObject> EnemyPrefabs = new List<GameObject>();

        public GameObject InstantiateEnemy(int id)
        {
            GameObject instance = Instantiate(EnemyPrefabs[id]);
            Entity enemy = instance.GetComponent<Entity>();
            enemy.Init();
            return instance;
        }

        public GameObject InstantiateEnemy(EnemyType type)
        {

            return InstantiateEnemy((int) type);
        }


    }
    public enum EnemyType
    {
        generic = 0,
        lancer = 1
    }
}
