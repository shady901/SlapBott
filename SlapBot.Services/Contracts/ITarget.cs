

using SlapBott.Data.Enums;

namespace SlapBott.Services.Contracts
{
    public interface ITarget
    {


        public void ApplyDamage(int damage, StatType elementalType);

    }
}
