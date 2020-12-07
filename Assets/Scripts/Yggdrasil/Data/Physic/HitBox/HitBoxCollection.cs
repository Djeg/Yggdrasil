using System;
using System.Collections.Generic;
using UnityEngine;

namespace Yggdrasil.Data.Physic.HitBox
{
    /**
     * <summary>
     * Contains a collection of hit boxes and a special method RequestHit
     * </summary>
     */
    [Serializable]
    public class HitBoxCollection
    {
        # region Properties

        /**
         * <summary>
         * The layer that contains the game objects that this character
         * can touch.
         * </summary>
         */
        [Tooltip("The layer used for hit collision")]
        public LayerMask layer = Physics2D.AllLayers;

        /**
         * <summary>
         * A collection of hit boxes
         * </summary>
         */
        [Tooltip("The list of hit boxes. Can have many since a character can have many attacks")]
        public List<HitBox> boxes = new List<HitBox>();

        /**
         * <summary>
         * The current index of the collection.
         * </summary>
         */
        [HideInInspector]
        public int index = 0;

        # endregion

        # region PropertyAccessors

        /**
         * <summary>
         * Retrieve the current hit box
         * </summary>
         */
        public HitBox Hit { get => boxes[index]; }

        # endregion
    }
}
