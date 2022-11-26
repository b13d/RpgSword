using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour
{
    float time = 3f;
    public ProjectileLaunch projectile;

    private void FixedUpdate()
    {
        time -= Time.deltaTime;

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //
            //.Log("œŒ »Õ”À »√–Œ ¿ œŒ »Õ”À »√–Œ ¿!!!!!!!!");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

            if (collision.tag == "Player")
            {
              transform.parent.transform.GetComponent<Animator>().SetTrigger("Attack");

            if (!projectile)
                projectile = collision.transform.GetComponent<MainPlayer>().projectile;

            }

            if (time < 0 && projectile)
            {
                projectile.enemyTransform = transform;
                projectile.projectileLaunched = true;
            time = 3f;
            }
        }
    }

