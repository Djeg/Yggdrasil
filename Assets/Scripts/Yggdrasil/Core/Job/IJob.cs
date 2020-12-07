using Yggdrasil.Core.Controller;

namespace Yggdrasil.Core.Job
{
    /**
     * <summary>
     * Define the behaviour of a system that handle one data.
     * </summary>
     */
    public interface IJob
    {
        # region Properties

        JobMethod Method { get; }

        # endregion

        # region Methods

        /**
         * <summary>
         * This method is executed when the job is created. It matches
         * the Awake method of a mono behaviour
         * </summary>
         */
        void Init(MonoController controller);

        /**
         * <summary>
         * Handle a given behaviour of a controller. For example
         * a PlayerController can have a MoveJob which handle
         * the player movement.
         * </summary>
         */
        void Handle();

        # endregion
    }
}
