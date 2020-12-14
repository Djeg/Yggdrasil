using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Djeg.Yggdrasil.Movement.Data;

namespace Djeg.Yggdrasil.Movement.Component
{
    /**
     * <summary>
     * Control the attack movement and expose 4 events:
     *
     *- OnAttackStart, OnAttackHit, OnAttackRelease, OnAttackEnd
     * </summary>
     */
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(ControlHorizontalMovement))]
    public class ControlAttackMovement : MonoBehaviour
    {
        # region Properties

        /**
         * <summary>
         * The collection of attack
         * </summary>
         */
        [SerializeField]
        [Header("Parameters")]
        private List<Attack> _attacks = new List<Attack>();

        /**
         * <summary>
         * The layer concerned by those attacks
         * </summary>
         */
        [SerializeField]
        private LayerMask _layer = Physics2D.AllLayers;

        /**
         * <summary>
         * Teh OnAttackStartEvent
         * </summary>
         */
        [SerializeField]
        [Header("Events")]
        private OnAttackStartEvent _onAttackStart = new OnAttackStartEvent();

        /**
         * <summary>
         * The OnAttackHit
         * </summary>
         */
        [SerializeField]
        private OnAttackHitEvent _onAttackHit = new OnAttackHitEvent();

        /**
         * <summary>
         * The OnAttackReleaseEvent
         * </summary>
         */
        [SerializeField]
        private OnAttackReleaseEvent _onAttackRelease = new OnAttackReleaseEvent();

        /**
         * <summary>
         * The OnAttackEndEvent
         * </summary>
         */
        [SerializeField]
        private OnAttackEndEvent _onAttackEnd = new OnAttackEndEvent();

        /**
         * <summary>
         * The current index
         * </summary>
         */
        private int _index = 0;

        /**
         * <summary>
         * Lock the next attack ability
         * </summary>
         */
        private bool _locked = false;

        /**
         * <summary>
         * A reference to the ControlHorizontalMovement
         * </summary>
         */
        private ControlHorizontalMovement _movement = null;

        /**
         * <summary>
         * A reference to the Rigidbody2D
         * </summary>
         */
        private Rigidbody2D _body = null;

        # endregion

        # region PropertyAccessors

        /**
         * <summary>
         * Return the attacks
         * </summary>
         */
        public List<Attack> Attacks { get => _attacks; }

        /**
         * <summary>
         * Retrieve the layer
         * </summary>
         */
        public LayerMask Layer { get => _layer; }

        /**
         * <summary>
         * Return the current index
         * </summary>
         */
        public int Index { get => _index; }

        /**
         * <summary>
         * Return the current attack
         * </summary>
         */
        public Attack CurrentAttack { get => _attacks[_index]; }

        /**
         * <summary>
         * Retrieve the lock state
         * </summary>
         */
        public bool Locked { get => _locked; set => _locked = true; }

        /**
         * <summary>
         * Retrieve the OnAttackStartEvent
         * </summary>
         */
        public OnAttackStartEvent OnAttackStart { get => _onAttackStart; }

        /**
         * <summary>
         * Retrieve the OnAttackHitEvent
         * </summary>
         */
        public OnAttackHitEvent OnAttackHit { get => _onAttackHit; }

        /**
         * <summary>
         * Retrieve teh OnAttackReleaseEvent
         * </summary>
         */
        public OnAttackReleaseEvent OnAttackRelease { get => _onAttackRelease; }

        /**
         * <summary>
         * Retrieve the OnAttackEndEvent
         * </summary>
         */
        public OnAttackEndEvent OnAttackEnd { get => _onAttackEnd; }

        # endregion

        # region PublicMethods

        /**
         * <summary>
         * Trigger an attack
         * </summary>
         */
        public void HitAttack()
        {
            if (CurrentAttack.impulse != Vector2.zero)
                _body.AddForce(
                    HorizontalDirectionHelper.Parse(_movement.Direction, CurrentAttack.impulse),
                    ForceMode2D.Impulse
                );

            Collider2D[] colliders = Physics2D.OverlapCircleAll(
                GetAttackPosition(CurrentAttack),
                CurrentAttack.radius,
                _layer
            );

            foreach (Collider2D collider in colliders)
            {
                GameObject victim = collider.gameObject;

                Rigidbody2D body = victim.GetComponent<Rigidbody2D>();
                ControlHorizontalMovement movement = victim.GetComponent<ControlHorizontalMovement>();

                if (null != body && null != movement)
                {
                    HorizontalDirection inversedDirection = HorizontalDirectionHelper.Inverse(movement.Direction);

                    body.AddForce(
                        HorizontalDirectionHelper.Parse(inversedDirection, CurrentAttack.force),
                        ForceMode2D.Impulse
                    );
                }

                OnAttackHit.Invoke(victim, CurrentAttack);
            }

            _index += 1;
        }

        /**
         * <summary>
         * Reset the attack index
         * </summary>
         */
        public void EndAttack()
        {
            _index = 0;

            OnAttackEnd.Invoke();
        }

        /**
         * <summary>
         * Start the attack
         * </summary>
         */
        public void Attack()
        {
            if (_locked)
                return;

            _locked = true;

            OnAttackStart.Invoke();
        }

        /**
         * <summary>
         * Release teh attack
         * </summary>
         */
        public void ReleaseAttack()
        {
            _locked = false;

            OnAttackRelease.Invoke();
        }

        # endregion

        # region PrivateMethods

        /**
         * <inheritdoc/>
         */
        private void Awake()
        {
            _movement = GetComponent<ControlHorizontalMovement>();
            _body     = GetComponent<Rigidbody2D>();
        }

        /**
         * <summary>
         * When pressing the attack input button
         * </summary>
         */
        private void OnAttackInput() => Attack();

        /**
         * <summary>
         * Disable the attack on jumping
         * </summary>
         */
        private void OnJumping() => _locked = true;

        /**
         * <summary>
         * Enable the attack when landing
         * </summary>
         */
        private void OnLanding() => _locked = false;

        /**
         * <inheritdoc/>
         */
        private void OnDrawGizmosSelected()
        {
            _attacks
                .FindAll(attack => attack.debug)
                .ForEach(attack => {
                    Gizmos.color = attack.debugColor;

                    Gizmos.DrawWireSphere(
                        GetAttackPosition(attack),
                        attack.radius
                    );
                })
            ;
        }

        /**
         * <summary>
         * Retrieve the position of an attack hit box
         * </summary>
         */
        private Vector3 GetAttackPosition(Attack attack) =>
            new Vector3(
                transform.position.x + HorizontalDirectionHelper.Parse(_movement.Direction, attack.position.x),
                transform.position.y + attack.position.y,
                transform.position.z
            );

        # endregion
    }

    /**
     * <summary>
     * Trigger when an attack start
     * </summary>
     */
    [System.Serializable]
    public sealed class OnAttackStartEvent : UnityEvent
    {
    }

    /**
     * <summary>
     * Trigger on attack hit
     * </summary>
     */
    [System.Serializable]
    public sealed class OnAttackHitEvent : UnityEvent<GameObject, Attack>
    {
    }

    /**
     * <summary>
     * Trigger on attack release
     * </summary>
     */
    [System.Serializable]
    public sealed class OnAttackReleaseEvent : UnityEvent
    {
    }

    /**
     * <summary>
     * Trigger on attack end
     * </summary>
     */
    [System.Serializable]
    public sealed class OnAttackEndEvent : UnityEvent
    {
    }
}
