using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Data
{
    /**
     * <summary>
     * Contains a collection of hit boxes and a special method RequestHit
     * </summary>
     */
    [Serializable]
    public class AttackCollectionData
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
        public List<AttackData> boxes;

        /**
         * <summary>
         * The current index of the collection.
         * </summary>
         */
        [HideInInspector]
        public int index = 0;

        /**
         * <summary>
         * Freeze the ability to hit
         * </summary>
         */
        [HideInInspector]
        public bool isFrozen = false;

        /**
         * <summary>
         * Request a hit
         * </summary>
         */
        [HideInInspector]
        public bool requestHit = false;

        # endregion

        # region PropertyAccessors

        /**
         * <summary>
         * Retrieve the current hit box
         * </summary>
         */
        public AttackData Hit { get => boxes[index]; }

        /**
         * <summary>
         * Test if the collection has been triggered
         * </summary>
         */
        public bool IsTriggered { get => requestHit && !isFrozen; }

        # endregion

        /**
         * <summary>
         * Add a listener to all hit boxes
         * </summary>
         */
        public void AddListener(UnityAction<GameObject, GameObject> callback)
        {
            boxes.ForEach(b => b.onHit.AddListener(callback));
        }

        /**
         * <summary>
         * Remove a listener from all the boxes
         * </summary>
         */
        public void RemoveListener(UnityAction<GameObject, GameObject> callback)
        {
            boxes.ForEach(b => b.onHit.RemoveListener(callback));
        }
    }
}
