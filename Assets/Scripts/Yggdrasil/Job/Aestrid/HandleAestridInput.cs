using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Yggdrasil.Core.Physic;
using Yggdrasil.Core.Controller;
using Yggdrasil.Core.Job;
using Yggdrasil.Data.Movement;

namespace Yggdrasil.Job.Aestrid
{
    /**
     * <summary>
     * Allow to connect some input and modified the Aestrid data accordingly
     * </summary>
     */
    [Serializable]
    public class HandleAestridInput : IStartableJob
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
         * A reference to the player input
         * </summary>
         */
        private PlayerInput _input = null;

        /**
         * <summary>
         * A reference to the movement data
         * </summary>
         */
        private TerestrialMovement _movement = null;

        # endregion

        # region PropertyAccessors

        public JobMethod Method { get => JobMethod.Update; }

        # endregion

        # region PublicMethods

        /**
         * <inheritdoc/>
         */
        public void Init(MonoController controller)
        {
            _input    = controller.GetComponent<PlayerInput>();
            _movement = controller.GetData<TerestrialMovement>();
        }

        /**
         * <summary>
         * When the job start
         * </summary>
         */
        public void Start()
        {
            _input.onActionTriggered += HandleInput;
        }

        /**
         * <inheritdoc/>
         */
        public void Handle()
        {
        }

        /**
         * <inheritdoc/>
         */
        public void Stop()
        {
            _input.onActionTriggered -= HandleInput;
        }

        # endregion

        # region PrivateMethods

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
            if (_jumpInputName == ctx.action.name && ctx.started)
            {
                _movement.requestJump = true;
            }
        }

        # endregion
    }
}
