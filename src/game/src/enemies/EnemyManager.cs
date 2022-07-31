using System;
using System.Collections.Generic;

namespace Elite
{
    public class EnemyGenerator : GameObject
    {

        public List<Enemy> enemies = new List<Enemy>();


        private int spawnDist = 300;

        private int enemiesSpawned = 0;

        private Vector3 lastPlayerPos = new Vector3(0,0,0);




        public override void Start()
        {
            visible = false;
        }

        public override void Update(float deltaTime)
        {
            // Despawn enemies if they're too far away
            /*
            for (int i = 0; i < enemies.Count; i++)
            {
                if(Engine.cameraPosition.SquaredDistanceTo(enemies[i].position) > 5000*5000)
                {
                    Engine.QueueDestruction(enemies[i]);
                }
            }
            */

            // Don't spawn more than 4 enemies
            if(enemies.Count > 3) return;


            if(lastPlayerPos.SquaredDistanceTo(Engine.cameraPosition) > spawnDist*spawnDist)
            {
                lastPlayerPos = Engine.cameraPosition;

                Enemy enemy;

                // After 3 enemies were spawned, the boss
                // can spawn as well.
                int upperBound = 2;
                if(enemiesSpawned > 2)
                {
                    upperBound = 3;
                }

                switch (Utils.RandomInt(0,upperBound))
                {
                    case 0:
                        enemy = InstanceEnemy(new Charger());

                        break;
                    case 1:
                        enemy = InstanceEnemy(new Stingray());

                        break;
                    case 2:
                        enemy = InstanceEnemy(new Boss());
                        
                        break;

                }

                enemiesSpawned++;

                spawnDist = Utils.RandomInt(500,1500);

                    
            }



        }


        public void DestroyEnemy(Enemy enemy)
        {
            enemies.Remove(enemy);
        }

        private Enemy InstanceEnemy(Enemy en)
        {
            Engine.Instance(en);
            enemies.Add(en);
            Engine.ChanageIndex(en,Engine.main.enemyLayer);

            en.position = Utils.RandomPositionExcludeCentre(50f,100f);

            return en;
            

        }




    }
}
