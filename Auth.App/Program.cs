using Auth.Data;
using Auth.Data.Classes;
using Auth.Data.InMemory;
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
            builder.RegisterType<UnitOfWork>()
                .UsingConstructor(new DefaultConstructorSelector())
                .As<IUnitOfWork>()
                .SingleInstance();
            Container = builder.Build();


            CreateModel();
            ShowModel();
        }

        static void CreateModel()
        {
            var unitOfWork = Container.Resolve<IUnitOfWork>();

            Group group = unitOfWork.GetRepository<Group>().Create();
            group.Name = "Administrators";
            group.Description = "Admin Groups";
            unitOfWork.GetRepository<Group>().Insert(group);

            User? user1 = unitOfWork.GetRepository<User>().Create();
            user1.Username = "tester1";
            user1.Groups.Add( group );
            group.Users.Add( user1 );
            unitOfWork.GetRepository<User>().Insert(user1);

            User? user2 = unitOfWork.GetRepository<User>().Create();
            user2.Username = "tester2";
            user2.Groups.Add(group);
            group.Users.Add(user2);
            unitOfWork.GetRepository<User>().Insert(user2);
        }

        static void ShowModel()
        {
            var unitOfWork = Container.Resolve<IUnitOfWork>();

            foreach ( var group in unitOfWork.GetRepository<Group>().GetAll() )
            {
                Console.WriteLine($"Group: {group.Name}");
                foreach( var user in group.Users ) 
                {
                    Console.WriteLine($"    User:  { user.Username }");
                }
            }

            foreach ( var user in unitOfWork.GetRepository<User>().GetAll() )
            {
                Console.Write($"User: {user.Username}, ");
                Console.WriteLine( $"Groups: { string.Join( ",", user.Groups.Select( e => e.Name ) ) }");
            }
        }
    }
}