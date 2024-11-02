using System.Collections.Generic;
using UnityEngine;

public class VisionChecker : MonoBehaviour
{
    public List<Transform> vertexTransforms; // Danh sách các Transform tạo thành hình khối 
    public List<Color> pyramidColors = new List<Color>();

    public bool IsSeePoint(Transform testPointTransform)
    {
        // Khai báo và khởi tạo danh sách vertices từ vertexTransforms
        List<Vector3> vertices = new List<Vector3>();
        foreach (var transform in vertexTransforms)
        {
            vertices.Add(transform.position);
        }

        Vector3 testPoint = testPointTransform.position; // Lấy vị trí của testPointTransform

        if (IsPointInsideShape(vertices, testPoint))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    [ContextMenu("GetChildTransforms")]
    private void GetChildTransforms()
    {
        vertexTransforms.Clear(); // Xóa danh sách hiện tại nếu cần
        foreach (Transform child in transform)
        {
            vertexTransforms.Add(child);
        }
    }

    bool IsPointInsideShape(List<Vector3> vertices, Vector3 P)
    {
        for (int i = 0; i < vertices.Count - 3; i++)
        {
            Vector3 O = vertices[i + 0];
            Vector3 A = vertices[i + 1];
            Vector3 B = vertices[i + 2];
            Vector3 C = vertices[i + 3];

            if (IsPointInsidePyramid(O, A, B, C, P)) return true;
        }
        return false;
    }

    // Hàm để kiểm tra liệu điểm P có nằm trong hình chóp tạo bởi các điểm O, A, B, C hay không
    public bool IsPointInsidePyramid(Vector3 O, Vector3 A, Vector3 B, Vector3 C, Vector3 P)
    {
        // Tính thể tích của hình chóp gốc V(OABC)
        float volumeOABC = CalculateTetrahedronVolume(O, A, B, C);

        // Tính thể tích các hình chóp con
        float volumePABC = CalculateTetrahedronVolume(P, A, B, C);
        float volumeOPBC = CalculateTetrahedronVolume(O, P, B, C);
        float volumeOAPC = CalculateTetrahedronVolume(O, A, P, C);
        float volumeOABP = CalculateTetrahedronVolume(O, A, B, P);

        // Tính tổng thể tích các hình chóp con
        float totalVolume = volumePABC + volumeOPBC + volumeOAPC + volumeOABP;

        // So sánh tổng thể tích các hình chóp con với thể tích hình chóp gốc
        // Sử dụng khoảng epsilon để xử lý sai số dấu phẩy động
        float epsilon = 1e-5f;
        return Mathf.Abs(totalVolume - volumeOABC) < epsilon;
    }

    // Hàm để tính thể tích của hình chóp tứ diện (O, A, B, C)
    private float CalculateTetrahedronVolume(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4)
    {
        Vector3 v1 = p2 - p1;
        Vector3 v2 = p3 - p1;
        Vector3 v3 = p4 - p1;
        float volume = Mathf.Abs(Vector3.Dot(v1, Vector3.Cross(v2, v3))) / 6f;
        return volume;
    }



    private void OnDrawGizmosSelected()
    {
        // Kiểm tra nếu có đủ điểm để tạo thành hình chóp
        if (vertexTransforms.Count >= 4)
        {
            // Đảm bảo danh sách màu sắc có đủ màu cho mỗi hình chóp
            while (pyramidColors.Count < vertexTransforms.Count - 3)
            {
                pyramidColors.Add(Random.ColorHSV());
            }

            for (int i = 0; i < vertexTransforms.Count - 3; i++)
            {
                // Sử dụng màu đã lưu trữ cho mỗi hình chóp
                Gizmos.color = pyramidColors[i];

                // Lấy các điểm từ danh sách
                Vector3 O = vertexTransforms[i + 0].position; // Đỉnh của hình chóp
                Vector3 A = vertexTransforms[i + 1].position;
                Vector3 B = vertexTransforms[i + 2].position;
                Vector3 C = vertexTransforms[i + 3].position;

                // Vẽ các cạnh của hình chóp
                Gizmos.DrawLine(O, A);
                Gizmos.DrawLine(O, B);
                Gizmos.DrawLine(O, C);
                Gizmos.DrawLine(A, B);
                Gizmos.DrawLine(B, C);
                Gizmos.DrawLine(C, A);
            }
        }
    }
}
