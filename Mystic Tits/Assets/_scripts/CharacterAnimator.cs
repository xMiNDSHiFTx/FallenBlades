using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class CharacterAnimator : MonoBehaviour 
{
    #region Variables
    const float LocomotionAnimationSmoothTime = .1f;

    Animator animator;
    NavMeshAgent agent;
	#endregion
	
	#region Unity Methods
	void Start () 
	{
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
	}
	
	void Update () 
	{
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, LocomotionAnimationSmoothTime, Time.deltaTime);
	}
	#endregion
}
