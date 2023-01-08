using UnityEngine;

namespace SlimeProject_Combat
{
    public class FireBall_Effects : Projectiles_Effect
    {
        [SerializeField] Projectiles_DataBase dataBase;
        public override void EffectAfterTouch(Vector3 position, Transform target)
        {
                Instantiate(GetComponent<Projectiles_Effect>().explosionPrefab, this.transform.position, Quaternion.identity);

            //一定機率生燃燒效果
            //產生爆炸效果
        }
    }
}