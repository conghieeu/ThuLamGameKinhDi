using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

	[Serializable]
	public class PlayerInput
	{
		public Vector2 movementInput;

		public Vector2 lookInput;

		public bool sprintWasPressed;

		public bool sprintIsPressed;

		public bool clickWasPressed;

		public bool clickIsPressed;

		public bool clickWasReleased;

		public bool aimWasPressed;

		public bool aimIsPressed;

		public bool jumpWasPressed;

		public bool jumpIsPressed;

		public bool crouchWasPressed;

		public bool crouchIsPressed;

		public bool dropItemWasPressed;

		public bool dropItemIsPressed;

		public bool dropItemWasReleased;

		public bool interactWasPressed;

		public bool escapeWasPressed;

		public bool emoteWasPressed;

		public bool emoteIsPressed;

		public bool toggleCameraFlipWasPressed;

		private MouseSensitivitySetting mouseSensitivitySetting;

		private InvertedMouseSetting invertedMouseSetting;

		public void SampeInput(PlayerData data, Player player)
		{
			ResetInput();
			movementInput = Vector2.zero;
			bool flag = data.strangledForSeconds > 0f;
			if (!player.HasLockedMovement())
			{
				if (GlobalInputHandler.WalkForwardKey.GetKey())
				{
					movementInput.y += 1f;
				}
				if (GlobalInputHandler.WalkBackwardKey.GetKey())
				{
					movementInput.y -= 1f;
				}
				if (GlobalInputHandler.WalkRightKey.GetKey())
				{
					movementInput.x += 1f;
				}
				if (GlobalInputHandler.WalkLeftKey.GetKey())
				{
					movementInput.x -= 1f;
				}
			}
			if (data.inputOverideAmount > 0.01f)
			{
				movementInput = Vector2.Lerp(movementInput, data.overrideMovementInput, data.inputOverideAmount);
			}
			if (GlobalInputHandler.CanTakeInput())
			{
				lookInput.y = Input.GetAxis("Mouse Y") * mouseSensitivitySetting.Value * invertedMouseSetting.GetFactor();
				lookInput.x = Input.GetAxis("Mouse X") * mouseSensitivitySetting.Value;
			}
			escapeWasPressed = GlobalInputHandler.GetKeyDown(KeyCode.Escape);
			if (!(data.inputOverideAmount > 0.99f))
			{
				if (!player.HasLockedMovement())
				{
					sprintWasPressed = GlobalInputHandler.SprintKey.GetKeyDown();
					sprintIsPressed = GlobalInputHandler.SprintKey.GetKey();
				}
				if (data.cantUseItemFor <= 0f)
				{
					clickWasPressed = GlobalInputHandler.GetKeyDown(KeyCode.Mouse0);
					clickIsPressed = GlobalInputHandler.GetKey(KeyCode.Mouse0);
					clickWasReleased = GlobalInputHandler.GetKeyUp(KeyCode.Mouse0);
				}
				if (!flag)
				{
					aimWasPressed = GlobalInputHandler.GetKeyDown(KeyCode.Mouse1);
					aimIsPressed = GlobalInputHandler.GetKey(KeyCode.Mouse1);
				}
				if (!player.HasLockedMovement() && !flag)
				{
					jumpWasPressed = GlobalInputHandler.JumpKey.GetKeyDown();
					jumpIsPressed = GlobalInputHandler.JumpKey.GetKey();
					crouchWasPressed = GlobalInputHandler.CrouchKey.GetKeyDown();
					crouchIsPressed = GlobalInputHandler.CrouchKey.GetKey();
				}
				if (!flag)
				{
					interactWasPressed = GlobalInputHandler.InteractKey.GetKeyDown();
					dropItemWasPressed = GlobalInputHandler.DropKey.GetKeyDown();
					dropItemWasReleased = GlobalInputHandler.DropKey.GetKeyUp();
					dropItemIsPressed = GlobalInputHandler.DropKey.GetKey();
					emoteWasPressed = GlobalInputHandler.EmoteKey.GetKeyDown();
					emoteIsPressed = GlobalInputHandler.EmoteKey.GetKey();
				}
				toggleCameraFlipWasPressed = GlobalInputHandler.ToggleSelfieModeKey.GetKeyDown();
			}
		}

		internal void ResetInput()
		{
			movementInput = Vector2.zero;
			lookInput.y = 0f;
			lookInput.x = 0f;
			sprintWasPressed = false;
			sprintIsPressed = false;
			clickWasPressed = false;
			clickIsPressed = false;
			aimWasPressed = false;
			aimIsPressed = false;
			jumpWasPressed = false;
			jumpIsPressed = false;
			crouchWasPressed = false;
			crouchIsPressed = false;
			interactWasPressed = false;
			dropItemWasPressed = false;
			dropItemWasReleased = false;
			dropItemIsPressed = false;
			emoteWasPressed = false;
			emoteIsPressed = false;
			toggleCameraFlipWasPressed = false;
		}

		public void Initialize()
		{
			mouseSensitivitySetting = GameHandler.Instance.SettingsHandler.GetSetting<MouseSensitivitySetting>();
			invertedMouseSetting = GameHandler.Instance.SettingsHandler.GetSetting<InvertedMouseSetting>();
		}
	}

	[Serializable]
	public class PlayerData
	{
		public AnimationCurve oxygenDisplayCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		public bool tasable = true;

		public float simplifiedColliderHeight = 0.5f;

		public float simplifiedColliderRadius = 1f;

		public bool simplifiedRagdoll;

		public bool playerIsInRealm;

		public Vector3 gravityDirection = Vector3.down;

		public Player player;

		public bool dead;

		public float sinceDied = 1000f;

		public bool isGrounded;

		public float sinceGrounded;

		public float groundHeight;

		public Vector3 groundPos;

		public float sinceJump;

		public float distanceToGround;

		public float groundAngle;

		public float totalMass;

		public float headHeight;

		public Vector2 playerLookValues;

		public Vector3 movementVector;

		public Vector3 groundNormal;

		public Vector3 lookDirection;

		public Vector3 lookDirectionUp;

		public Vector3 lookDirectionRight;

		public bool isCrouching;

		public float crouchingFor;

		public float sinceCrouchSwitch;

		public bool isLocal = true;

		public float health = 100f;

		public static float maxHealth = 100f;

		public bool playerSetUpAndReady;

		public bool isSprinting;

		public float cameraPhysicsAmount;

		public float damageFeedback;

		public float targetHeight;

		public ItemInstance currentItem;

		public bool physicsAreReady;

		public int selectedItemSlot = -1;

		public int nrOfGroundCols;

		public string groundTag;

		public bool groundBelow;

		public List<Bot> fearList = new List<Bot>();

		public bool carried;

		public bool hookedIntoTerminal;

		public float inputOverideAmount;

		public Vector2 overrideMovementInput = Vector2.zero;

		public float possession;

		public Vector3 lastSimplifiedPosition;

		public float remainingOxygen = 500f;

		public float maxOxygen = 500f;

		public bool usingOxygen = true;

		public float microphoneValue;

		public float throwCharge;

		public Quaternion rotationOvveride;

		public float rotationOvverideStr;

		public float jelloTime;

		public float fallTime;

		public float tazeTime;

		public float sinceGotBackUp;

		public float physicsCameraTime;

		public bool isInCostomizeTerminal;

		public bool isInTitleCardTerminal;

		public bool isSnatched;

		public float dropItemsFor;

		public bool isHangingUpsideDown;

		public float currentStamina;

		public bool staminaDepleated;

		public float sinceSprint;

		public Bed currentBed;

		public float sleepAmount;

		public float triedToSleepTime;

		public bool rested;

		public bool isInDiveBell;

		public int framesSinceBotTeleport;

		public float emoteTime;

		public float cantUseItemFor;

		public float voiceVolumeModifier = 1f;

		public bool looksLikeShroomMonster;


		public float sinceRescueDragged = 10f;

		public float inWaterAmount;


		public float sinceTrampoline;

		public float strangledForSeconds;

		public float movementSlowFactor;

		public bool forceAimPressed;

		public void UpdateValues_Fixed()
		{
			sinceTrampoline += Time.deltaTime;
			movementSlowFactor = Mathf.MoveTowards(movementSlowFactor, 1f, Time.fixedDeltaTime);
			strangledForSeconds -= Time.fixedDeltaTime;
			framesSinceBotTeleport++;
			if (!isSprinting)
			{
				sinceSprint += Time.deltaTime;
			}
			else
			{
				sinceSprint = 0f;
			}
			sinceRescueDragged += Time.fixedDeltaTime;
			inWaterAmount = Mathf.MoveTowards(inWaterAmount, 0f, Time.fixedDeltaTime);
			dropItemsFor -= Time.fixedDeltaTime;
			_ = fallTime;
			fallTime -= Time.fixedDeltaTime;
			if (fallTime > 0f)
			{
				sinceGotBackUp = 0f;
			}
			else
			{
				sinceGotBackUp += Time.fixedDeltaTime;
			}
			tazeTime -= Time.fixedDeltaTime;
			for (int num = recentDamage.Count - 1; num >= 0; num--)
			{
				if (recentDamage[num].ShouldRemove())
				{
					recentDamage.RemoveAt(num);
				}
			}
			physicsCameraTime -= Time.fixedDeltaTime;
			if (!isGrounded)
			{
				sinceGrounded += Time.fixedDeltaTime;
			}
			else
			{
				sinceGrounded = 0f;
			}
			if (isCrouching)
			{
				crouchingFor += Time.fixedDeltaTime;
			}
			else
			{
				crouchingFor = 0f;
			}
			sinceCrouchSwitch += Time.fixedDeltaTime;
			if (player.Ragdoll() || player.data.PhysicsCamera())
			{
				cameraPhysicsAmount = Mathf.Lerp(cameraPhysicsAmount, 1f, Time.fixedDeltaTime * 5f);
			}
			else
			{
				cameraPhysicsAmount = Mathf.Lerp(cameraPhysicsAmount, 0f, Time.fixedDeltaTime * 2f);
			}
			sinceJump += Time.fixedDeltaTime;
			rotationOvverideStr -= Time.fixedDeltaTime;
			_ = dead;
			if (dead)
			{
				sinceDied += Time.fixedDeltaTime;
			}
		}

		internal bool StandingStill()
		{
			return movementVector.magnitude < 0.1f;
		}

		internal void UpdateValues()
		{
			possession -= Time.deltaTime;
			jelloTime -= Time.deltaTime;
			emoteTime -= Time.deltaTime;
			cantUseItemFor -= Time.deltaTime;
			if (!rested && currentBed != null && (PlayerHandler.instance.PlayerVoiceVolumeAtPosition(player.Center(), 5f, 10f) < 0.8f || triedToSleepTime > 2f))
			{
				sleepAmount = Mathf.MoveTowards(sleepAmount, 1f, Time.deltaTime * 0.3f);
			}
			else
			{
				sleepAmount = Mathf.MoveTowards(sleepAmount, 0f, Time.deltaTime * 1f);
			}
			if (currentBed != null && PlayerHandler.instance.AllPlayersInBed())
			{
				triedToSleepTime += Time.deltaTime;
			}
			else
			{
				triedToSleepTime = 0f;
			}
			if (possession < 0f)
			{
				possession = 0f;
			}
			if (usingOxygen && !isInDiveBell)
			{
				remainingOxygen -= Time.deltaTime;
				if (remainingOxygen < maxOxygen * 0.5f && PhotonNetwork.IsMasterClient && PhotonGameLobbyHandler.CurrentObjective is FilmSomethingScaryObjective)
				{
					PhotonGameLobbyHandler.Instance.SetCurrentObjective(new ReturnToTheDiveBellObjective());
				}
			}
		}

		internal float OxygenPercentage()
		{
			return remainingOxygen / maxOxygen;
		}

		public float OxygenDisplayPercentage()
		{
			return oxygenDisplayCurve.Evaluate(OxygenPercentage());
		}

		public float CameraPhysicsAmount()
		{
			return cameraPhysicsAmount;
		}

		public bool PhysicsCamera()
		{
			if (emoteTime > 0f)
			{
				return true;
			}
			return physicsCameraTime > 0f;
		}

		internal void clampLookValues()
		{
			float x = playerLookValues.x;
			float num = Mathf.Sign(x);
			x = Math.Abs(x);
			x %= 360f;
			playerLookValues.x = x * num;
		}

		internal bool CanInteract()
		{
			if (!dead && !currentSeat)
			{
				return !currentBed;
			}
			return false;
		}
	}

	[Serializable]
	public class PlayerRefs
	{
		public PlayerRagdoll ragdoll;

		public PlayerAnimRefHandler animRefHandler;

		public GameObject rigRoot;

		public Animator animator;

		public Transform animatorTransform;

		public PlayerAnimationHandler animationHandler;

		public PlayerItems items;

		public Transform headPos;

		public Transform cameraPos;

		public PlayerInteraction interaction;

		public Rig IKRig;

		public TwoBoneIKConstraint IK_Right;

		public Transform IK_Hand_R;

		public TwoBoneIKConstraint IK_Left;

		public Transform IK_Hand_L;

		public PlayerController controller;

		public IKRigHandler ikHandler;

		public SkinnedMeshRenderer bodyMeshRenderer;

		internal SphereCollider simpleCollider;
	}

	public static Player localPlayer;

	public static Player observedPlayer;

	public bool ai;

	public PlayerInput input;

	public static bool justDied;

	public PlayerData data;

	public PlayerRefs refs;

	private float voiceNoiseCounter;

	private Coroutine toggleCollisionCor;

	private List<bool> collidersEnabled = new List<bool>();

	private List<Collider> collidersToToggleList = new List<Collider>();

	public bool IsLocal => this == localPlayer;

	private void Awake()
	{

	}

	private void CheckOxygen()
	{
		bool flag = SceneManager.GetActiveScene().name != "SurfaceScene";
		data.usingOxygen = flag;
		if (!flag)
		{
			data.remainingOxygen = data.maxOxygen;
		}
		if (ai)
		{
			data.usingOxygen = false;
		}
	}

	private void OnDestroy()
	{

	}

	private void LoadHat()
	{
		int equippedHat = PlayerPrefs.GetInt("EquippedHat", -1);
		if (equippedHat >= 0)
		{
			StartCoroutine(Wait());
		}
		IEnumerator Wait()
		{
			yield return 5;
			Call_EquipHat(equippedHat);
		}
	}

	private void DoInits()
	{
		refs.animRefHandler.DoInit();
		refs.ragdoll.DoInit();
	}

	private void Update()
	{
		Vector3 position = refs.ragdoll.GetBodypart(BodypartType.Hip).rig.position;
		if (float.IsNaN(position.x) || float.IsNaN(position.y) || float.IsNaN(position.z))
		{
			Debug.LogError("Player position is NaN");
			base.gameObject.SetActive(value: false);
			CallDie();
		}
		MakeVoiceNoise();
		if (Center().y < -100f || Center().y > 100f)
		{

			CallDie();

			refs.ragdoll.ExtraDrag(0f);
		}

		if (AllowInput())
		{
			input.SampeInput(data, this);
		}
		if (HasLockedInput())
		{
			input.ResetInput();
		}
		data.UpdateValues();

	}

	private void MakeVoiceNoise()
	{
		if (data.dead)
		{
			return;
		}
		voiceNoiseCounter += Time.deltaTime;
		if (!(voiceNoiseCounter < 0.1f))
		{
			voiceNoiseCounter = 0f;
			if (data.microphoneValue > 0.9f)
			{
				SFX_Player.instance.PlayNoise(Center(), 30f);
			}
		}
	}

	public bool HasLockedInput()
	{
		if (data.hookedIntoTerminal || data.isInCostomizeTerminal || data.isInTitleCardTerminal)
		{
			return true;
		}
		return false;
	}

	public bool HasLockedMovement()
	{
		if (refs.emotes.IsPlayingEmote)
		{
			return true;
		}
		return false;
	}

	private bool AllowInput()
	{
		if (!data.isLocal || ai)
		{
			return false;
		}
		if (HasLockedInput())
		{
			return false;
		}
		return true;
	}

	public void TakeDamageLocalIKnowWhatImDoing(float damage)
	{
		TakeDamage(damage);
	}

	private void TakeDamage(float damage)
	{
		if (!ai && !data.dead)
		{
			data.health -= damage;

			if (data.health <= 0f)
			{
				Die();
			}
		}
	}

	public bool CallHeal(float healAmount)
	{
		if (healAmount >= PlayerData.maxHealth)
		{
			return false;
		}

		return true;
	}

	private void RPCA_Heal(float amount)
	{
		if (!ai && !data.dead && !(data.health >= PlayerData.maxHealth))
		{
			data.health += amount;
			data.health = Mathf.Clamp(data.health, 0f, PlayerData.maxHealth);
			if (refs.view.IsMine)
			{

			}
		}
	}

	public static void KillLocal()
	{
		localPlayer.Die();
	}

	public void Die()
	{
		if (refs.view.IsMine && !data.dead && !ai)
		{

		}
	}

	internal void CallDie()
	{
		if (!data.dead && !ai)
		{

		}
	}

	public void CallRevive()
	{
		if (data.dead && !ai)
		{

		}
	}

	public void RPCA_PlayerDie()
	{
		Debug.Log("Player Died", this);
		data.dead = true;
		if (IsLocal)
		{
			justDied = true;
		}
		if (refs.view.IsMine)
		{
			StartCoroutine(DelayThenTalkToDead(3f));
			StartCoroutine(DelayDropItems());
		}
	}

	private IEnumerator DelayThenTalkToDead(float f)
	{
		yield return new WaitForSecondsRealtime(f);
		if (justDied)
		{

		}
	}

	private void RPCA_PlayerRevive()
	{
		Debug.LogError("REVIVED!");
		data.dead = false;
		data.health = 30f;
		if (refs.view.IsMine)
		{
			justDied = false;
		}
	}

	private IEnumerator DelayDropItems()
	{
		yield return new WaitForSeconds(3f);
		if (!TryGetInventory(out var o))
		{
			yield break;
		}
		List<ItemDescriptor> items = o.GetItems();
		o.Clear();
		foreach (ItemDescriptor item in items)
		{
			RequestCreatePickup(item.item, item.data, Center(), Quaternion.identity);
			Debug.Log("Dropping item because of death: " + item.item.name);
		}
	}

	private void FixedUpdate()
	{
		data.UpdateValues_Fixed();
	}

	internal Vector3 GetRelativePosition_Rig(BodypartType bodypart, Vector3 relativePosition)
	{
		Bodypart bodypart2 = refs.ragdoll.GetBodypart(bodypart);
		return bodypart2.transform.TransformPoint(relativePosition / bodypart2.transform.lossyScale.x);
	}

	internal Vector3 GetRelativePosition_Anim(BodypartType bodypart, Vector3 relativePosition)
	{
		Transform transform = refs.ragdoll.GetBodypart(bodypart).animationTarget.transform;
		return transform.transform.TransformPoint(relativePosition / transform.transform.lossyScale.x);
	}

	internal Vector3 LookDirection(Vector3 direction)
	{
		return Vector3.zero + direction.x * data.lookDirectionRight + direction.y * data.lookDirectionUp + direction.z * data.lookDirection;
	}

	internal void MoveAllRigsInDirection(Vector3 delta)
	{
		if (data.simplifiedRagdoll)
		{
			refs.ragdoll.GetBodypart(BodypartType.Hip).rig.transform.position += delta;
		}
		else
		{
			refs.ragdoll.MoveAllRigsInDirection(delta);
		}
	}

	internal Vector3 Center()
	{
		return refs.ragdoll.GetBodypart(BodypartType.Hip).rig.position;
	}

	internal Vector3 TransformCenter()
	{
		return refs.ragdoll.GetBodypart(BodypartType.Hip).rig.transform.position;
	}

	internal Vector3 CenterGroundPos()
	{
		Vector3 result = Center();
		result.y = data.groundPos.y;
		return result;
	}

	internal void SetLookDirection(Vector3 vector3)
	{
		data.playerLookValues = HelperFunctions.DirectionToLook(vector3);
	}

	public bool TryGetInventory(out PlayerInventory o)
	{
		if (TryGetGlobalPlayerData(out var d))
		{
			o = d.inventory;
			return true;
		}
		o = null;
		return false;
	}

	public void RequestCreatePickup(byte itemID, ItemInstanceData data, Vector3 pos, Quaternion rot, Vector3 vel, Vector3 angVel)
	{
		if (refs.view.IsMine)
		{
			byte[] array = data.Serialize(createNewGuid: true);
			refs.view.RPC("RPC_RequestCreatePickupVel", RpcTarget.MasterClient, itemID, array, pos, rot, vel, angVel);
		}
	}

	public void RequestCreatePickup(Item item, ItemInstanceData data, Vector3 pos, Quaternion rot)
	{
		if (refs.view.IsMine)
		{
			byte[] array = data.Serialize(createNewGuid: true);
			refs.view.RPC("RPC_RequestCreatePickup", RpcTarget.MasterClient, item.id, array, pos, rot);
		}
	}

	[PunRPC]
	public void RPC_RequestCreatePickupVel(byte itemID, byte[] dataBuffer, Vector3 pos, Quaternion rot, Vector3 vel, Vector3 angVel)
	{
		ItemInstanceData itemInstanceData = new ItemInstanceData(Guid.Empty);
		itemInstanceData.Deserialize(dataBuffer);
		PickupHandler.CreatePickup(itemID, itemInstanceData, pos, rot, vel, angVel);
	}

	[PunRPC]
	public void RPC_RequestCreatePickup(byte itemID, byte[] dataBuffer, Vector3 pos, Quaternion rot)
	{
		ItemInstanceData itemInstanceData = new ItemInstanceData(Guid.Empty);
		itemInstanceData.Deserialize(dataBuffer);
		PickupHandler.CreatePickup(itemID, itemInstanceData, pos, rot);
	}

	public Vector3 HeadPosition()
	{
		return refs.ragdoll.GetBodypart(BodypartType.Head).rig.position;
	}

	public bool CanSee(Vector3 targetPos, float validLookAngle = 70f, bool checkLineOfSight = true, HelperFunctions.LayerType mask = HelperFunctions.LayerType.TerrainProp)
	{
		Vector3 vector = HeadPosition();
		if (Vector3.Angle(data.lookDirection, targetPos - vector) > validLookAngle)
		{
			return false;
		}
		if (checkLineOfSight && (bool)HelperFunctions.LineCheck(targetPos, vector, HelperFunctions.LayerType.TerrainProp).transform)
		{
			return false;
		}
		return true;
	}

	public void OnGetMic(float db)
	{
		float micValueFromDecibels = GetMicValueFromDecibels(db);
		if (m_VoiceChatModeSetting != null && m_VoiceChatModeSetting.CanTalk())
		{
			data.microphoneValue = micValueFromDecibels;
		}
		else
		{
			data.microphoneValue = 0f;
		}
	}

	private float GetMicValueFromDecibels(float decibels)
	{
		return math.saturate(math.remap(-100f, -20f, 0f, 1f, decibels));
	}

	internal bool Ragdoll()
	{
		if (data.dead)
		{
			return true;
		}
		if (data.fallTime > 0f)
		{
			return true;
		}
		return false;
	}

	internal void SetPhysicsCamera(float seconds)
	{
		data.physicsCameraTime = seconds;
	}

	internal bool HangingUpsideDown()
	{
		if (data.CameraPhysicsAmount() > 0.5f && !ai)
		{
			return true;
		}
		return false;
	}

	internal Vector3 GetUpDirection()
	{
		if (HangingUpsideDown())
		{
			return Vector3.down;
		}
		return Vector3.up;
	}

	internal bool NoControl()
	{
		if (data.dead)
		{
			return true;
		}
		if (data.fallTime > 0f)
		{
			return true;
		}
		return false;
	}

	public void CallTakeDamage(float damage)
	{
	}

	public void RPCA_CallTakeDamage(float damage)
	{
		if (damage > 0.01f)
		{
			TakeDamage(damage);
		}
	}

	internal void CallTakeDamageAndTase(float damage, float tase)
	{

	}

	public void RPCA_CallTakeDamageAndTase(float damage, float tase)
	{
		if (damage > 0.01f)
		{
			TakeDamage(damage);
		}
		if (tase > 0.01f)
		{
			refs.ragdoll.TaseShock(tase);
		}
	}

	public void RPCM_RequestSit(int viewID, int seatID)
	{

	}

	public void RPCA_Sit(int viewID, int seatID)
	{

	}

	public void RPCA_UnSit(int viewID, int seatID)
	{
	}

	internal void CallTakeDamageAndAddForceAndFall(float damage, Vector3 force, float fall)
	{
		refs.view.RPC("RPCA_TakeDamageAndAddForce", RpcTarget.All, damage, force, fall);
	}

	public void RPCA_TakeDamageAndAddForce(float damage, Vector3 force, float fall)
	{
		if (damage > 0.01f)
		{
			TakeDamage(damage);
		}
		if (force.magnitude > 0.01f)
		{
			refs.ragdoll.AddForce(force, ForceMode.VelocityChange);
		}
		if (fall > 0.01f)
		{
			refs.ragdoll.Fall(fall);
		}
	}

	internal void CallTakeDamageAndAddForceAndFallWithFallof(float damage, Vector3 force, float fall, Vector3 pos, float range)
	{
		refs.view.RPC("RPCA_TakeDamageAndAddForceFallWithFallof", RpcTarget.All, damage, force, fall, pos, range);
	}

	public void RPCA_TakeDamageAndAddForceFallWithFallof(float damage, Vector3 force, float fall, Vector3 pos, float range)
	{
		if (damage > 0.01f)
		{
			TakeDamage(damage);
		}
		if (force.magnitude > 0.01f)
		{
			refs.ragdoll.AddForce(force, ForceMode.VelocityChange, pos, range);
		}
		if (fall > 0.01f)
		{
			refs.ragdoll.Fall(fall);
		}
	}

	public void WakeUp()
	{
		data.rested = true;
	}

	internal float Visibility()
	{
		float result = 1f;
		if (data.microphoneValue > 0.9f || data.isSprinting)
		{
			result = 2f;
		}
		else if (data.isCrouching)
		{
			result = 0.5f;
		}
		return result;
	}

	public void RPC_SelectSlot(int slotID)
	{
		data.selectedItemSlot = slotID;
	}

	internal void CallMakeSound(int soundID)
	{
	}

	public void RPC_MakeSound(int soundID)
	{
		if (soundID == 0)
		{
		}
	}

	internal void ToggleCollisionForSeconds(float seconds)
	{
		if (toggleCollisionCor != null)
		{
			Debug.Log("Stopping current to start new corutine!");
			StopCoroutine(toggleCollisionCor);
			toggleCollisionCor = StartCoroutine(ToggleColliders());
			return;
		}
		Debug.Log("Clearing data and starting new corutine from scratch!");
		Collider[] componentsInChildren = GetComponentsInChildren<Collider>();
		collidersEnabled.Clear();
		collidersToToggleList.Clear();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (!componentsInChildren[i].isTrigger)
			{
				collidersToToggleList.Add(componentsInChildren[i]);
				collidersEnabled.Add(componentsInChildren[i].enabled);
			}
		}
		toggleCollisionCor = StartCoroutine(ToggleColliders());
		IEnumerator ToggleColliders()
		{
			for (int j = 0; j < collidersToToggleList.Count; j++)
			{
				if (!(collidersToToggleList[j] == null))
				{
					collidersToToggleList[j].enabled = false;
				}
			}
			yield return new WaitForSeconds(seconds);
			for (int k = 0; k < collidersToToggleList.Count; k++)
			{
				if (!(collidersToToggleList[k] == null))
				{
					collidersToToggleList[k].enabled = collidersEnabled[k];
				}
			}
			toggleCollisionCor = null;
		}
	}

	internal void ReToggleCollision()
	{
		if (toggleCollisionCor == null)
		{
			return;
		}
		Debug.Log("Cancelling current corutine and resetting colliders!");
		StopCoroutine(toggleCollisionCor);
		for (int i = 0; i < collidersToToggleList.Count; i++)
		{
			if (!(collidersToToggleList[i] == null))
			{
				collidersToToggleList[i].enabled = collidersEnabled[i];
			}
		}
		collidersEnabled.Clear();
		collidersToToggleList.Clear();
		toggleCollisionCor = null;
	}

	internal void Teleport(Vector3 position, Vector3 forward)
	{
		StartCoroutine(IForcePosition());
		IEnumerator IForcePosition()
		{
			int frames = 20;
			while (frames > 0)
			{
				SetLookDirection(forward);
				frames--;
				data.sinceGrounded = 0f;
				Vector3 vector = position - Center();
				for (int i = 0; i < refs.ragdoll.bodypartList.Count; i++)
				{
					refs.ragdoll.bodypartList[i].rig.position += vector;
					refs.ragdoll.bodypartList[i].rig.velocity *= 0f;
					refs.ragdoll.bodypartList[i].rig.angularVelocity *= 0f;
				}
				yield return new WaitForFixedUpdate();
				yield return null;
			}
		}
	}

	internal Rigidbody GetRig(BodypartType part)
	{
		return refs.ragdoll.GetBodypart(part).rig;
	}

	internal void ClampGravity(float clampTime)
	{
		data.sinceGrounded = Mathf.Clamp(data.sinceGrounded, 0f, clampTime);
	}

	internal bool TryingToLeavePose()
	{
		if (!input.escapeWasPressed && !input.jumpWasPressed && !data.isSprinting)
		{
			return input.interactWasPressed;
		}
		return true;
	}

	internal void CallAddForceToBodyParts(int[] ints, Vector3[] vector3s)
	{

	}

	internal void RPCA_AddForceToBodyParts(int[] ints, Vector3[] vector3s)
	{
		for (int i = 0; i < ints.Length; i++)
		{
			refs.ragdoll.GetBodypartFromID(ints[i]).rig.AddForce(vector3s[i], ForceMode.VelocityChange);
		}
	}

	public void Call_EquipHat(int hatIndex)
	{

	}

	public void Call_RemoveHat()
	{

	}

	public void RPCA_EquipHat(int hatIndex)
	{

	}

	public void OnPlayerEnteredRoom()
	{

	}

	internal void CallSlowFor(float speedFactor, float time)
	{

	}

	internal void RPCA_SlowFor(float speedFactor, float time)
	{
		StartCoroutine(ISlowFor());
		IEnumerator ISlowFor()
		{
			float c = 0f;
			while (c < time)
			{
				data.movementSlowFactor = speedFactor;
				c += Time.deltaTime;
				yield return null;
			}
		}
	}
}
