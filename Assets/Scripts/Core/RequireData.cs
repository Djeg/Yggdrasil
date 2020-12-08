using System;

namespace Core
{
    /**
     * <summary>
     * This attribute controls if a behaviour possess the corect data.
     * </summary>
     */
    [AttributeUsage(AttributeTargets.Class, Inherited=true, AllowMultiple=true)]
    public class RequireData : Attribute
    {

        /**
         * <summary>
         * Retrieve the associated type.
         * </summary>
         */
        public Type DataType { get; private set; }

        /**
         * <summary>
         * Create an attribute
         * </summary>
         */
        public RequireData(Type dataType)
        {
            DataType = dataType;
        }
    }
}
