using Auth.Data;
using Auth.Data.Classes;
using Autofac;

namespace Auth.App
{
    internal class Program
    {
        static IContainer Container { get; set; }

        static IUnitOfWork UnitOfWork { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var builder = new ContainerBuilder();
            builder.RegisterType<Factory>()
                .UsingConstructor(new DefaultConstructorSelector())
                .SingleInstance();
            Container = builder.Build();

            var user = Container.Resolve<Factory>().Create<User>();


            //UnitOfWork = new UnitOfWork();

            //CreateModel();
            //ShowModel();
        }

        static void CreateModel()
        {
            Group group = UnitOfWork.GetRepository<Group>().Create();
            group.Name = "Administrators";
            group.Description = "Admin Groups";
            UnitOfWork.GetRepository<Group>().Insert(group);

            User? user1 = UnitOfWork.GetRepository<User>().Create();
            user1.Username = "tester1";
            user1.Groups.Add( group );
            group.Users.Add( user1 );
            UnitOfWork.GetRepository<User>().Insert(user1);

            User? user2 = UnitOfWork.GetRepository<User>().Create();
            user2.Username = "tester2";
            user2.Groups.Add(group);
            group.Users.Add(user2);
            UnitOfWork.GetRepository<User>().Insert(user2);
        }

        static void ShowModel()
        {
            foreach( var group in UnitOfWork.GetRepository<Group>().GetAll() )
            {
                Console.WriteLine($"Group: {group.Name}");
                foreach( var user in group.Users ) 
                {
                    Console.WriteLine($"    User:  { user.Username }");
                }
            }

            foreach ( var user in UnitOfWork.GetRepository<User>().GetAll() )
            {
                Console.Write($"User: {user.Username}, ");
                Console.WriteLine( $"Groups: { string.Join( ",", user.Groups.Select( e => e.Name ) ) }");
            }
        }
    }
}