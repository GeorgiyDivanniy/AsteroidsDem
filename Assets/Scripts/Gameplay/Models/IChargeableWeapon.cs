using System;

namespace Models
{
    public interface IChargeableWeapon
    {
        event Action<int,int> OnChargeChanged;
        event Action<float> OnCooldownProgressChanged;
    }
}