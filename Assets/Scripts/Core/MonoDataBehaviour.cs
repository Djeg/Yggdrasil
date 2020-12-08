using System;
using System.Reflection;
using System.Collections;
using UnityEngine;

namespace Core
{
    /**
     * <summary>
     * This class allows to interact with data container easilty. It provides
     * easy access method such has `GetData<T>()` and `HasData<T>()`. Note
     * that the method `Awake` has been replaced by the `Init` method.
     * </summary>
     */
    [RequireComponent(typeof(MonoDataContainer))]
    public class MonoDataBehaviour : MonoBehaviour
    {
        # region Properties

        /**
         * <summary>
         * A reference to the MonoDataContainer attached to this game object
         * </summary>
         */
        protected MonoDataContainer _dataContainer = null;

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods

        /**
         * <summary>
         * A simple helper to retrieve a data container
         * </summary>
         */
        public T GetData<T>()
        {
            if (null == _dataContainer)
                _dataContainer = GetComponent<MonoDataContainer>();

            return _dataContainer.GetData<T>();
        }

        /**
         * <summary>
         * A simple helper to test of the MonoDataContainer contains the data.
         * </summary>
         */
        public bool HasData<T>()
        {
            if (null == _dataContainer)
                _dataContainer = GetComponent<MonoDataContainer>();

            return _dataContainer.HasData<T>();
        }

        /**
         * <summary>
         * Set a given data. This is usefull when working for struct.
         * </summary>
         */
        public void SetData<T>(T data)
        {
            if (!HasData<T>())
            {
                throw new Exception($"Unable to set the data {typeof(T).Name} because {gameObject.name} does not have the data.");
            }

            FieldInfo[] fields = _dataContainer.GetType().GetFields(
                BindingFlags.Instance
                | BindingFlags.NonPublic
                | BindingFlags.Public
            );

            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == typeof(T))
                {
                    field.SetValue(_dataContainer, data);

                    return;
                }
            }
        }

        # endregion

        # region PrivateMethods

        /**
         * <summary>
         * Create the data container reference
         * </summary>
         */
        protected void Awake()
        {
            _dataContainer = GetComponent<MonoDataContainer>();

            CheckDataRequirements();

            Init(_dataContainer);
        }

        /**
         * <summary>
         * The method that replace the awake
         * </summary>
         */
        protected virtual void Init(MonoDataContainer container)
        {
        }

        /**
         * <summary>
         * Check if any data requirements is failling
         * </summary>
         */
        private void CheckDataRequirements()
        {
            RequireData[] requireDataTypes = (RequireData[])GetType()
                .GetCustomAttributes(typeof(RequireData), true);

            foreach (RequireData attribute in requireDataTypes)
            {
                if (!HasDataType(attribute.DataType))
                {
                    throw new Exception($"{gameObject.name} does not posses the {attribute.DataType.Name} in their MonoDataContainer.");
                }
            }
        }

        /**
         * <summary>
         * Test if the given data type is present inside the MonoDataContainer
         * </summary>
         */
        private bool HasDataType(Type t)
        {
            FieldInfo[] fields = _dataContainer.GetType().GetFields(
                BindingFlags.Instance
                | BindingFlags.NonPublic
                | BindingFlags.Public
            );

            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == t)
                    return true;
            }

            return false;
        }

        # endregion
    }
}
