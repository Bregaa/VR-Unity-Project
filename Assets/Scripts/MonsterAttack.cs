using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    private Animator animator; 
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void monsterAttackTrigger()
    {
        animator.SetBool("MonsterAttack", true);
        this.gameObject.transform.Find("Monster breathing").gameObject.GetComponent<AudioSource>().Play();
    }
}
