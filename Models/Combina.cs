using System;
using System.Collections.Generic;
using System.Linq;

namespace exanim.Models
{
    public static class Combina
    {
        public static IEnumerable<IEnumerable<T>> Cuadro<T>(this IEnumerable<T> lista, int num)
        {
            if (num == 0)
            {
                return new[] { new T[0] };
            }
            else
            {
                /*
                return Cuadro(lista.Skip(1), num - 1)
                    .Select(marca => Enumerable.Repeat(lista.First(), 1).Union(marca))
                    .Union(Cuadro(lista.Skip(1), num));
                */
                return lista.SelectMany((ele, ind) => lista.Skip(ind + 1).Cuadro(num - 1).Select(
                    c => (new[] { ele }).Concat(c)));
            }
        }
    }
}
