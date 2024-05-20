using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class KiyomiUSHide : MonoBehaviour, IStartActionUpdateState
    {
        public UnityEvent OnLostPlayer;

        [SerializeField] protected NavMeshAgent agent;
        protected IRayCastEnemyData dataEnemy;
        protected IDataPlayer dataPlayer;
        private void Start()
        {
            dataEnemy = GetComponent<PlayerDetection>();
            dataPlayer = FindAnyObjectByType<Player>();
        }

        public void StartAction()
        {
            IsHiddingWhileIsWatching();
        }

        private void IsHiddingWhileIsWatching()
        {

            Vector3 positionToHit = dataPlayer.GetPosition();
            agent.destination = positionToHit;
            if (RayDetectPlayer(positionToHit, out RaycastHit hitInfo))
            {
                StartCoroutine(GoToLastPlayerPosition(positionToHit, hitInfo.transform.CompareTag("Player") || Vector3.Distance(transform.position, positionToHit) < 1f));
            }
        }

        private bool RayDetectPlayer(Vector3 positionToHit, out RaycastHit hitInfo)
        {
            return Physics.Raycast(transform.position + dataEnemy.RayPositionOffset, positionToHit - transform.position, out hitInfo, Mathf.Infinity);
        }

        private IEnumerator GoToLastPlayerPosition(Vector3 positionToHit, bool search)
        {
            yield return new WaitWhile(() => Vector3.Distance(transform.position, positionToHit) > 1f);
            if (search)
            {
                FindPlayer();
            }
            else
            {
                OnLostPlayer.Invoke();
            }
        }

        private void FindPlayer()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 3f);
            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent<HideInteractable>(out var hi))
                {
                    hi.Interact();
                    return;
                }
            }
        }
    }
}