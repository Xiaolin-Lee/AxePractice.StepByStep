using System;
using System.Collections.Generic;

namespace Manualfac
{
    public class ContainerBuilder
    {
        readonly List<Action<ComponentRegistry>> callbacks = new List<Action<ComponentRegistry>>();
        bool hasBeenBuilt;

        public void RegisterCallback(Action<ComponentRegistry> callback)
        {
            if (callback == null) { throw new ArgumentNullException(nameof(callback)); }
            callbacks.Add(callback);
        }

        public Container Build()
        {
            if (hasBeenBuilt)
            {
                throw new InvalidOperationException("The container has been built.");
            }

            #region Please implement the code to pass the test

            /*
             * Since all the build operation can be considered as constructing the
             * ComponentRegistry. Please create a component registry and construct
             * its data. Then attach the registry to Container.
             * 
             */

            hasBeenBuilt = true;
            var registory = new ComponentRegistry();
            foreach (var callback in callbacks)
            {
                callback(registory);
            }

            return new Container(registory);

            #endregion
        }
    }
}