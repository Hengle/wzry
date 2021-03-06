﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public static class ReadonlyContextExtension
{
    public static void AddRange<T>(this List<T> InListRef, ReadonlyContext<T> InTarget)
    {
        ReadonlyContext<T>.Enumerator enumerator = InTarget.GetEnumerator();
        while (enumerator.MoveNext())
        {
            InListRef.Add(enumerator.Current);
        }
    }
}

