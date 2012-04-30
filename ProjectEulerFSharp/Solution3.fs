namespace ProjectEulerFSharp

open System
open System.Numerics
open ProjectEulerCore.Infrastructure

[<Problem(3, "The prime factors of 13195 are 5, 7, 13 and 29. What is the largest prime factor of the number 600851475143 ?")>]
type Solution3() =
    let target = 600851475143L

    member this.Solve() =
        let rec maxPrimeFactor (acc:int64) (factor:int64) =
            if acc = 1L then factor
            elif acc % factor = 0L then maxPrimeFactor (acc / factor) factor
            else maxPrimeFactor acc (factor + 1L)

        maxPrimeFactor target 2L
