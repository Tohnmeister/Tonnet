namespace Tonnet
{
    
    /// <summary>
    /// Represents a scope-bound resource manager that mimics RAII (Resource
    /// Acquisition Is Initialization) from C++. Executes a user-provided
    /// creation action upon construction and a destruction action upon
    /// disposal, managing the lifetime of an object of type <typeparamref
    /// name="T"/>. This ensures that resources are properly initialized and
    /// cleaned up in a deterministic manner using the IDisposable pattern.
    /// </summary>
    public sealed class Scoped<T>(Func<T> createFunc, Action<T> destroyAction) : IDisposable
    {
        private readonly T resource = createFunc();
        private bool isDisposed = false;

        public void Dispose()
        {
            if (isDisposed) return;

            isDisposed = true;
            destroyAction(resource);
        }
    }
}
