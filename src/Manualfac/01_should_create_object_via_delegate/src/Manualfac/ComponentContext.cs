using System;
using System.Collections.Generic;

namespace Manualfac
{
    public class ComponentContext : IComponentContext
    {
        #region Please modify the following code to pass the test

        /*
         * A ComponentContext is used to resolve a component. Since the component
         * is created by the ContainerBuilder, it brings all the registration
         * information. 
         * 
         * You can add non-public member functions or member variables as you like.
         */

        private readonly Dictionary<Type, Func<IComponentContext, object>> registerRepository;
        public ComponentContext(Dictionary<Type, Func<IComponentContext, object>> registerRepository)
        {
            this.registerRepository = registerRepository;
        }
        public object ResolveComponent(Type type)
        {
            if (registerRepository.ContainsKey(type))
            {
                return registerRepository[type](this);
            }

            throw new DependencyResolutionException();
        }

        #endregion
    }
}