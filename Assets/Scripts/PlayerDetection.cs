using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class PlayerDetection : MonoBehaviour, IRayCastEnemyData, IPlayerDetect
    {        
        public UnityEvent OnPlayerDetected;
        public UnityEvent OnPlayerStayDetected;
        public UnityEvent OnPlayerLost;
        public UnityEvent OnPlayerNear;

        [SerializeField] protected float detectionRange;
        [SerializeField] protected float playerNearThreshold;
        [SerializeField] [Range(-1, 1)] protected float angleVision;
        [SerializeField] private Vector3 rayPositionOffset;
        private bool playerDetected;
        private IDataPlayer player;
        
        public Vector3 RayPositionOffset
        {
            get => rayPositionOffset;
            set => rayPositionOffset = value;
        }

        public bool PlayerDetected 
        { 
            get => playerDetected; 
            set => playerDetected = value;
        }

        private void Awake()
        {
            player = FindAnyObjectByType<Player>();
        }
        
        private void Update()
        {
            SearchPlayer();
        }

        private void SearchPlayer()
        {
            Vector3 directionToPlayer = player.GetPosition() - transform.position;
            float distanceToPlayer = directionToPlayer.magnitude;

            if (distanceToPlayer < detectionRange && !playerDetected && RayDetectPlayer() && IsInRangeDetection())
            {
                PlayerFound();
            }
            else if (distanceToPlayer < detectionRange * 2 && playerDetected)
            {
                PlayerStillFound();
            }
            else if (distanceToPlayer >= detectionRange && playerDetected)
            {
                PlayerLost();
            }

            if (distanceToPlayer < playerNearThreshold && playerDetected)
            {
                OnPlayerNear?.Invoke();
            }
        }

        private void PlayerStillFound()
        {
            OnPlayerStayDetected?.Invoke();
        }

        private void PlayerFound()
        {
            playerDetected = true;
            OnPlayerDetected?.Invoke();
        }

        public void PlayerLost()
        {
            playerDetected = false;
            OnPlayerLost?.Invoke();
        }

        private bool RayDetectPlayer()
        {
            Physics.Raycast(transform.position + RayPositionOffset, player.GetPosition() - transform.position, out RaycastHit hitInfo);
            return hitInfo.transform.CompareTag("Player");
        }

        private bool IsInRangeDetection()
        {
            return Vector3.Dot(transform.forward, player.GetPosition() - transform.position) > angleVision;
        }
    }
}