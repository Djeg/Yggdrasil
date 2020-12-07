using System;
using UnityEngine;
using Yggdrasil.Core.Controller;
using Yggdrasil.Data.Effect;
using Yggdrasil.Job.Effect;

namespace Yggdrasil.Controller.Effect
{
    /**
     * <summary>
     * Contains data and job to make the background parallax
     * </summary>
     */
    [RequireComponent(typeof(SpriteRenderer))]
    public class BackgroundParallaxController : MonoController
    {
        /**
         * <summary>
         * The brackground parallax data
         * </summary>
         */
        [SerializeField]
        [Header("Data")]
        private ParallaxBackground _parallax;

        /**
         * <summary>
         * The background parallax job
         * </summary>
         */
        [SerializeField]
        [Header("Job")]
        private HandleParallaxBackground _parallaxJob;
    }
}
