using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackLightening : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Trigger lightening + sparks
        GameObject.Find("Monster attack").transform.Find("LightningBolt").gameObject.SetActive(true);
        GameObject.Find("Monster attack").transform.Find("Thunder Sound").gameObject.GetComponent<AudioSource>().Play();

        animator.SetBool("MonsterRunAway", true);
        GameObject.Find("Monster attack").transform.Find("Monster").gameObject.transform.Find("Monster scream").gameObject.GetComponent<AudioSource>().Play();
        GameObject.Find("9 - Ah2").gameObject.GetComponent<AudioSource>().Play();

        //Delay to deactivate the lightning
        animator.gameObject.GetComponent<MonoBehaviour>().StartCoroutine(DeactivateLightningAfterDelay());
    }
    private IEnumerator DeactivateLightningAfterDelay()
    {
        yield return new WaitForSeconds(0.7f);
        GameObject.Find("Monster attack").transform.Find("LightningBolt").gameObject.SetActive(false);
        GameObject.Find("Monster attack").transform.Find("Invisible Barrier").gameObject.SetActive(false);
    }
}
