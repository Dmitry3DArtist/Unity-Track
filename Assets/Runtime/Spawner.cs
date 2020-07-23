using System.Collections;
using UnityEngine;



namespace TowerDefense.Runtime
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Unit m_unit = default;
        [SerializeField] private Path m_path = default;




        // Start is called before the first frame update
        private void Start()
        {
            StartCoroutine(Spawn());
        }




        private IEnumerator Spawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(0.25f, 1f));
                Unit ballOne = Instantiate(m_unit);
                ballOne.StartMove(m_path);
            }
        }



    }
}