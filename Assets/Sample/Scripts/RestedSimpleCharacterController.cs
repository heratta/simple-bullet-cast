using Helab.Simply;
using UnityEngine;

namespace Sample
{
    [RequireComponent(typeof(TurnAroundWithDirection))]
    public class RestedSimpleCharacterController : MonoBehaviour
    {
        [SerializeField] private Color bodyColor = Color.gray;
        
        [SerializeField] private Color directionColor = Color.red;
        
        private TurnAroundWithDirection _turnAround;

        private void Awake()
        {
            _turnAround = GetComponent<TurnAroundWithDirection>();
            SetRendererColor.ChangeColorIfAttachedComponent(transform.Find("Body"), bodyColor);
            SetRendererColor.ChangeColorIfAttachedComponent(transform.Find("Direction"), directionColor);
        }
        
        private void Update()
        {
            UpdateForTurnAround();
        }
        
        private void UpdateForTurnAround()
        {
            var (thrustDirectionInput, _) = SimpleHelper.GetThrustDirectionByInput();
            if (0f < thrustDirectionInput.magnitude)
            {
                _turnAround.TargetDirection = thrustDirectionInput;
            }
        }
    }
}
