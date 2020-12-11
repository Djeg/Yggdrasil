using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Core;
using Data;

namespace Behaviour
{
    /**
     * <summary>
     * Control the input related to aestrid
     * </summary>
     */
    [RequireComponent(typeof(PlayerInput))]
    [RequireData(typeof(MovementData))]
    [RequireData(typeof(AttackCollectionData))]
    public class ControlAestridInput : MonoDataBehaviour
    {
        # region Properties

        /**
         * <summary>
         * The move input name
         * </summary>
         */
        [SerializeField]
        private string _moveInputName = "Move";

        /**
         * <summary>
         * The jump input name
         * </summary>
         */
        [SerializeField]
        private string _jumpInputName = "Jump";

        /**
         * <summary>
         * The attack input name
         * </summary>
         */
        [SerializeField]
        private string _attackInputName = "Attack";

        /**
         * <summary>
         * The attack input name
         * </summary>
         */
        [SerializeField]
        private string _dashInputName = "Dash";

        /**
         * <summary>
         * A reference to the player input
         * </summary>
         */
        private PlayerInput _input = null;

        /**
         * <summary>
         * A reference to the movement data
         * </summary>
         */
        private MovementData _movement = null;

        /**
         * <summary>
         * A reference to the hit box collection data
         * </summary>
         */
        private AttackCollectionData _attacks = null;

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods
        # endregion

        # region PrivateMethods

        /**
         * <inheritdoc/>
         */
        protected override void Init(MonoDataContainer container)
        {
            _input    = GetComponent<PlayerInput>();
            _movement = GetData<MovementData>();
            _attacks  = GetData<AttackCollectionData>();
        }

        /**
         * <inheritdoc/>
         */
        private void OnEnable()
        {
            _input.onActionTriggered += HandleInput;
        }

        /**
         * <inheritdoc/>
         */
        private void OnDisable()
        {
            _input.onActionTriggered -= HandleInput;
        }

        /**
         * <summary>
         * Handle any input action and update the movement data currentMovement
         * on Move.
         * </summary>
         */
        private void HandleInput(InputAction.CallbackContext ctx)
        {
            // Handle Left and Right Stick
            if (_moveInputName == ctx.action.name)
            {
                Vector2 movement = ctx.ReadValue<Vector2>();
                _movement.currentMovement = movement.x;
            }

            // Handle jump
            if (_jumpInputName == ctx.action.name && ctx.started && !_movement.jumping)
            {
                _movement.requestJump = true;
                _movement.holdingJump = true;
            }

            if (_jumpInputName == ctx.action.name && ctx.started && _movement.jumping && _movement.blocking)
            {
                _movement.requestJump = true;
                _movement.holdingJump = true;
            }

            if (_jumpInputName == ctx.action.name && ctx.canceled)
            {
                _movement.holdingJump = false;
            }

            if (_attackInputName == ctx.action.name && ctx.started)
            {
                _attacks.requestHit = true;
            }

            if (_dashInputName == ctx.action.name && ctx.started && !_movement.dashing)
            {
                _movement.requestDash = true;
            }
        }

        # endregion
    }
}
