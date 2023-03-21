using Autofac.Core;
using Autofac.Core.Activators.Reflection;

namespace Auth.App
{
    public class DefaultConstructorSelector : IConstructorSelector
    {
        public BoundConstructor SelectConstructorBinding( BoundConstructor[] bindings, IEnumerable<Parameter> parameters)
        {
            var constructor = bindings.SingleOrDefault( c => c.TargetConstructor.GetParameters().Length == 0 );

            // Handle the case when there is no default constructor
            if ( constructor == null ) throw new InvalidOperationException();
            return constructor;
        }
    }
}
