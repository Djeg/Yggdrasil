namespace Yggdrasil.Core.Job
{
    /**
     * <summary>
     * Define the ability of a job to start and stop. It matches the
     * OnEnable and OnDisable method on a MonoBehaviour.
     * </summary>
     */
    public interface IStartableJob : IJob
    {
        # region Properties
        # endregion

        # region Methods

        /**
         * <summary>
         * Start a job. Match the OnEnable of a mono behaviour.
         * </summary>
         */
        void Start();

        /**
         * <summary>
         * Stop a job. Match the OnDisable of a mono behaviour.
         * </summary>
         */
        void Stop();

        # endregion
    }
}
