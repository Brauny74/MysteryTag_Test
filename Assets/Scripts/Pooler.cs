using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kazin_Test
{
    /// <summary>
    /// �B�������}���s�p���u�|���~���z �{�|�p���� �t�|�� �����|�u���p ���q���u�{�����r.
    /// </summary>
    public class Pooler : MonoBehaviour
    {
        private List<GameObject> pool;

        [SerializeField]
        private GameObject PoolPrefab;

        [SerializeField]
        private int AmountToPool;

        [SerializeField]
        [Tooltip("�E���|�y true, �����| �q���t�u�� ���p�����y������������ �t�|�� �~���r���� ���|�u�}�u�~�����r, �u���|�y AmountToPool �t�������y�s�~����.")]
        private bool Expandable;

        private void Start()
        {
            pool = new List<GameObject>();
            for (int i = 0; i < AmountToPool; i++)
            {
                CreatePooledObject();
            }
        }

        private GameObject CreatePooledObject(bool activeOnStart = false)
        {
            GameObject tmp = Instantiate(PoolPrefab.gameObject);
            tmp.gameObject.SetActive(activeOnStart);
            pool.Add(tmp);
            return tmp;
        }

        public GameObject GetPooledObject()
        {
            for (int i = 0; i < AmountToPool; i++)
            {
                if (!pool[i].activeInHierarchy)
                {
                    pool[i].SetActive(true);
                    return pool[i];
                }
            }
            if (Expandable)
            {
                AmountToPool++;
                return CreatePooledObject(true);
            }
            else
            {
                return null;
            }
        }

        public void ReturnToPool(GameObject obj)
        {
            obj.SetActive(false);
        }
    }
}