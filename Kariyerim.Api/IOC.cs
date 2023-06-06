namespace Kariyerim.Api
{
    public class Ioc
    {
        private static Dictionary<Type, Type> registered = new Dictionary<Type, Type>();
        public static void Register<TBase, TClass>() where TClass : class, new()
        {
            registered.Add(typeof(TBase), typeof(TClass));
        }

        public static TInterface Instance<TInterface>()
        {
            var type = registered[typeof(TInterface)];
            var result = Activator.CreateInstance(type);
            return (TInterface)result;
        }
    }
}
