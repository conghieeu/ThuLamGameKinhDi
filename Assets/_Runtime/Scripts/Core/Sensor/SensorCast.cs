
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CuaHang
{
    /// <summary> Sử dụng Physics.BoxCastAll để phát hiện va chạm </summary>
    public class SensorCast : MonoBehaviour
    {
        public LayerMask _layer;
        public List<Transform> _hits;
        [SerializeField] protected Vector3 _size;

        private void Update()
        {
            _hits = BoxCastHits();
        }
 
        /// <summary> Gọi liên tục để lấy va chạm </summary>
        private List<Transform> BoxCastHits()
        {
            RaycastHit[] hits = Physics.BoxCastAll(transform.position, _size / 2f, transform.forward, transform.rotation, 0f, _layer);
            return hits.Select(x => x.transform).ToList();
        }

        // Vẽ box hit ra khi click vào thì thấy được box hit
        private void OnDrawGizmosSelected()
        {
            Matrix4x4 rotationMatrix = Matrix4x4.TRS(transform.position, transform.rotation, _size);
            Gizmos.matrix = rotationMatrix;
            Gizmos.DrawWireCube(Vector3.zero, _size);
        }
    }
}