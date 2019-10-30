using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YugiohDeck.Core
{
    readonly struct Option<T>
    {
        public static readonly Option<T> None = new Option<T>(false, default);

        private readonly T value;
        public readonly bool IsValid;

        private Option(bool isValid, T value)
        {
            this.IsValid = isValid;
            this.value = value;
        }

        public T Unwrap()
        {
            if (!this.IsValid)
            {
                throw new InvalidOperationException("Try to unwrap an invalid data.");
            }
            return this.value;
        }

        public Option<U> MapValid<U>(Func<T, U> map)
        {
            if (this.IsValid)
            {
                return Option<U>.Some(map(this.Unwrap()));
            }
            else
            {
                return Option<U>.None;
            }
        }

        public Option<U> AndThen<U>(Func<T, Option<U>> map)
        {
            if (this.IsValid)
            {
                return map(this.Unwrap());
            }
            else
            {
                return Option<U>.None;
            }
        }

        public static Option<T> Some(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            return new Option<T>(true, value);
        }
    }
}
