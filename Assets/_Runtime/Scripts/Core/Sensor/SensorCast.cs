using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(VisionChecker))]

/// <summary> Sử dụng Physics.BoxCastAll để phát hiện va chạm </summary>
public class SensorCast : MonoBehaviour
{
    public LayerMask layerCast;
    public List<Transform> boxCastHits;
    public List<Transform> visionHits;
    public Color colorGizmos;
    public Vector3 boxSize;
    public Vector3 localBoxPos;

    VisionChecker visionChecker;

    private void Start()
    {
        visionChecker = GetComponent<VisionChecker>();
    }

    private void FixedUpdate()
    {
        boxCastHits = BoxCastHits();
        visionHits = GetObjectHitsInVision(boxCastHits);
    }

    private List<Transform> GetObjectHitsInVision(List<Transform> hits)
    {
        List<Transform> hitsInVision = new();

        foreach (Transform t in hits)
        {
            if (visionChecker.IsSeePoint(t))
            {
                hitsInVision.Add(t);
            }
        }

        return hitsInVision;
    }

    /// <summary> Gọi liên tục để lấy va chạm </summary>
    private List<Transform> BoxCastHits()
    {
        RaycastHit[] hits = Physics.BoxCastAll(transform.position + localBoxPos, boxSize / 2f, transform.forward, transform.rotation, 0f, layerCast);
        return hits.Select(x => x.transform).ToList();
    }

    // Vẽ box hit ra khi click vào thì thấy được box hit
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = colorGizmos;
        Matrix4x4 rotationMatrix = Matrix4x4.TRS(transform.position + localBoxPos, transform.rotation, boxSize);
        Gizmos.matrix = rotationMatrix;
        Gizmos.DrawWireCube(Vector3.zero, boxSize);
    }
}
