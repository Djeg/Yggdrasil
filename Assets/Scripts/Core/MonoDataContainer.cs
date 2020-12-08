using System;
using System.Reflection;
using System.Collections;
using UnityEngine;

namespace Core
{
    /**
     * <summary>
     * This mono data container is a special mono behaviour wich **must**
     * only contains data needed in order to make the object behaviour.
     *
     * You can easily access those data by using the `GetData<DataClass>()`
     * in order to retrieve a data class of a scriptable object
     * and iteract with them.
     * </summary>
     */
    public class MonoDataContainer : MonoBehaviour
    {
        # region Properties
        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods

        /**
         * <summary>
         * Retrieve a given data by given it's type.
         * </summary>
         */
        public T GetData<T>()
        {
            Type t = typeof(T);
            FieldInfo[] fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == t)
                    return (T)field.GetValue(this);
            }

            throw new Exception($"{gameObject.name} does not contains the {t.FullName} data.");
        }

        /**
         * <summary>
         * Test if this data container has some data.
         * </summary>
         */
        public bool HasData<T>()
        {
            Type t = typeof(T);
            FieldInfo[] fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == t)
                    return true;
            }

            return false;
        }

        # endregion

        # region PrivateMethods
        # endregion
    }
}
