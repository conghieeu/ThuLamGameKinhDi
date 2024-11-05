using UnityEngine; 

public class Bodypart : MonoBehaviour
{
    public BodypartType bodypartType;

    internal Rigidbody rig;

    public float movementForceMultiplier = 1f;

    public BodypartAnimationTarget animationTarget;

    private Quaternion startLocal;

    private Player player;

    private ConfigurableJoint joint;

    internal void Config(BodypartType partType)
    {
        bodypartType = partType;
    }

    internal void InitPart()
    {
        startLocal = base.transform.localRotation;
        rig = GetComponent<Rigidbody>();
        joint = GetComponent<ConfigurableJoint>();
        player = GetComponentInParent<Player>();
    }

    internal void SetTarget(BodypartAnimationTarget bodypartAnimationTarget)
    {
        animationTarget = bodypartAnimationTarget;
    }

    internal void FollowAnimJointDrive()
    {
 
    }

    internal void FollowAnimSimple(Bodypart hip)
    {
        Vector3 vector = animationTarget.transform.position - hip.animationTarget.transform.position;
        base.transform.position = Vector3.Lerp(base.transform.position, hip.rig.transform.position + vector, 3f * Timez.CappedFixedDeltaTime);
        base.transform.rotation = Quaternion.Lerp(base.transform.rotation, animationTarget.transform.rotation, 3f * Timez.CappedFixedDeltaTime);
    }

    internal void FollowAnimJointVel(Transform physicsRoot, Transform animationRoot, float force, bool addOpposingForce)
    {
        Vector3 vector = animationTarget.transform.TransformPoint(base.transform.InverseTransformPoint(rig.worldCenterOfMass)) - animationRoot.position;
        Vector3 vector2 = (physicsRoot.transform.position + vector - rig.worldCenterOfMass) * force;
        rig.AddForce(vector2, ForceMode.Acceleration);
        if (addOpposingForce)
        {
            Vector3 force2 = vector2 * rig.mass;
            AddOpposingForce(force2);
        }
    }

    private void AddOpposingForce(Vector3 force)
    {
        float totalMass = player.data.totalMass;
        for (int i = 0; i < player.refs.ragdoll.rigList.Count; i++)
        {
            if (player.refs.ragdoll.rigList[i].gameObject.activeInHierarchy)
            {
                float num = player.refs.ragdoll.rigList[i].mass / totalMass;
                player.refs.ragdoll.rigList[i].AddForce(-force * num, ForceMode.Force);
            }
        }
    }

    internal void FollowAnimJointAngularVel(Transform physicsRoot, Transform animationRoot, float torque)
    {
        if (!player.data.dead || bodypartType != 0)
        {
            Vector3 forward = animationTarget.transform.forward;
            Vector3 up = animationTarget.transform.up;
            Vector3 vector = Vector3.Cross(rig.transform.forward, forward).normalized * Vector3.Angle(rig.transform.forward, forward);
            vector += Vector3.Cross(rig.transform.up, up).normalized * Vector3.Angle(rig.transform.up, up) * 0.5f;
            rig.AddTorque(vector * torque, ForceMode.Acceleration);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        Collide(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        Collide(collision);
    }

    private void Collide(Collision collision)
    {
        if ((bool)player && !(collision.transform.root == base.transform.root) && (bool)player.refs.ragdoll)
        {
            player.refs.ragdoll.BodyPartCollision(collision, this);
        }
    }
}
