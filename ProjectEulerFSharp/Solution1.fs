namespace ProjectEulerFSharp

open System
open ProjectEulerCore.Infrastructure

[<Problem(1, "Add all the natural numbers below one thousand that are multiples of 3 or 5.")>]
type Solution1 =
    new() = { }
    
    member this.SolveBruteForce() =
        Seq.sum(seq { for x in 1 .. 999 do if (x % 3 = 0) || (x % 5 = 0) then yield x })
