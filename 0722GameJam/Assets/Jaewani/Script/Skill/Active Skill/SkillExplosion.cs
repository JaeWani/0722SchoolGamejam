using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillExplosion : MonoBehaviour
{
    public GameObject ExplosionParticle;
    void Start()
    {
        Destroy(gameObject,0.2f);
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            ExplosionDamage(transform.position, transform.localScale.x);
        }
    }
    private void ExplosionDamage(Vector2 center, float radius)
    {
            Instantiate(ExplosionParticle, transform.position, Quaternion.identity);
            var hitColliders = Physics2D.OverlapCircleAll(center, radius);

            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].TryGetComponent(out Block block))
                    block.blockStat.blockHp -= (GameManager.instance.Ball.GetComponent<Ball>().ballStat.ballDamage * 2);
            }
            Destroy(gameObject);
    }
    
}
