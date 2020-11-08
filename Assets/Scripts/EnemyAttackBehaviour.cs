using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnemyAttackBehaviour : MonoBehaviour
{
    public Transform PlayerPosition;
    public float damage;
    public float loadingTime;
    public float Speed;
    public Image SliderBar;
    public bool vulnurable;
    public bool kiri;
    


    private void OnEnable()
    {       
        loadingTime = 2;
        vulnurable = true;
        gameObject.transform.localScale = new Vector3(2, 2, 2);
        StartCoroutine(ieTimingAttack());
        
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ieTimingAttack()
    {
        float maxloadtime = loadingTime;
        while (loadingTime>0)
        {
            loadingTime -= Time.deltaTime;
            SliderBar.fillAmount = loadingTime / maxloadtime;
            yield return new WaitForEndOfFrame();
        }
        vulnurable = false;
        Tweener moveTween = transform.DOMove(PlayerPosition.transform.position, 1);
        Tweener scaleTween = transform.DOScale(new Vector3(.6f, .6f, .6f), 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);

        }
    }
}
