using UnityEngine;



namespace TowerDefense.Runtime
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private float m_speed = default;




        private Path m_path = default;



        private Vector3 m_start = default;
        private Vector3 m_end = default;
        private float m_interpolate = 0f;
        private int m_pathIndex = 0;





        public void StartMove(Path path)
        {
            m_path = path;
            m_start = transform.position;
            m_end = m_path.GetPoint(m_pathIndex).position;
        }



        // Update is called once per frame
        private void Update()
        {
            if (m_path == null)
            {
                return;
            }



            m_interpolate += Time.deltaTime * m_speed / Vector3.Distance(m_start, m_end);
            transform.position = Vector3.Lerp(m_start, m_end, m_interpolate);
            if (m_interpolate >= 1)
            {
                m_pathIndex++;
                if (m_pathIndex >= m_path.Length)
                {
                    Debug.Log("Moving finished!");
                    enabled = false;
                    return;
                }



                m_start = transform.position;
                m_end = m_path.GetPoint(m_pathIndex).position;
                m_interpolate = 0;
            }
        }
    }
}