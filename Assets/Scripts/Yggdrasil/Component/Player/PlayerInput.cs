using System.Collections;
using UnityEngine;

namespace Yggdrasil.Component.Player
{
    /**
     * <summary>
     * The class contains all the data needed to handle the player controller
     * input.
     * </summary>
     */
    public class PlayerInput : MonoBehaviour
    {
        # region Properties

        /**
         * <summary>
         * The horinzontal movement 
         * </summary>
         */
        public float horizontalMovement = 0f;

        /**
         * <summary>
         * Is it jumping
         * </summary>
         */
        public bool jumping = false;

        /**
         * <summary>
         * Is it attacking
         * </summary>
         */
        public bool attacking = false;

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods

        /**
         * <summary>
         * Refresh the input based on the static Input instance
         * </summary>
         */
        public void Update()
        {
            horizontalMovement = Input.GetAxis("Horizontal");
            jumping            = Input.GetButtonDown("Jump");
            attacking          = Input.GetButtonDown("Fire1");
        }

        # endregion

        # region PrivateMethods
        # endregion
    }
}
