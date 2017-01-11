namespace Cosmetics.Contracts
{
    using Cosmetics.Common;

    public interface IShampoo : IProduct
    {
         uint Mililitres { get; }

        UsageType Usage { get; }


    }
}