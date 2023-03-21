using Auth.Data.Classes;

namespace Auth.Data
{
    public class Factory
    {
        public Factory()
            : this( typeof(User), typeof(Group), typeof(Permission) )
        {
        }

        public Factory( params Type[] types ) 
        { 
            Constructs = new List<Type>( types );
        }

        private static IList<Type> Constructs { get; set; } = new List<Type>();

        public T? Create<T>() 
        {
            var type = typeof( T );

            if ( ! Constructs.Contains( type ) ) return Cast<T>(null);
            return Cast<T>( Activator.CreateInstance( type, null ) );
        }

        public static T? Cast<T>(object? obj)
        {
            return (T?) obj;
        }
    }
}
