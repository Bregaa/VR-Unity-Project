using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlamethrowerEmission : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform flamesTransform = animator.gameObject.transform.Find("canon_lvl_1").Find("gunpoint").Find("Flames");
        flamesTransform.GetComponent<ParticleSystem>().Play();
        flamesTransform.GetComponent<AudioSource>().Play();

        animator.gameObject.transform.Find("Flames area").GetComponent<BoxCollider>().enabled = true;

        animator.SetBool("flameThrowerActive", false);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject.Find("Flamethrowers game").GetComponent<FlamethrowersGameController>().nextRound();
    }
}
