using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject ExplosionParticle;
    public bool CanExplosion = true;
    public float ExplosionDmg = 0.3f;
    void Start()
    {

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
        if (CanExplosion == true) 
        {
            Instantiate(ExplosionParticle, transform.position, Quaternion.identity);
            var hitColliders = Physics2D.OverlapCircleAll(center, radius);

            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].TryGetComponent(out Block block))
                    block.blockStat.blockHp -= (GameManager.instance.Ball.GetComponent<Ball>().ballStat.ballDamage * ExplosionDmg);
            }
            StopAllCoroutines();
            StartCoroutine(ExplosionDelay());
            Destroy(gameObject);
        }
    }
    WaitForSecondsRealtime wait = new WaitForSecondsRealtime(0.01f);
    IEnumerator ExplosionDelay() 
    {
        CanExplosion = false;
        yield return wait;
        CanExplosion = true;
    }
}
