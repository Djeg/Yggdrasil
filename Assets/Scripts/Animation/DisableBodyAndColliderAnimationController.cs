using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animation
{
    /**
     * <summary>
     * Disable the rigidbody and the collider of a game object during the
     * animation.
     * </summary>
     */
    public class DisableBodyAndColliderAnimationController : StateMachineBehaviour
    {
        # region Properties

        /**
         * <summary>
         * Enable the body and collider when exit
         * </summary>
         */
        [SerializeField]
        private bool _enableOnExit = false;

        /**
         * <summary>
         * The rigidbody2D reference
         * </summary>
         */
        private Rigidbody2D _body = null;

        /**
         * <summary>
         * The collider2D reference
         * </summary>
         */
        private Collider2D _collider = null;

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods

        /**
         * <inheritdoc/>
         */
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _body     = animator.GetComponent<Rigidbody2D>();
            _collider = animator.GetComponent<Collider2D>();

            _body.isKinematic = true;
            _collider.enabled = false;
        }

        /**
         * <inheritdoc/>
         */
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!_enableOnExit)
                return;

            _body.isKinematic = false;
            _collider.enabled = true;
        }

        # endregion

        # region PrivateMethods
        # endregion
    }
}
