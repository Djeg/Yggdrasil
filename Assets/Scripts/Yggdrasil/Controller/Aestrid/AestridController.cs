using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Yggdrasil.Core.Controller;
using Yggdrasil.Data.Movement;
using Yggdrasil.Data.Physic.HitBox;
using Yggdrasil.Job.Movement;
using Yggdrasil.Job.Aestrid;
using Yggdrasil.Job.Physic;

namespace Yggdrasil.Controller.Aestrid
{
    /**
     * <summary>
     * Contains jobs and data used to control the player.
     * </summary>
     */
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Animator))]
    public class AestridController : MonoController
    {
        /**
         * <summary>
         * The character movement data
         * </summary>
         */
        [SerializeField]
        [Header("Data")]
        private TerestrialMovement _terestrialMovement;

        /**
         * <summary>
         * The character hit boxes
         * </summary>
         */
        [SerializeField]
        private HitBoxCollection _hitBoxCollection;

        /**
         * <summary>
         * Move player job
         * </summary>
         */
        [SerializeField]
        [Header("Job")]
        private HandleAestridInput _aestridInputJob;

        /**
         * <summary>
         * Handle the Terestrial movement
         * </summary>
         */
        [SerializeField]
        private HandleTerestrialMovement _terestrialMovementJob;

        /**
         * <summary>
         * Handle animator data
         * </summary>
         */
        [SerializeField]
        private HandleAestridAnimator _aestridAnimatorJob;

        /**
         * <summary>
         * The hit box collection jox
         * </summary>
         */
        [SerializeField]
        private HandleHitBoxCollection _hitBixCollectionJob;
    }
}
