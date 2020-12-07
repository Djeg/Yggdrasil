using System.Collections;

namespace Yggdrasil.Core.Job
{
    /**
     * <summary>
     * Define on which mono behaviour method this job must be
     * executed.
     * </summary>
     */
    public enum JobMethod
    {
        Update,
        FixedUpdate,
        LateUpdate
    }
}
