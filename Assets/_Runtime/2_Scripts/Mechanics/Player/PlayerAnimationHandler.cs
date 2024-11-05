using System.Collections;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
	private Player player;

	private Animator animator;

	private float movementType;

	private float stanceType = 1f;

	private Coroutine cor;

	private void Start()
	{
		player = GetComponent<Player>();
		animator = player.refs.animator;
	}

	private void Update()
	{
		HandleAnimationTarget();
		SetAnimatorValues();
	}

	private void SetAnimatorValues()
	{
		animator.SetBool("Move", player.input.movementInput.magnitude > 0.2f);
		animator.SetBool("Is Grounded", player.data.groundBelow);
		animator.SetFloat("Fall Speed", player.refs.ragdoll.GetBodypart(BodypartType.Hip).rig.velocity.y);
		animator.SetFloat("MoveInputX", player.input.movementInput.x);
		animator.SetFloat("MoveInputY", player.input.movementInput.y);
		animator.SetBool("Crouch", player.data.isCrouching);
		animator.SetFloat("Rotation", player.refs.ragdoll.GetBodypart(BodypartType.Hip).rig.angularVelocity.y);
		if (player.data.isSprinting)
		{
			movementType = Mathf.Lerp(movementType, 1f, Time.deltaTime * 10f);
		}
		else
		{
			movementType = Mathf.Lerp(movementType, 0f, Time.deltaTime * 10f);
		}
		animator.SetFloat("MovementType", movementType);
		animator.SetBool("Holding Item", player.data.currentItem != null);
		if (player.data.isCrouching)
		{
			stanceType = Mathf.MoveTowards(stanceType, 0f, Time.deltaTime * 3f);
		}
		else
		{
			stanceType = Mathf.MoveTowards(stanceType, 1f, Time.deltaTime * 3f);
		}
		animator.SetFloat("StanceType", stanceType);
		animator.SetBool("Jump", player.input.jumpWasPressed);
		if (player.data.currentBed != null)
		{
			animator.SetFloat("Look Y", 0f);
		}
		else
		{
			animator.SetFloat("Look Y", player.data.lookDirection.y);
		}
	}

	private void HandleAnimationTarget()
	{
		if (player.data.physicsAreReady)
		{
			player.data.targetHeight = Vector3.Project(player.refs.ragdoll.GetBodypart(BodypartType.Head).animationTarget.transform.position - player.refs.animatorTransform.position, player.refs.animatorTransform.up).magnitude;
			player.refs.animatorTransform.rotation = HelperFunctions.GetRotationWithUp(player.data.lookDirection, -player.data.gravityDirection);
			player.refs.animatorTransform.rotation = Quaternion.Lerp(player.refs.animatorTransform.rotation, player.data.rotationOvveride, Mathf.Clamp01(player.data.rotationOvverideStr));
		}
	}

	internal void StartSleep()
	{
		animator.Play("Sleep");
	}

	internal void StopSleep()
	{
		animator.Play("Idle");
	}

	internal void PlayEmote(string emoteName, float emoteLength)
	{
		animator.SetBool("Emote", value: true);
		animator.Play(emoteName, 0, 0f);
		player.data.emoteTime = emoteLength;
		if (cor != null)
		{
			StopCoroutine(cor);
		}
		cor = StartCoroutine(DelayStopEmote(emoteLength));
		IEnumerator DelayStopEmote(float emoteLength)
		{
			yield return new WaitForSeconds(emoteLength);
			animator.SetBool("Emote", value: false);
			cor = null;
		}
	}

	internal void PlayAnimation(string animationName)
	{
		animator.Play(animationName);
	}
}
