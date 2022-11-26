using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{


    public bool projectileLaunched;
    float time = 0f;
    public Transform playerTransform, enemyTransform;
    public GameObject projectile, placeAllProjectile;
    public List<GameObject> projectileList = new List<GameObject>();
    public List<Vector3> lastPosPlayer = new List<Vector3>();
    public List<Vector3> firstPosProjectile = new List<Vector3>();
    List<GameObject> DestroyProjectile;



    private void Update()
    {
        if (ParametrsPlayer.lvlUP == false)
            playerTransform = playerTransform.GetComponent<Transform>();

    }


    void FixedUpdate()
    {
        if (ParametrsPlayer.lvlUP == false)
        {
            time -= Time.deltaTime;

            DeleteProjectile();


            if (projectileLaunched == true)
            {
                time = 3f;
                projectileLaunched = false;
                if (enemyTransform != null && playerTransform != null)
                {
                    if (enemyTransform.position != playerTransform.position)
                    {
                        var dist = Vector2.Distance(playerTransform.position, enemyTransform.position);


                        projectileList.Add(Instantiate(projectile, enemyTransform.position, Quaternion.identity, placeAllProjectile.transform));
                        lastPosPlayer.Add(playerTransform.position);
                        firstPosProjectile.Add(projectileList[projectileList.Count - 1].transform.position);


                        projectileList[projectileList.Count - 1].transform.rotation = Quaternion.Euler(projectileList[projectileList.Count - 1].transform.rotation.eulerAngles.x, 
                            projectileList[projectileList.Count - 1].transform.rotation.eulerAngles.y, Mathf.Atan2(playerTransform.position.y - projectileList[projectileList.Count - 1].transform.position.y,
                                playerTransform.position.x - projectileList[projectileList.Count - 1].transform.position.x) * Mathf.Rad2Deg); // ÝÒÎ ÐÀÁÎÒÀÅÒ!!!! ÏÎÂÎÐÎÒ ÌÀÃÈ×ÅÑÊÎÃÎ ØÀÐÀ Â ÑÒÎÐÎÍÓ ÈÃÐÎÊÀ

                    }
                }

            }

            if (projectileList.Count > 0)
            {
                for (int i = 0; i < projectileList.Count; i++)
                {



                    if (projectileList[i].transform.position == lastPosPlayer[i])
                    {
                        lastPosPlayer[i] += lastPosPlayer[i] - firstPosProjectile[i];
                    }
                    else
                        projectileList[i].transform.position = Vector2.MoveTowards(projectileList[i].transform.position, lastPosPlayer[i], Time.deltaTime * 2f); // ÒÓÒ ÎØÈÁÊÀ


                }
            }
        }

        
    }



    void DeleteProjectile()
    {
        if (projectileList.Count > 10)
        {
            for (int i = 0; i < projectileList.Count; i++)
            {
                if (Mathf.Abs(projectileList[i].transform.position.x) - Mathf.Abs(playerTransform.position.x) > 10|| Mathf.Abs(projectileList[i].transform.position.y) - Mathf.Abs(playerTransform.position.y) > 10)
                {
                    Destroy(projectileList[i].gameObject);
                    projectileList.Remove(projectileList[i]);
                    firstPosProjectile.Remove(firstPosProjectile[i]);
                    lastPosPlayer.Remove(lastPosPlayer[i]);
                }
            }
        }
    }



}
