using UnityEngine;


namespace MiniJam150
{
    public class SpotlightMovement : MonoBehaviour
    {
        [SerializeField] private float maxMovementTime = 5f;
        [SerializeField] private RandomTimer randomTimer;
        [SerializeField] private Vector2 maxHorizontalSpotlightMovement;

        private Vector3 newTargetPosition = Vector3.zero;
        private float currentMaxMovementTime = 0f;
        private float movementDelta = 0f;


        public void MoveToNewPosition()
        {
            randomTimer.run = false;
            newTargetPosition = new Vector3
                (
                    x: Random.Range(-maxHorizontalSpotlightMovement.x, maxHorizontalSpotlightMovement.x),
                    y: transform.position.y,
                    z: Random.Range(-maxHorizontalSpotlightMovement.y, maxHorizontalSpotlightMovement.y)
                );
            currentMaxMovementTime = Random.Range(1f, maxMovementTime);
        }


        private void Update()
        {
            if (transform.position != newTargetPosition)
            {
                movementDelta += Time.deltaTime;
                transform.position = Vector3.Lerp(transform.position, newTargetPosition, movementDelta / currentMaxMovementTime);
            }
            else
            {
                if (!randomTimer.run)
                {
                    randomTimer.run = true;
                    movementDelta = 0f;
                }
            }
        }
    }
}