using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Xử lý va chạm và quản lý danh sách các đối tượng va chạm.
/// </summary>
public class CollisionHandler : MonoBehaviour
{
    public List<Transform> detectedObjects; // Danh sách các đối tượng được phát hiện theo layer và tag
    public List<Transform> allCollidingObjects; // Danh sách tất cả các đối tượng va chạm
    public LayerMask allowedLayers; // Biến cho phép cấu hình layer
    public List<string> allowedTags; // Danh sách các tag được phép

    void Start()
    {
        detectedObjects = new List<Transform>();
        allCollidingObjects = new List<Transform>();
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
}


