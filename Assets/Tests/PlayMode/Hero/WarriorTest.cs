namespace Aloha.Test
{
    public class WarriorTest
    {
        [Test]
        public void WarriorRageTakeDamageRegenerationTest(){
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats stats = (WarriorStats)ScriptableObject.CreateInstance("WarriorStats");
            stats.maxRage = 10;
            stats.maxHealth = 10;
            stats.attack = 10;
            stats.defense = 10;
            stats.xp = 10;
            warrior.Init(stats);

            Assert.AreEqual(10, warrior.stats.maxRage);

            warrior.currentRage = 5;
            Assert.AreEqual(5, warrior.currentRage);

            warrior.TakeDamage(2);
            Assert.AreEqual(7, warrior.currentRage);

            GameObject.Destroy(warriorGO);
        }

        [Test]
        public void WarriorRageAttackTest(){
            GameObject warriorGO = new GameObject();
            Warrior warrior = warriorGO.AddComponent<Warrior>();
            WarriorStats stats = (WarriorStats)ScriptableObject.CreateInstance("WarriorStats");
            stats.maxRage = 10;
            stats.maxHealth = 10;
            stats.attack = 10;
            stats.defense = 10;
            stats.xp = 10;
            warrior.Init(stats);

            Assert.AreEqual(10, warrior.stats.maxRage);

            GameObject enemyGO = new GameObject();
            Enemy enemy = enemyGO.AddComponent<Enemy>();
            EnemyStats enemyStats = (EnemyStats)ScriptableObject.CreateInstance("EnemyStats");
            enemyStats.maxHealth = 100;
            enemy.Init(enemyStats);

            Assert.AreEqual(100, enemy.currentHealth);

            warrior.Attack(enemy);
            Assert.AreEqual(5, warrior.currentRage);
            Assert.AreEqual(88, enemy.currentHealth);

            GameObject.Destroy(enemyGO);
            GameObject.Destroy(warriorGO);
        }
    }
}