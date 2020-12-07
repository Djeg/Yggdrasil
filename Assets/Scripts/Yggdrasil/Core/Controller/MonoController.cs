using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Yggdrasil.Core.Job;

namespace Yggdrasil.Core.Controller
{
    /**
     * <summary>
     * A controller is a special mono behaviours which contains parametrable Data
     * and Jobs wich operate on specific data.
     *
     * A Data is generaly a simple Serializable Struct or class wich contains various
     * scalar data.
     *
     * A Job is implementing the IJob interface and is run at the Update,
     * FixedUpdate or LateUpdate depending on it's JobMethod attribute.
     *
     * In order to make a controller it's very simple. Declare all your
     * data as SerializeField using Serialize Struct or Class. Declare all your
     * job as private attribute and it's done ! Job's will be automatically
     * instanciated and executed during Update, FixedUpdate or LateUpdate :)
     *
     * This controller defines a set of public methods kind of usefull if
     * you want to interact with data or even jobs.
     * </summary>
     */
    public abstract class MonoController : MonoBehaviour
    {
        # region Properties

        /**
         * <summary>
         * Contains all the job
         * </summary>
         */
        private List<IJob> _jobs = new List<IJob>();

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods

        public MonoController()
        {
            List<IJob> jobs = RetrieveJobs();

            foreach (IJob job in jobs)
            {
                AddJob(job);
            }
        }

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
         * Add a job
         * </summary>
         */
        public void AddJob<T>() where T : IJob, new()
        {
            foreach (IJob job in _jobs)
            {
                if (job.GetType() == typeof(T))
                    throw new Exception($"The job {typeof(T).FullName} is already registered in {GetType().FullName}");
            }

            _jobs.Add(Activator.CreateInstance<T>());
        }

        /**
         * <summary>
         * Add a job by using it's instance
         * </summary>
         */
        public void AddJob(IJob job)
        {
            if (_jobs.Exists(j => j.GetType() == job.GetType()))
                throw new Exception($"The job {job.GetType().FullName} is already registered in {GetType().FullName}");

            _jobs.Add(job);
        }

        /**
         * <summary>
         * Retrieve a Job
         * </summary>
         */
        public T GetJob<T>() where T : IJob
        {
            IJob job = _jobs.Find(j => j.GetType() == typeof(T));

            if (null == job)
                throw new Exception($"The job {typeof(T).FullName} is not registered in {GetType().FullName}");

            return (T)job;
        }

        /**
         * <summary>
         * Test if a specific job exists
         * </summary>
         */
        public bool HasJob<T>() where T : IJob =>
            _jobs.Exists(j => typeof(T) == j.GetType());

        public bool HasJob(IJob job) =>
            _jobs.Exists(j => job.GetType() == j.GetType());

        /**
         * <summary>
         * Remove a job
         * </summary>
         */
        public void RemoveJob<T>() where T : IJob
        {
            _jobs.RemoveAll(j => j.GetType() == typeof(T));
        }

        # endregion

        # region PrivateMethods

        /**
         * <summary>
         * Register all the job stored in attributes inside this controller.
         * </summary>
         */
        private void Awake()
        {
            foreach (IJob job in _jobs)
            {
                job.Init(this);
            }
        }

        /**
         * <summary>
         * Start job on component enabled
         * </summary>
         */
        private void OnEnable() =>
            _jobs
            .FindAll(j => {
                IStartableJob job = j as IStartableJob;

                return null != job;
            })
            .ForEach(j => {
                IStartableJob job = j as IStartableJob;
                job.Start();
            });

        /**
         * <summary>
         * Stop jobs when disabled
         * </summary>
         */
        private void OnDisabled() =>
            _jobs
            .FindAll(j => {
                IStartableJob job = j as IStartableJob;

                return null != job;
            })
            .ForEach(j => {
                IStartableJob job = j as IStartableJob;
                job.Stop();
            });

        /**
         * <summary>
         * Trigger all update job
         * </summary>
         */
        private void Update() =>
            _jobs
            .FindAll(j => j.Method == JobMethod.Update)
            .ForEach(j => j.Handle());

        /**
         * <summary>
         * Trigger all fixed update job
         * </summary>
         */
        private void FixedUpdate() =>
            _jobs
            .FindAll(j => j.Method == JobMethod.FixedUpdate)
            .ForEach(j => j.Handle());

        /**
         * <summary>
         * Trigger all late update job
         * </summary>
         */
        private void LateUpdate() =>
            _jobs
            .FindAll(j => j.Method == JobMethod.LateUpdate)
            .ForEach(j => j.Handle());

        /**
         * <summary>
         * Draw gismos
         * </summary>
         */
        private void OnDrawGizmos() =>
            _jobs
            .FindAll(j => {
                IGizmosJob job = j as IGizmosJob;

                return null != job;
            })
            .ForEach(j => {
                IGizmosJob job = j as IGizmosJob;
                job.DrawGizmos(this);
            });

        /**
         * <summary>
         * Draw gismos selected
         * </summary>
         */
        private void OnDrawGizmosSelected() =>
            _jobs
            .FindAll(j => {
                IGizmosJob job = j as IGizmosJob;

                return null != job;
            })
            .ForEach(j => {
                IGizmosJob job = j as IGizmosJob;
                job.DrawGizmosSelected(this);
            });

        /**
         * <summary>
         * Retrieve all jobs attached to this component using reflection
         * </summary>
         */
        private List<IJob> RetrieveJobs()
        {
            List<IJob> jobs = new List<IJob>();
            FieldInfo[] fields = GetType().GetFields(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly
            );

            foreach (FieldInfo field in fields)
            {
                Type propertyType = field.FieldType;
                Type[] jobInterfaces = propertyType.GetInterfaces();

                foreach (Type jobInterface in jobInterfaces)
                {
                    if (
                        jobInterface.Namespace != "Yggdrasil.Core.Job"
                        || jobInterface.Name != "IJob"
                    ) {
                        continue;
                    }

                    IJob instance = (IJob)Activator.CreateInstance(propertyType);
                    jobs.Add(instance);
                }
            }

            return jobs;
        }

        # endregion
    }
}
