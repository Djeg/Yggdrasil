using Yggdrasil.Core.Controller;

namespace Yggdrasil.Core.Job
{
    /**
     * <summary>
     * Allow a job to draw gizmos data
     * </summary>
     */
    public interface IGizmosJob : IJob
    {
        # region Properties
        # endregion

        # region Methods

        void DrawGizmos(MonoController controller);

        void DrawGizmosSelected(MonoController controller);

        # endregion
    }
}
