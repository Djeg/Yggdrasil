using System;
using System.Collections.Generic;
using UnityEngine;

namespace Yggdrasil.Data.Character
{
    /**
     * <summary>
     * Contains all the data needed in order to physicaly create one or more
     * hit boxes.
     * </summary>
     */
    [Serializable]
    public class CharacterHitBoxes
    {
        # region Properties

        /**
         * <summary>
         * The layer that contains the game objects that this character
         * can touch.
         * </summary>
         */
        public LayerMask layer = Physics2D.AllLayers;

        /**
         * <summary>
         * A collection of hit boxes
         * </summary>
         */
        public List<HitBox> boxes = new List<HitBox>();

        # endregion

        # region PropertyAccessors
        # endregion
    }

    /**
     * <summary>
     * Contains the hit box data
     * </summary>
     */
    [Serializable]
    public class HitBox
    {
        /**
         * <summary>
         * The hit box position (relative to it's parent game object)
         * </summary>
         */
        public Vector2 position = Vector2.zero;

        /**
         * <summary>
         * The hit box radius
         * </summary>
         */
        public float radius = .5f;

        /**
         * <summary>
         * Draw or not this hit box on screen
         * </summary>
         */
        public bool debug = false;

        /**
         * <summary>
         * The color attached to the debug circle
         * </summary>
         */
        public Color color = Color.red;

        /**
         * <summary>
         * Ask for this hit box to request a hit
         * </summary>
         */
        [HideInInspector]
        public bool requestHit = false;
    }
}
