using System;
using System.Collections.Generic;
using System.Linq;
using Tydbits.DressingUp.Clothing;
using Tydbits.DressingUp.Rules;
using Tydbits.DressingUp.State;

namespace Tydbits.DressingUp.Policies
{
    // Main business logic implementation, providing state transition decisions to State.
    // Delegates On/Off implementaion to Rules.
    public abstract class CommonPolicy : IPolicy
    {
        public abstract bool IsApplicable(ClothingType clothing);

        public bool CanPutOn(IState state, ClothingType clothing)
        {
            return IsApplicable(clothing) &&
                PutOnRules(clothing).All(rule => rule.IsSatisfied(state));
        }

        protected virtual IEnumerable<IRule> PutOnRules(ClothingType clothing)
        {
            if (ClothingSet.Street.Contains(clothing))
                yield return new OffRule(ClothingType.Pajamas);

            switch (clothing)
            {
                case ClothingType.Pajamas:
                case ClothingType.Socks:
                case ClothingType.Shirt:
                case ClothingType.Pants:
                    break;
                case ClothingType.Footwear:
                    if (IsApplicable(ClothingType.Socks))
                        yield return new OnRule(ClothingType.Socks);
                    if (IsApplicable(ClothingType.Pants))
                        yield return new OnRule(ClothingType.Pants);
                    break;
                case ClothingType.Headwear:
                case ClothingType.Jacket:
                    if (IsApplicable(ClothingType.Shirt))
                        yield return new OnRule(ClothingType.Shirt);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(clothing), clothing, null);
            }
        }

        public bool CanLeave(IState state)
        {
            return LeaveRules().All(rule => rule.IsSatisfied(state));
        }

        protected virtual IEnumerable<IRule> LeaveRules()
        {
            return ClothingSet.Street.Where(IsApplicable).Select(item => new OnRule(item));
        }
    }
}