using UnityEngine;
using UnityEngine.AI;

public class GhostAI : MonoBehaviour
{
    [SerializeField] Transform player;
    NavMeshAgent agent;
    Animator anim;
    GhostState currentStage;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        currentStage = new Idle(gameObject, agent, anim, player);
    }

    void Update()
    {
        currentStage = currentStage.Process();
    }
}
