using System;
using UnityEngine;
using System.Collections.Generic;
using Yggdrasil.Core.Controller;
using Yggdrasil.Core.Job;
using Yggdrasil.Data.Character;

namespace Yggdrasil.Job.Character
{
    /**
     * <summary>
     * Handle the character hit boxes
     * </summary>
     */
    [Serializable]
    public class HandleCharacterHitBoxes : IGizmosJob
    {
        # region Properties
        # endregion

        # region PropertyAccessors

        /**
         * <inheritdoc/>
         */
        public JobMethod Method { get => JobMethod.FixedUpdate; }

        # endregion

        # region PublicMethods

        /**
         * <inheritdoc/>
         */
        public void Init(MonoController controller)
        {
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
        public void DrawGizmos(MonoController controller)
        {
        }

        /**
         * <inheritdoc/>
         */
        public void DrawGizmosSelected(MonoController controller)
        {
            CharacterHitBoxes hitBoxes = controller.GetData<CharacterHitBoxes>();
            Vector3 position = controller.gameObject.transform.position;

            hitBoxes
                .boxes
                .FindAll(b => b.debug)
                .ForEach(b => {
                    Gizmos.color = b.color;

                    Vector3 center = new Vector3(
                        position.x + b.position.x,
                        position.y + b.position.y,
                        position.z
                    );

                    Gizmos.DrawWireSphere(center, b.radius);
                })
            ;
        }

        # endregion

        # region PrivateMethods
        # endregion
    }
}
