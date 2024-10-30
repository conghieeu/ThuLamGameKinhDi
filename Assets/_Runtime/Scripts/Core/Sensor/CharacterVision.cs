using System.Collections.Generic;
using UnityEngine;

/// <summary> Sử dụng collider để phát hiện va chạm </summary>
public class CharacterVision : MonoBehaviour
{
    public Transform rayStartPoint; // Biến công khai cho điểm bắt đầu của tia
    public LayerMask allowedLayers; // Biến cho phép cấu hình layer
    public List<string> allowedTags; // Danh sách các tag được phép
    public List<Transform> unobstructedHits; // Danh sách các đối tượng không bị cản trở
    public List<Transform> detectedObjects; // Danh sách các đối tượng được phát hiện theo layer và tag
    public List<Transform> allCollidingObjects; // Danh sách tất cả các đối tượng va chạm

    void Start()
    {
        unobstructedHits = new List<Transform>();
        detectedObjects = new List<Transform>();
        allCollidingObjects = new List<Transform>();
    }

    void Update()
    {
        UpdateUnobstructedHits();
    }

    /// <summary>
    /// Xử lý khi một đối tượng khác nằm trong vùng collider.
    /// Thêm đối tượng vào danh sách detectedObjects nếu nó thuộc layer và tag cho phép.
    /// Thêm đối tượng vào danh sách allCollidingObjects không phân biệt layer và tag.
    /// </summary>
    /// <param name="other">Đối tượng va chạm.</param>
    void OnTriggerStay(Collider other)
    {
        if (!allCollidingObjects.Contains(other.transform))
        {
            allCollidingObjects.Add(other.transform);
        }

        if ((allowedLayers.value & (1 << other.gameObject.layer)) != 0 && allowedTags.Contains(other.tag))
        {
            if (!detectedObjects.Contains(other.transform))
            {
                detectedObjects.Add(other.transform);
            }
        }
    }

    /// <summary>
    /// Xử lý khi một đối tượng rời khỏi vùng collider.
    /// Loại bỏ đối tượng khỏi danh sách detectedObjects và allCollidingObjects.
    /// </summary>
    /// <param name="other">Đối tượng va chạm.</param>
    void OnTriggerExit(Collider other)
    {
        if (detectedObjects.Contains(other.transform))
        {
            detectedObjects.Remove(other.transform);
        }

        if (allCollidingObjects.Contains(other.transform))
        {
            allCollidingObjects.Remove(other.transform);
        }
    }

    /// <summary>
    /// Cập nhật danh sách các đối tượng không bị cản trở bởi vật cản.
    /// </summary>
    void UpdateUnobstructedHits()
    {
        unobstructedHits.Clear(); // Xóa danh sách trước khi cập nhật

        foreach (var hit in detectedObjects)
        {
            if (hit != null)
            {
                if (IsUnobstructed(hit))
                {
                    unobstructedHits.Add(hit);
                }
            }
        }
    }

    /// <summary>
    /// Kiểm tra xem có vật cản nào giữa đối tượng hiện tại và đối tượng hit không.
    /// Vẽ tia từ đối tượng hiện tại đến đối tượng hit hoặc điểm va chạm.
    /// </summary>
    /// <param name="hit">Đối tượng cần kiểm tra.</param>
    /// <returns>Trả về true nếu không có vật cản, ngược lại trả về false.</returns>
    bool IsUnobstructed(Transform hit)
    {
        Vector3 direction = hit.position - rayStartPoint.position;
        Ray ray = new Ray(rayStartPoint.position, direction);
        RaycastHit hitInfo;

        // Kiểm tra nếu có vật cản giữa đối tượng hiện tại và hit
        if (Physics.Raycast(ray, out hitInfo, direction.magnitude))
        {
            // Kiểm tra nếu va chạm chính là đối tượng chứa điểm đến
            if (hitInfo.transform == hit)
            {
                // Vẽ tia đến đối tượng hit
                Debug.DrawLine(rayStartPoint.position, hit.position, Color.green);
                return true;
            }

            // Vẽ tia đến điểm va chạm
            Debug.DrawLine(rayStartPoint.position, hitInfo.point, Color.red);
            return false;
        }
        else
        {
            // Vẽ tia đến đối tượng hit
            Debug.DrawLine(rayStartPoint.position, hit.position, Color.green);
            return true;
        }
    }
}

