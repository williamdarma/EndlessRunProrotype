using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager enemyinstance;
    public Transform[] SpawnProjectile;
    public GameObject EnemyProjectile;
    public int JumlahAttack = 10;
    public List<GameObject> listenemyAttack = new List<GameObject>();
    bool enemyAlive;
    // Start is called before the first frame update
    void Start()
    {
        enemyinstance = this;
        enemyAlive = true;
        initializeEnemyAttack();
        StartCoroutine(ieEnemyAttackPattern());
    }

    void initializeEnemyAttack()
    {
        for (int i = 0; i < JumlahAttack; i++)
        {
            GameObject temp = Instantiate(EnemyProjectile);
            listenemyAttack.Add(temp);
            temp.SetActive(false);
        }
    }

    GameObject SpawnedenemyAttack()
    {
        for (int i =0; i < listenemyAttack.Count;i++)
        {
            if (!listenemyAttack[i].activeInHierarchy)
            {
                return listenemyAttack[i];
            }
        }
        return null;
    }

    public void EnemyAttack(int TipeAttack)
    {
        if (TipeAttack==0)
        {
            GameObject temp = SpawnedenemyAttack();
            int tempint = Random.Range(0, SpawnProjectile.Length);
            temp.transform.position = SpawnProjectile[tempint].position;
            temp.SetActive(true);
        }
        else
        {
            for (int i = 0; i < SpawnProjectile.Length; i++)
            {
                GameObject temp = SpawnedenemyAttack();
                temp.transform.position = SpawnProjectile[i].position;
            }
        }
    }



    IEnumerator ieEnemyAttackPattern()
    {
        yield return new WaitForSeconds(5f);
        while (enemyAlive)
        {
            int tempint = Random.Range(3, 6);
            yield return new WaitForSeconds(tempint);
            EnemyAttack(0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
